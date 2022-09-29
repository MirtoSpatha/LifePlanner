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
    public partial class Bathroom : Form
    {
        private bool lights_on = true;
        private bool menu_open = false;

        public Bathroom()
        {
            InitializeComponent();
        }

        private void Bathroom_Load(object sender, EventArgs e)
        {
            //disable the menu button that corresponds to the form
            Misc.manageButtons(this, panel3);

            //set initial menu button location
            button1.Location = new Point(panel3.Location.X, panel3.Location.Y);
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = (lights_on) ? Resource1.bathroom_Dark : Resource1.bathroom_Bright;
            lights_on = !lights_on;
        }

        private void Hallbtn_Click(object sender, EventArgs e)
        {
            String form = ((Button)sender).Name.Replace("btn", "");
            Misc.openForm(form);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //run show/hide function for menu and return result in menu_open
            menu_open = Misc.ShowHide(this, button1, panel3, menu_open);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Misc.openForm("Hall");
            this.Hide();
        }

        private void Bathroom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
