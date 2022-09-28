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
    public partial class Messagebox : Form
    {
        private Feeder f;

        public Messagebox(String text, Feeder f)
        {
            InitializeComponent();

            Misc.mblist.Add(this);

            this.f = f;

            label1.Text = text;
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, label1.Location.Y);
            button1.Location = new Point(this.Width / 2 - button1.Width / 2, button1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Messagebox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Misc.mblist.Remove(this);

            //We need to bring to front Feeder form after all message boxes have been closed
            if (Misc.mblist.Count == 0)
                f.BringToFront();
            //When we close one message box we need to bring the others to front
            else
            {
                foreach (Messagebox m in Misc.mblist)
                    m.BringToFront();
            }
            
        }
    }
}
