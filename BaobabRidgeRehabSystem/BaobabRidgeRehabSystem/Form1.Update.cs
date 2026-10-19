using System;
using System.Collections.Generic;
using System.Linq;

namespace BaobabRidgeRehabSystem
{
    // Update feature: search and edit logic for Form1
    public partial class Form1
    {
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
    }
}