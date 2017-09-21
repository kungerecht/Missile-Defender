//Kevin Ungerecht
//Missile Command for FINAL

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Settings : Form
    {
        public int numMiss;
        public bool speed;
        public int numCities;
        public bool isSaved = false;

        public Settings()
        {
            InitializeComponent();
            this.missileBox.SelectedIndex = 2;
            this.citiesNum.Value = 6;
        }

        private void play(object sender, EventArgs e)
        {
            string m = missileBox.Text;
            if (m.Equals("Unlimited"))
            {
                numMiss = 999;
            }
            else {
                numMiss = Int32.Parse(m);
            }
            numCities = Convert.ToInt32(citiesNum.Value);

            if (radioButton2.Checked.Equals(true))
            {
                speed = true;
            }
            else { speed = false; }

            isSaved = true;
            this.Hide();
        }
    }
}
