using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BaobabRidgeRehabSystem
{
    // Validation rules from Section 3 of the brief. Each method returns null when the value
    // is valid, or a friendly message that names the field when it is not.
    // Add uses all of them; Update uses the same ones but skips the uniqueness check.
    internal static class AnimalValidator
    {
        public const int MaxTextLength = 30;
        public const int MinWholeNumber = 0;
        public const int MaxWholeNumber = 100;

        // WR- followed by exactly 4 digits. [0-9] is used instead of \d because \d also
        // matches non-English digits (for example Arabic-Indic numerals).
        private static readonly Regex AnimalIdPattern = new Regex(@"^WR-[0-9]{4}$");

        // Only plain digits are allowed, so "3.5", "-1", "+4" and "abc" are all rejected.
        private static readonly Regex WholeNumberPattern = new Regex(@"^[0-9]+$");

        // Trims the typed ID and converts it to upper case, so " wr-0007 " becomes "WR-0007".
        public static string NormaliseAnimalId(string rawId)
        {
            return (rawId ?? string.Empty).Trim().ToUpperInvariant();
        }

        // Checks that the (already normalised) ID is present, in WR-0000 format, and not already used.
        public static string ValidateAnimalId(string animalId, ICollection<string> existingIds)
        {
            if (animalId.Length == 0)
            {
                return "Animal ID is required.";
            }
            if (!AnimalIdPattern.IsMatch(animalId))
            {
                return "Animal ID must be the letters WR- followed by exactly 4 digits (for example WR-0007).";
            }
            if (existingIds != null && existingIds.Contains(animalId))
            {
                return "Animal ID " + animalId + " already exists. Each animal must have a unique ID.";
            }
            return null;
        }

        // Checks a required text field (Name or Species): 1-30 characters and no pipe character.
        public static string ValidateText(string value, string fieldName)
        {
            if (value.Length == 0)
            {
                return fieldName + " is required.";
            }
            if (value.Length > MaxTextLength)
            {
                return fieldName + " must be between 1 and " + MaxTextLength + " characters (it is currently " + value.Length + ").";
            }
            // The pipe separates fields in animals.txt, so allowing it would corrupt the file.
            if (value.Contains("|"))
            {
                return fieldName + " must not contain the pipe character |.";
            }
            return null;
        }

        // Checks a required whole number from 0 to 100 (Age or Recovery Score).
        // On success the parsed number is returned through the out parameter.
        public static string ValidateWholeNumber(string value, string fieldName, out int number)
        {
            number = 0;
            string rangeMessage = fieldName + " must be a whole number between " + MinWholeNumber + " and " + MaxWholeNumber + ".";

            if (value.Length == 0)
            {
                return fieldName + " is required. " + rangeMessage;
            }
            // TryParse also fails for numbers too big for an int (e.g. 99999999999), so no crash.
            if (!WholeNumberPattern.IsMatch(value) || !int.TryParse(value, out number))
            {
                return rangeMessage;
            }
            if (number < MinWholeNumber || number > MaxWholeNumber)
            {
                return rangeMessage;
            }
            return null;
        }
    }
}
