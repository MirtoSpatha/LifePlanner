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
    public partial class House : Form
    {
        bool menu_open = false;

        public House()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!menu_open)
            {
                button1.Location = new Point(panel1.Location.X + panel1.Width, panel1.Location.Y);
                panel1.Visible = panel1.Enabled = true;
                button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255,128,128); //red
                menu_open = true;
            }
            else
            {
                button1.Location = new Point(panel1.Location.X, panel1.Location.Y);
                panel1.Visible = panel1.Enabled = false;
                button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128); //green
                menu_open = false;
            }
        }

        private void House_Load(object sender, EventArgs e)
        {
            button1.Location = new Point(panel1.Location.X, panel1.Location.Y);
        }

    }
}
