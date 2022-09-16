using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
        string selected_activity;
        string selected_address;
        string selected_transportation;
        string selected_beverage;
        private Dictionary<string,string> event_info = new Dictionary<string,string>();

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

            // Beverage
            textBox3.Hide();
            radioButton10.Text = Program.beverage + " (Προεπιλογή)";

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Τίτλος:")
                textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Τίτλος:";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            StartTime = comboBox1.Text;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            EndTime = comboBox2.Text;
        }
       
        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            selected_activity = comboBox3.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                selected_address = Program.address;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                selected_address = Program.work_address;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox2.Show();
                selected_address = textBox2.Text;
            }
            else
            {
                textBox2.Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                selected_address = textBox2.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                selected_transportation = Program.transportation;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
                selected_transportation = radioButton5.Text;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
                selected_transportation = radioButton6.Text;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
                selected_transportation = radioButton7.Text;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                comboBox4.Show();
                selected_transportation = comboBox4.Text;
            }
            else
            {
                comboBox4.Hide();
            } 
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
                selected_transportation = comboBox4.Text;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
                selected_beverage = "Nothing";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
                selected_beverage = Program.beverage;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox3.Show();
                selected_beverage = textBox3.Text;
            }
            else
            {
                textBox3.Hide();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                selected_beverage = textBox3.Text;
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            Hide();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            event_info.Add("Title", textBox1.Text);
            event_info.Add("Start Time", StartTime);
            event_info.Add("End Time", EndTime);
            event_info.Add("Activity", selected_activity);
            event_info.Add("Address", selected_address);
            event_info.Add("Transportation", selected_transportation);
            event_info.Add("Beverage", selected_beverage);
            foreach (string value in event_info.Values)
            {
                MessageBox.Show(value);
            }
            Parent.Hide();
            Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
