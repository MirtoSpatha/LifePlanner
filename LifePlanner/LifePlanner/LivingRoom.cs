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
    public partial class LivingRoom : Form
    {
        private int robot_clicks;

        private bool lights_on;
        private bool menu_open;
        private bool tv_on;
        public string channel;
        public Bitmap gif_channel;

        public LivingRoom(Bitmap gif_channel = null, bool lights_on = true, string channel = "", bool tv_on=false)
        {
            InitializeComponent();

            this.lights_on = lights_on;
            this.channel = channel;
            this.gif_channel = gif_channel;
            this.tv_on = tv_on;
        }

        private void LivingRoom_Load(object sender, EventArgs e)
        {
            Misc.manageAssistantfromFile(this, chatbot_panel, "first_livingroom");

            if (tv_on)
                pictureBox1.Image = gif_channel ?? Resource1.tvstatic;
            else
                pictureBox1.Image = null;

            this.BackgroundImage = (lights_on) ? Resource1.living_room_Bright : Resource1.living_room_Dark;

            //disable the menu button that corresponds to the form
            Misc.manageButtons(this, panel1);

            //set initial menu button location
            button1.Location = new Point(panel1.Location.X, panel1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //run show/hide function for menu and return result in menu_open
            menu_open = Misc.ShowHide(this, button1, panel1, menu_open);
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = (lights_on) ? Resource1.living_room_Dark : Resource1.living_room_Bright;
            lights_on = !lights_on;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            Misc.openForm("Hall");
            this.Hide();
        }

        private void tvpanel_MouseClick(object sender, MouseEventArgs e)
        {
            //if gif_channel is null set tvstatic gif to variable
            if (!tv_on)
                pictureBox1.Image = gif_channel ?? Resource1.tvstatic;
            else
                pictureBox1.Image = null;

            tv_on = !tv_on;
        }

        private void αλλαγήΚαναλιούToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!tv_on)
            {
                MessageBox.Show("Παρακαλώ ανοίξτε πρώτα την τηλεόραση!", "Προϊδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TV control = new TV(channel, this, pictureBox1);
            control.Show();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if gif_channel is null set tvstatic gif to variable
            if (!tv_on)
                pictureBox1.Image = gif_channel ?? Resource1.tvstatic;
            else
                pictureBox1.Image = null;

            tv_on = !tv_on;
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            switch (robot_clicks)
            {
                case 0:
                    label2.Text =  "Στο παράθυρο που θα σου εμφανιστεί,\n" +
                                   "εισήγαγε έναν διψήφιο αριθμό πατόντας\n" +
                                   "τα κουμπιά και μετά πάτα 'ΟΚ'.Αν θες να\n" +
                                   "αλλάξεις την επιλογή σου, πάτα πρώτα\n" +
                                   "'Εκαθάριση'";
                    robot_clicks += 1;
                    break;

                default:
                    //hide robot and enable the other controls
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = true;
                        else if (c.Parent == chatbot_panel || c == chatbot_panel)
                            c.Enabled = c.Visible = false;
                    }

                    //change the file variable for this assistant
                    Misc.changeAssistantStateInFile("first_livingroom");

                    break;
            }
        }

        private void Hallbtn_Click(object sender, EventArgs e)
        {
            String form = ((Button)sender).Name.Replace("btn", "");
            Misc.openForm(form);
            this.Hide();           
        }
        private void LivingRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            LivingRoom lr = new LivingRoom(gif_channel, lights_on, channel, tv_on);
            lr.Show();
            lr.Hide();
        }
    }
}
