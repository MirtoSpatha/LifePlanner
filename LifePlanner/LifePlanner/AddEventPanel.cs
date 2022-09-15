using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LifePlanner
{
    public partial class AddEventPanel : UserControl
    {
        string StartTime;
        string EndTime;

        public AddEventPanel(string StartTime)
        {
            InitializeComponent();
            BringToFront();
            this.StartTime = StartTime;
        }

        private void AddEventPanel_Load(object sender, EventArgs e)
        {
            // date and time
            Date_label.Text = Program.Date.ToString();
            comboBox1.Text = StartTime;
            var current = comboBox1.SelectedIndex;
            string after = comboBox1.Items[current + 1].ToString();
            comboBox2.Text = after;
            //comboBox2.Text = DateTime.ParseExact(StartTime, "HH:mm",null).AddHours(1).ToString();
            EndTime = comboBox2.Text;
            // Address
            textBox2.Hide();
            // transportation
            comboBox4.Hide();
            radioButton4.Text = Program.transportation + " (Προεπιλογή)";
            /*
            int index = Program.items.IndexOf(radioButton4.Text);
            List<string> result = Program.items;
            result.RemoveAt(index);
            radioButton5.Text = result[0];
            radioButton6.Text = result[1];
            radioButton7.Text = result[2];
            */

            // Drink
            textBox3.Hide();
            radioButton10.Text = Program.drink + " (Προεπιλογή)";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartTime = comboBox1.SelectedIndex.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EndTime = comboBox2.SelectedIndex.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            Hide();
        }

        public void plan_Event()
        {
            return;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            Hide();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Show();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Show();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
                textBox1.Text = "Τίτλος:";
        }
    }
}
