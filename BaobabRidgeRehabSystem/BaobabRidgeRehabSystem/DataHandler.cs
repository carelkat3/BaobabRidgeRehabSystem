using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaobabRidgeRehabSystem
{   
    //Processes data from ReadData class into a readable format for datagridview
    internal class DataHandler
    {
        // Full path to animals.txt in the same folder as the running .exe (Section 5.1).
        // A bare "animals.txt" would depend on the current working directory, which is not
        // always the .exe folder (for example when launched from a shortcut).
        public static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");
        public static List<Animal> GetAnimals()
        {
            List<Animal> animalList = new List<Animal>();

            string[] lines = ReadData.ReadAllLines(filePath);

            int skippedLines = 0; //Keeps track of malformed lines in text file

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                // Validation Rule: Must have exactly 7 fields
                if (parts.Length != 7)
                {
                    skippedLines++;
                    continue;
                }

                parts[0].Trim().ToUpper(); //id
                parts[1].Trim();           //name
                parts[2].Trim();           //species
                parts[5].Trim();           //status
                parts[6].Trim();           //housing unit

                // Validation Rule: Animal ID must be "WR-" followed by 4 digits
                // ^ means start of line
                // WR- always starts with this
                // \d is any digit from 0-9
                // {4} meaning 4 \d in a row
                // $ Meaning end of line
                if (!Regex.IsMatch(parts[0], @"^WR-\d{4}$"))
                {
                    skippedLines++;
                    continue;
                }

                // Validation Rule: Age must be a whole number between 0 and 100
                if (!int.TryParse(parts[3].Trim(), out int age) || age < 0 || age > 100)
                {
                    skippedLines++;
                    continue;
                }

                // Validation Rule: Recovery Score must be a whole number between 0 and 100
                if (!int.TryParse(parts[4].Trim(), out int score) || score < 0 || score > 100)
                {
                    skippedLines++;
                    continue;
                }



                Animal animal = new Animal(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5], parts[6]);
                animalList.Add(animal);
            }

            if (skippedLines > 0)
            {
                MessageBox.Show($"{skippedLines} line(s) were skipped while loading records.",
                                "Data Load Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return animalList;
        }

    }
}
