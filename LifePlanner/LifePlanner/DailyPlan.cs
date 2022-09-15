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
    public partial class DailyPlan : Form
    {
        AddEventPanel event_panel = null;
        public DailyPlan()
        {
            InitializeComponent();
        }

        private void DailyPlan_Load(object sender, EventArgs e)
        {
            label2.Text = Program.Date.ToString();
            panel2.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                Color.Transparent, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid);
            
        }

        private void panelt5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelt5_MouseClick(object sender, MouseEventArgs e)
        {
            event_panel = new AddEventPanel("05:00");
            panel2.Size = event_panel.Size;
            panel2.Anchor = AnchorStyles.None;
            event_panel.Parent = panel2;
            panel2.Show();
            //panel.Show();
        }

        private void panel2_VisibleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
