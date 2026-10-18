using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeRehabSystem
{   
    //Processes data from ReadData class into a readable format for datagridview
    internal class DataHandler
    {
        public static string filePath = "animals.txt";
        public static List<Animal> GetAnimals()
        {
            List<Animal> animalList = new List<Animal>();

            string[] lines = ReadData.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                Animal animal = new Animal(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5], parts[6]);
                animalList.Add(animal);
            }

            return animalList;
        }

    }
}
