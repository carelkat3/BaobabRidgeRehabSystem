using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaobabRidgeRehabSystem
{
    public class ReadData
    {
       //Reads all lines from text file for datahandler
        public static string[] ReadAllLines(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return new string[0];
                }

                return File.ReadAllLines(filePath);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access error. Please check permissions and make sure the file isnt read-only.",
                                "File Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[0];
            }
            catch (IOException)
            {
                MessageBox.Show("The file 'animals.txt' is currently in use by another program.",
                                "File Lock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[0];
            }
        }
    }
}
