using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeRehabSystem
{
    internal class Animal
    {
        //Initialization of variables
        public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; }
        public string HousingUnit { get; set; }


        //Constructor for feature 2
        public Animal(string _animalID, string _name, string _species, int _age, int _recoveryScore, string _status, string _housingUnit)
        {
            AnimalID = _animalID;
            Name = _name;
            Species = _species;
            Age = _age;
            RecoveryScore = _recoveryScore;
            Status = _status;
            HousingUnit = _housingUnit;
        }

    }
}
