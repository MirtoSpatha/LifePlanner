using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class Options : Form
    {
        bool first = true;

        public Options()
        {
            InitializeComponent();
        }

        private void chatbot_panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (first)
            {
                panel1.Visible = panel1.Enabled = true;
                foreach (Control c in panel1.Controls)
                {
                    c.Visible = true;
                }

                label1.Text = "Κάνε κλικ πανω στο ημερολόγιο\nγια τη δημιουργία του\n" +
                "ημερήσιου πλάνου σου ή στο\n" +
                "σπιτάκι για να διαχειριστείς τις\n" +
                "συσκευές του σπιτιού σου\n" +
                "από απόσταση!";

                first = false;

                return;
            }

            foreach (Control c in panel1.Controls)
            {
                c.Enabled = true;
            }
            
            chatbot_panel.Visible = chatbot_panel.Enabled = false;
            foreach (Control c in chatbot_panel.Controls)
            {
                c.Visible = false;
                c.Enabled = false;
            }
        }

        private void home_pictureBox_Click(object sender, EventArgs e)
        {
            Misc.openForm("Hall");
            this.Hide();
        }

        private void home_pictureBox_MouseHover(object sender, EventArgs e)
        {

            ((PictureBox)sender).BackColor = Color.FromArgb(128, 255, 128);
        }

        private void home_pictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }

        private void calendar_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void food_and_pet_timer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int rand_int = r.Next(1, 11);
            
            //40% propability at every tick to eat food
            //20% to drop by 10% and 20% to drop by 20%
            if (rand_int >= 1 && rand_int <= 4)
            {
                double result = (double)rand_int / 2;
                Misc.food_percentage -= (int) Math.Ceiling(result) * 10;
            }
            //40% propability at every tick to drink water
            //20% to drop by 10% and 20% to drop by 20%
            else if (rand_int >= 5 && rand_int <= 8)
            {
                double result = (double)rand_int / 6;
                Misc.water_percentage -= (int)Math.Ceiling(result) * 10;
            }
            //20% propability at every tick for pet to kick something
            //10% to kick food and 10% to kick water
            //loss is 40%
            else if(rand_int == 9)
            {
                Misc.old_food_percentage = Misc.food_percentage;
                Misc.food_percentage -= 40;
            }
            else
            {
                Misc.old_water_percentage = Misc.water_percentage;
                Misc.water_percentage -= 40;
            }

            //if food/water percentage drops to 0 or less
            if (Misc.food_percentage <= 0)
            {
                //if both percentages droped
                if (Misc.water_percentage <= 0)
                    pet_timer.Enabled = false;

                Misc.food_percentage = 0;
                Misc.openForm("Feeder");
                return;
            }
            else if(Misc.water_percentage <= 0)
            {
                //if both percentages droped
                if (Misc.food_percentage <= 0)
                    pet_timer.Enabled = false;

                Misc.water_percentage = 0;
                Misc.openForm("Feeder");
                return;
            }

            //if food/water had been kicked
            if(Misc.old_food_percentage != 0 || Misc.old_water_percentage != 0)
            {
                Misc.openForm("Feeder");
            }

        }
    }
}
