using System;

namespace BaobabRidgeRehabSystem
{
    // Holds the ONE classification method required by Section 4 of the brief.
    // Add and Update must both call Classify() so the rules live in a single place.
    internal static class AnimalClassifier
    {
        // Works out an animal's status and housing unit from its Recovery Score (0-100).
        // The spelling of every status and housing unit must match the brief exactly,
        // because these strings are written to animals.txt and checked by assessors.
        public static (string Status, string HousingUnit) Classify(int recoveryScore)
        {
            if (recoveryScore < 0 || recoveryScore > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(recoveryScore),
                    "Recovery Score must be between 0 and 100.");
            }

            // Scores are whole numbers, so checking the upper bound of each band in order
            // leaves no gaps: 19 is Critical, 20 is Serious, 79 is Recovering, 80 is Release-Ready.
            if (recoveryScore <= 19)
            {
                return ("Critical", "Intensive Care Unit");
            }
            if (recoveryScore <= 39)
            {
                return ("Serious", "High-Dependency Ward");
            }
            if (recoveryScore <= 59)
            {
                return ("Stable", "Recovery Ward");
            }
            if (recoveryScore <= 79)
            {
                return ("Recovering", "Outdoor Enclosure");
            }
            return ("Release-Ready", "Pre-Release Camp");
        }
    }
}
