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
    public partial class Alarm : Form
    {
        public Alarm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int new_hours = (Convert.ToInt32(label1.Text) + 1) % 24;

            label1.Text = new_hours.ToString().Length == 1 ? "0" + new_hours.ToString() : new_hours.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int new_hours = Convert.ToInt32(label1.Text) - 1;
            if (new_hours < 0)
                new_hours = 23;

            label1.Text = new_hours.ToString().Length == 1 ? "0" + new_hours.ToString() : new_hours.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int new_minutes = (Convert.ToInt32(label3.Text) + 1) % 60;

            label3.Text = new_minutes.ToString().Length == 1 ? "0" + new_minutes.ToString() : new_minutes.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int new_minutes = Convert.ToInt32(label3.Text) - 1;
            if (new_minutes < 0)
                new_minutes = 59;

            label3.Text = new_minutes.ToString().Length == 1 ? "0" + new_minutes.ToString() : new_minutes.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string time = label1.Text + ":" + label3.Text;
            string[] alarms = richTextBox1.Lines;
            if (alarms.Contains(time))
                MessageBox.Show("Αυτή η ώρα υπάρχει ήδη!", "Προϊδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                richTextBox1.AppendText(time + "\n");
        }

        private void Alarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Alarm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
