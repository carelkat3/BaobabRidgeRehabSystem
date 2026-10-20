using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaobabRidgeRehabSystem
{
    // Feature 3 - Update an animal: search, edit mode, save changes and clear.
    // Reuses ValidateAnimalInputs(false), ClearAnimalInputs() and AnimalClassifier.Classify()
    // from the Add feature instead of copying them.
    public partial class Form1
    {
        // Runs when the user clicks Search: finds the typed ID in animals.txt and loads it into the form.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchId.Text.Trim();

            if (searchText.Length == 0)
            {
                MessageBox.Show("Type an Animal ID to search for (for example WR-0007).",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchId.Focus();
                return;
            }

            Animal found;

            try
            {
                found = FindAnimalById(DataHandler.GetAnimals(), searchText);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                ShowFileError(DescribeFileProblem(ex));
                return;
            }

            if (found == null)
            {
                // Requirement 3.1: tell the user and change nothing else.
                MessageBox.Show("No animal with ID " + searchText.ToUpperInvariant() + " was found.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchId.Focus();
                txtSearchId.SelectAll();
                return;
            }

            LoadAnimalIntoForm(found);
        }

        // Runs when the user clicks a cell in the grid: loads that row's animal into the form.
        private void dgvAnimalRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // the column header was clicked, not a record
            }

            Animal clicked = dgvAnimalRecords.Rows[e.RowIndex].DataBoundItem as Animal;

            if (clicked != null)
            {
                LoadAnimalIntoForm(clicked);
            }
        }

        // Runs when the user clicks Save Changes: validates, changes only the edited record,
        // rewrites animals.txt, then refreshes the grid and returns to Add mode.
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Same rules as Add, but the ID cannot change so it is not checked for uniqueness (3.3).
            Animal edited = ValidateAnimalInputs(false);

            if (edited == null)
            {
                return; // a message was shown and the cursor moved to the bad field
            }

            try
            {
                // Read the current file, change only the edited animal, write everything back (3.4).
                List<Animal> animals = DataHandler.GetAnimals();

                if (!ApplyEditToList(animals, edited.AnimalID, edited.Name, edited.Species,
                        edited.Age, edited.RecoveryScore))
                {
                    MessageBox.Show("Animal " + edited.AnimalID + " is no longer in animals.txt, so nothing was changed.",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AnimalFileWriter.SaveAll(DataHandler.filePath, animals);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                ShowFileError(DescribeFileProblem(ex) + " The changes were not saved.");
                return;
            }

            MessageBox.Show(
                "Animal " + edited.AnimalID + " (" + edited.Name + ") was updated." + Environment.NewLine + Environment.NewLine +
                "Status: " + edited.Status + Environment.NewLine +
                "Housing Unit: " + edited.HousingUnit,
                "Animal Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ExitEditMode();
            RefreshGridAfterAdd(); // reloads the grid and reports a refresh failure without crashing (3.5)
        }

        // Runs when the user clicks Clear: leaves edit mode and empties the form.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ExitEditMode();
        }

        // Puts the form back in Add mode with empty boxes. Delete can call this too
        // when the animal that was loaded for editing gets deleted.
        private void ExitEditMode()
        {
            SetEditMode(false);
            txtSearchId.Clear();
            ClearAnimalInputs();
        }

        // Copies an animal's values into the input boxes and switches the form to edit mode.
        private void LoadAnimalIntoForm(Animal animal)
        {
            txtAnimalId.Text = animal.AnimalID;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtAge.Text = animal.Age.ToString();
            txtRecoveryScore.Text = animal.RecoveryScore.ToString();
            SetEditMode(true);
        }

        // Edit mode: ID box read-only, Add disabled, Save Changes enabled. Add mode is the reverse (3.2).
        private void SetEditMode(bool editing)
        {
            txtAnimalId.ReadOnly = editing;
            btnAdd.Enabled = !editing;
            btnSaveChanges.Enabled = editing;
        }

        // Turns a file exception into a friendly message (never a stack trace).
        private string DescribeFileProblem(Exception ex)
        {
            if (ex is UnauthorizedAccessException)
            {
                return "The program does not have permission to change animals.txt. " +
                       "Check that the file is not set to read-only, then try again.";
            }
            if (ex is DirectoryNotFoundException)
            {
                return "The folder that should contain animals.txt could not be found.";
            }
            return "animals.txt is being used by another program. Close it in the other program and try again.";
        }

        // Finds the animal whose ID matches the search text (exact match, ignoring case
        // and surrounding spaces). Returns null if the text is empty or nothing matches.
        private Animal FindAnimalById(List<Animal> animals, string searchId)
        {
            string trimmedId = (searchId ?? string.Empty).Trim();

            if (trimmedId.Length == 0)
            {
                return null;
            }

            return animals.FirstOrDefault(a =>
                string.Equals(a.AnimalID, trimmedId, StringComparison.OrdinalIgnoreCase));
        }

        // Applies the edited values to the single animal with the given ID and recalculates
        // its status and housing unit. Every other animal in the list is left untouched.
        // Returns false if no animal with that ID exists.
        private bool ApplyEditToList(List<Animal> animals, string animalId, string name,
            string species, int age, int recoveryScore)
        {
            Animal target = FindAnimalById(animals, animalId);

            if (target == null)
            {
                return false;
            }

            // Status and housing always come from the one shared classification method,
            // even if the score is unchanged (requirement 3.3).
            var (status, housingUnit) = AnimalClassifier.Classify(recoveryScore);

            target.Name = name;
            target.Species = species;
            target.Age = age;
            target.RecoveryScore = recoveryScore;
            target.Status = status;
            target.HousingUnit = housingUnit;

            return true;
        }

        // Connects the Update controls to their handlers when the form loads
        // (done in code so the shared Form1.cs and the designer file need no extra edits).
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnSearch.Click += btnSearch_Click;
            btnSaveChanges.Click += btnSaveChanges_Click;
            btnClear.Click += btnClear_Click;
            dgvAnimalRecords.CellClick += dgvAnimalRecords_CellClick;
        }
    }
}