using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BaobabRidgeRehabSystem
{
    public partial class Form1
    {
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string animalId = AnimalValidator.NormaliseAnimalId(txtAnimalId.Text);
            string validationError = AnimalValidator.ValidateAnimalId(animalId, null);

            if (validationError != null)
            {
                MessageBox.Show(validationError, "Invalid Animal ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalId.Focus();
                txtAnimalId.SelectAll();
                return;
            }

            try
            {
                string[] lines = ReadData.ReadAllLines(DataHandler.filePath);
                List<string> remainingLines = new List<string>();
                bool animalFound = false;

                foreach (string line in lines)
                {
                    string[] fields = line.Split('|');
                    string lineAnimalId = fields.Length > 0
                        ? AnimalValidator.NormaliseAnimalId(fields[0])
                        : string.Empty;

                    if (!animalFound && lineAnimalId == animalId)
                    {
                        animalFound = true;
                    }
                    else
                    {
                        remainingLines.Add(line);
                    }
                }

                if (!animalFound)
                {
                    MessageBox.Show("No animal with ID " + animalId + " was found.",
                        "Animal Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult confirmation = MessageBox.Show(
                    "Are you sure you want to delete animal " + animalId + "?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (confirmation != DialogResult.Yes)
                {
                    return;
                }

                File.WriteAllLines(DataHandler.filePath, remainingLines, new UTF8Encoding(false));
            }
            catch (DirectoryNotFoundException)
            {
                ShowFileError("The folder that should contain animals.txt could not be found. The animal was not deleted.");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                ShowFileError("The program does not have permission to change animals.txt. " +
                              "Check that the file is not set to read-only, then try again. The animal was not deleted.");
                return;
            }
            catch (IOException)
            {
                ShowFileError("animals.txt is being used by another program. " +
                              "Close it in the other program and try again. The animal was not deleted.");
                return;
            }

            MessageBox.Show("Animal " + animalId + " was deleted.",
                "Animal Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            displayAnimals();
            txtAnimalId.Clear();
            txtAnimalId.Focus();
        }
    }
}
