using System;
using System.IO;
using System.Text;

namespace BaobabRidgeRehabSystem
{
    // Writes animal records to animals.txt. Exceptions (IOException, UnauthorizedAccessException)
    // are deliberately NOT caught here: the form catches them and shows a friendly message.
    internal static class WriteData
    {
        // UTF-8 without a byte-order mark, as required by Section 5.1 of the brief.
        private static readonly Encoding FileEncoding = new UTF8Encoding(false);

        // Builds one line of animals.txt in the required field order:
        // ID | Name | Species | Age | Score | Status | Housing Unit
        public static string FormatLine(Animal animal)
        {
            return string.Join("|",
                animal.AnimalID,
                animal.Name,
                animal.Species,
                animal.Age,
                animal.RecoveryScore,
                animal.Status,
                animal.HousingUnit);
        }

        // Appends one animal as a new line at the end of the file without touching existing lines.
        // Creates the file if it does not exist yet.
        public static void AppendAnimal(string filePath, Animal animal)
        {
            string line = FormatLine(animal);

            // If the last record has no line break after it (the starter file is saved that way),
            // add one first. Otherwise the new record would be glued onto the end of the old one.
            if (FileNeedsLineBreak(filePath))
            {
                line = Environment.NewLine + line;
            }

            File.AppendAllText(filePath, line + Environment.NewLine, FileEncoding);
        }

        // Returns true if the file has content but does not end with a line break.
        private static bool FileNeedsLineBreak(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                if (stream.Length == 0)
                {
                    return false;
                }

                // Only the very last byte needs checking, so jump straight to it.
                stream.Seek(-1, SeekOrigin.End);
                return stream.ReadByte() != '\n';
            }
        }
    }
}
