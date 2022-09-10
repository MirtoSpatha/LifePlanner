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
        public Options()
        {
            InitializeComponent();
        }

        private void chatbot_panel_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = panel1.Enabled = true;
            foreach (Control c in panel1.Controls)
            {
                c.Visible = true;
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
            this.Hide();
            House h = new House();
            h.Show();
        }
    }
}
