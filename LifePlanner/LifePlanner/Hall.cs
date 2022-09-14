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
    public partial class Hall : Form
    {
        bool menu_open = false;
        bool lights_on = true;
        String door_status = "Κλειστή";
        int robot_clicks = 0;

        public Hall()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu_open = Misc.ShowHide(this, button1, panel1, menu_open);
        }

        private void House_Load(object sender, EventArgs e)
        {
            button1.Location = new Point(panel1.Location.X, panel1.Location.Y);

            foreach(Control c in Controls)
            {
                if (c.Parent != chatbot_panel && c != chatbot_panel)
                    c.Enabled = false;
            }

        }

        //door lock
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (door_status == "Ανοιχτή") ? Resource1.locked : Resource1.unlocked;
            door_status = (door_status == "Ανοιχτή") ? "Κλειστή" : "Ανοιχτή";
        }

        private void Exit_panel_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Κατάσταση εξώπορτας: " + door_status, "Εξώπορτα", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //lights
        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = (lights_on) ? Resource1.Hallway_Dark : Resource1.Hallway_Bright;
            lights_on = !lights_on;
        }

        private void chatbot_panel_MouseClick(object sender, MouseEventArgs e)
        {
            switch (robot_clicks)
            {
                case 0:
                    label2.Text = "Τα εικονίδια αριστερά από κάθε\n"+
                                    "πόρτα διευκρινίζουν τα δωμάτια.\n"+
                                    "Μπορείς επίσης να περιηγηθείς σε\n"+
                                    "αυτά κάνοντας κλίκ στο μενού πάνω\n"+
                                    "αριστερά!";
                    robot_clicks += 1;
                    break;

                case 1:
                    label2.Text = "Μπορείς να αλληλεπιδράσεις με\n"+
                                    "οτιδήποτε έχει άσπρο περίγραμμα\n"+
                                    "ή με κάποιο εικονίδιο που μετατρέπει\n"+
                                    "τον κέρσορά σου σε χεράκι όταν τον\n"+
                                    "περνάς από πάνω του! Δώσε προσοχή\n"+
                                    "στα σχετικά εικονίδια!";
                    robot_clicks += 1;
                    break;

                default:
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = true;
                        else if (c.Parent == chatbot_panel || c == chatbot_panel)
                            c.Enabled = c.Visible = false;
                    }
                    break;
            }
        }
    }
}
