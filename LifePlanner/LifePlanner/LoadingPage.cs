using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Timer = System.Windows.Forms.Timer;

namespace LifePlanner
{
    public partial class LoadingPage : Form
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        private void LoadingPage_Load(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.Size = new Size(876, 541);
            myProgressBar2.Value = 0;
            timer1.Start();
            timer1.Enabled = true;
            this.label1.ForeColor = Color.FromArgb(68, 67, 104);
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

        private void myProgressBar2_Load(object sender, EventArgs e)
        {

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
                Hide();
                if (Program.NewUser == true)
                {
                    new Start().Show();
                }
                else
                {
                    Misc.openForm("Options");
                }
            }
        }
    }
}
