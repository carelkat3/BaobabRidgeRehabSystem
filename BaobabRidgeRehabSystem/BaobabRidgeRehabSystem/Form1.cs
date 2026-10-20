using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaobabRidgeRehabSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BuildSummaryPanel(); // Feature 5 controls are built in code (see Form1.Summary.cs)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayAnimals();
        }

        private void displayAnimals()
        {
            List<Animal> animals = DataHandler.GetAnimals();
            dgvAnimalRecords.DataSource = animals;
        }
    }
}
