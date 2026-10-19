using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
