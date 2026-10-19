using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BaobabRidgeRehabSystem
{
    // Feature 1 - Add a new animal.
    // ValidateAnimalInputs() and ClearAnimalInputs() are shared so the Update feature can reuse them.
    public partial class Form1
    {
        // Runs when the user clicks Add: validates every field, works out the status and
        // housing unit, appends one line to animals.txt, then refreshes the grid and clears the boxes.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Animal newAnimal;

            try
            {
                // Reading the file (for the uniqueness check) can also fail, so it sits inside the try.
                newAnimal = ValidateAnimalInputs(true);
                if (newAnimal == null)
                {
                    return; // A message has already been shown and the cursor moved to the bad field.
                }

                WriteData.AppendAnimal(DataHandler.filePath, newAnimal);
            }
            catch (DirectoryNotFoundException)
            {
                ShowFileError("The folder that should contain animals.txt could not be found. The animal was not saved.");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                ShowFileError("The program does not have permission to change animals.txt. " +
                              "Check that the file is not set to read-only, then try again. The animal was not saved.");
                return;
            }
            catch (IOException)
            {
                // Most often the file is open in another program (for example Excel) and is locked.
                ShowFileError("animals.txt is being used by another program. " +
                              "Close it in the other program and try again. The animal was not saved.");
                return;
            }

            MessageBox.Show(
                "Animal " + newAnimal.AnimalID + " (" + newAnimal.Name + ") was added." + Environment.NewLine + Environment.NewLine +
                "Status: " + newAnimal.Status + Environment.NewLine +
                "Housing Unit: " + newAnimal.HousingUnit,
                "Animal Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshGridAfterAdd();
            ClearAnimalInputs();
        }

        // Validates the five input boxes in order (ID, Name, Species, Age, Recovery Score).
        // On the first problem it shows a message naming the field, puts the cursor back in
        // that box and returns null. If everything is valid it returns a fully classified Animal.
        // checkIdIsUnique is true for Add and false for Update (the ID cannot change when editing).
        private Animal ValidateAnimalInputs(bool checkIdIsUnique)
        {
            // Rule from Section 3: all typed text is trimmed before it is validated.
            string animalId = AnimalValidator.NormaliseAnimalId(txtAnimalId.Text);
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string scoreText = txtRecoveryScore.Text.Trim();

            ICollection<string> existingIds = checkIdIsUnique ? GetExistingAnimalIds() : null;

            string error = AnimalValidator.ValidateAnimalId(animalId, existingIds);
            if (error != null)
            {
                return RejectField(txtAnimalId, error);
            }

            error = AnimalValidator.ValidateText(name, "Name");
            if (error != null)
            {
                return RejectField(txtName, error);
            }

            error = AnimalValidator.ValidateText(species, "Species");
            if (error != null)
            {
                return RejectField(txtSpecies, error);
            }

            error = AnimalValidator.ValidateWholeNumber(ageText, "Age", out int age);
            if (error != null)
            {
                return RejectField(txtAge, error);
            }

            error = AnimalValidator.ValidateWholeNumber(scoreText, "Recovery Score", out int recoveryScore);
            if (error != null)
            {
                return RejectField(txtRecoveryScore, error);
            }

            // Status and housing unit always come from the single shared classification method.
            var classification = AnimalClassifier.Classify(recoveryScore);

            return new Animal(animalId, name, species, age, recoveryScore,
                              classification.Status, classification.HousingUnit);
        }

        // Reads the first field (the ID) of every line in animals.txt so duplicates can be blocked.
        // Raw lines are checked, not just the valid ones, so a new ID can never clash with any line.
        private ICollection<string> GetExistingAnimalIds()
        {
            HashSet<string> ids = new HashSet<string>();

            foreach (string line in ReadData.ReadAllLines(DataHandler.filePath))
            {
                string id = AnimalValidator.NormaliseAnimalId(line.Split('|')[0]);
                if (id.Length > 0)
                {
                    ids.Add(id);
                }
            }

            return ids;
        }

        // Shows a validation message for one field, moves the cursor back to it and returns null.
        private Animal RejectField(TextBox field, string message)
        {
            MessageBox.Show(message, "Invalid " + GetFieldLabel(field), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            field.Focus();
            field.SelectAll();
            return null;
        }

        // Returns the human-readable name of an input box, used in the message box title.
        private string GetFieldLabel(TextBox field)
        {
            if (field == txtAnimalId) return "Animal ID";
            if (field == txtName) return "Name";
            if (field == txtSpecies) return "Species";
            if (field == txtAge) return "Age";
            return "Recovery Score";
        }

        // Empties all five input boxes and puts the cursor in the Animal ID box, ready for the next animal.
        private void ClearAnimalInputs()
        {
            txtAnimalId.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
            txtAnimalId.Focus();
        }

        // Reloads the grid after a successful add. The record is already saved at this point,
        // so if reloading fails the user is told the save worked rather than the program crashing.
        private void RefreshGridAfterAdd()
        {
            try
            {
                displayAnimals();
            }
            catch (Exception)
            {
                ShowFileError("The animal was saved, but the list could not be refreshed. " +
                              "Restart the program to see the latest records.");
            }
        }

        // Shows a friendly file-related error (never a stack trace) and keeps the program running.
        private void ShowFileError(string message)
        {
            MessageBox.Show(message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
