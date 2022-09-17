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
        private bool lights_on;
        private bool menu_open;

        public LivingRoom(bool lights_on = true)
        {
            InitializeComponent();

            this.lights_on = lights_on;
        }

        private void LivingRoom_Load(object sender, EventArgs e)
        {
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

        private void LivingRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            LivingRoom lr = new LivingRoom(lights_on);
            lr.Show();
            lr.Hide();
        }
    }
}
