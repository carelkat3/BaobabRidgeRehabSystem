using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeRehabSystem
{
    public class ReadData
    {
       //Reads all lines from text file for datahandler
        public static string[] ReadAllLines(string filePath)
        {
            if (!File.Exists(filePath)) 
            {
                File.Create(filePath).Close();
                return new string[0];
            }

            return File.ReadAllLines(filePath);
        }
    }
}
