using System;
using System.Collections.Generic;
using System.Linq;

namespace BaobabRidgeRehabSystem
{
    // Update feature: search and edit-mode logic for Form1
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
    }
}