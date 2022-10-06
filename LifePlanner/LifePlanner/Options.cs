using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class Options : Form
    {
        int robot_clicks = 0;
        bool first = true;

        public Options()
        {
            InitializeComponent();
        }

        private void chatbot_panel_MouseClick(object sender, MouseEventArgs e)
        {
            switch (robot_clicks)
            {
                case 0:

                    label1.Text = "Κάνε κλικ πανω στο ημερολόγιο\nγια τη δημιουργία του\n" +
                                    "ημερήσιου πλάνου σου ή στο\n" +
                                    "σπιτάκι για να διαχειριστείς τις\n" +
                                    "συσκευές του σπιτιού σου\n" +
                                    "από απόσταση!";

                    panel1.Visible = true;
                    robot_clicks += 1;
                    break;
               case 1:
                    if (first)
                    {

                        label1.Text = "Αν χρειαστείς τη βοήθειά μου,κάνε κλικ\n" +
                                        "στο μπλε κουμπί με το ερωτηματικό\n" +
                                        "στο πάνω δεξιό μέρος της οθόνης, και εγώ\n" +
                                        "θα σου δίνω οδηγίες για τις ενέργειές σου.";

                        first = false;
                        robot_clicks += 1;
                    }
                    else
                    {
                        defCase();
                    }
                    robot_clicks += 1;
                    break;

                default:
                    defCase();
                    break;


            }
        }

        private void defCase()
        {
            //hide robot and enable the other controls
            foreach (Control c in Controls)
            {
                if (c.Parent != chatbot_panel && c != chatbot_panel)
                {
                    c.Enabled = true;
                    c.Visible = true;
                }
                else if (c.Parent == chatbot_panel || c == chatbot_panel)
                    c.Enabled = c.Visible = false;
            }

            //change the file variable for this assistant
            Misc.changeAssistantStateInFile("first_options");
            label1.Text = "Διάλεξε τι θες να κάνεις πρώτα!";
        }

        private void home_pictureBox_Click(object sender, EventArgs e)
        {
            Misc.openForm("Hall");
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
            Misc.openForm("DailyPlan");
        }


        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ms = MessageBox.Show("Είσαι σίγουρος ότι θες να τερματίσεις την εφαρμογή; \n Όλες σου οι αλλαγές θα χαθούν.", "Ector", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (ms.Equals(DialogResult.OK))
            {
                Application.OpenForms[0].Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Misc.changeAssistantStateInFile("first_options", true);
            Misc.manageAssistantfromFile(this, chatbot_panel, "first_options");
            robot_clicks = 0;
            chatbot_panel.Show();
        }

        private void Options_Load(object sender, EventArgs e)
        {           
            panel1.Visible = !Misc.manageAssistantfromFile(this, chatbot_panel, "first_options");
        }
    }
}
