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
    public partial class LoadingPage : Form
    {
        public LoadingPage()
        {
            InitializeComponent();
            this.Enabled = true;
            this.MinimumSize = new Size(876, 541);
            this.MaximumSize = new Size(876, 541);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                Color.FromArgb(161, 166, 203), 7, ButtonBorderStyle.Solid,
                Color.FromArgb(161, 166, 203), 7, ButtonBorderStyle.Solid,
                Color.FromArgb(161, 166, 203), 7, ButtonBorderStyle.Solid,
                Color.FromArgb(161, 166, 203), 7, ButtonBorderStyle.Solid);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (myProgressBar2.Value < myProgressBar2.Max)
            {
                myProgressBar2.Value++;
                myProgressBar2.Refresh();
            }

            if (myProgressBar2.Value == myProgressBar2.Max)
            {
                timer1.Stop();
                this.Enabled = false;
                this.Hide();
                this.Close();
            }
        }

        private void LoadingPage_Load(object sender, EventArgs e)
        {
            myProgressBar2.Value = 0;
            timer1.Start();
        }
    }
}
