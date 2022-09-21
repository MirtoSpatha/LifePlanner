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
        string Title;
        string selected_activity;
        string selected_address;
        string selected_transportation;
        string selected_beverage;
        public Dictionary<string,string> event_info = new Dictionary<string,string>();
        //ComboBox.ObjectCollection CItems;

        public AddEventPanel(string StartTime)
        {
            InitializeComponent();
            BringToFront();
            this.StartTime = StartTime;
            /*
            CItems.AddRange(new object[] {
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00",
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00"}); ;
            */
        }

        private void AddEventPanel_Load(object sender, EventArgs e)
        {
            DailyPlan.restricted_hours = DailyPlan.find_restricted_hours();
            //comboBox1.Items.Add(CItems);
            //comboBox2.Items.Add(CItems);
            /*
            foreach (string h in DailyPlan.restricted_hours)
            {
                comboBox1.Items.Remove(h);
                comboBox2.Items.Remove(h);
            }
            */
            event_info.Clear();
            // date and time
            Date_label.Text = Program.Date.ToString();
            comboBox1.Text = StartTime;
            var current = comboBox1.SelectedIndex;
            string after = comboBox1.Items[current + 1].ToString();
            comboBox2.Text = after;
            EndTime = comboBox2.Text;
            // Address
            textBox2.Hide();
            // transportation
            comboBox4.Hide();
            radioButton4.Text = Program.transportation + " (Προεπιλογή)";
            int index = Program.items.IndexOf(Program.transportation);
            List<string> result = new List<string>(Program.items);
            result.RemoveAt(index);
            radioButton5.Text = result[0];
            radioButton6.Text = result[1];
            radioButton7.Text = result[2];
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
            {
                textBox1.Text = "Τίτλος:";
                Title = "null";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "Τίτλος:" && textBox1.Text != "")
                Title = textBox1.Text;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (DailyPlan.restricted_hours.Contains(comboBox1.SelectedItem))
            {
                comboBox1.SelectedIndex = -1;
            }
            else
                StartTime = comboBox1.Text;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (DailyPlan.restricted_hours.Contains(comboBox2.SelectedItem))
            {
                comboBox2.SelectedIndex = -1;
            }
            else
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
            if (radioButton11.Checked == true)
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
            selected_beverage = textBox3.Text;
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            Parent.Visible = false;
            Parent.Hide();
            Hide();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //form validation 
            if (textBox1.Text == "" || textBox1.Text == "Τίτλος:")
            {
                MessageBox.Show("Δώσε έναν τίτλο στη δραστηριότητά σου.");
                textBox1.Text = "Τίτλος:";
                Title = "null";
            }
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Επίλεξε το είδος της δραστηριότητάς σου.");
                selected_activity = "null";
            }
            if (radioButton1.Checked == false & radioButton2.Checked == false & (radioButton3.Checked == false || textBox2.Text == ""))
            {
                MessageBox.Show("Διάλεξε ή συμπλήρωσε μια διεύθυνση της ακόλουθης μορφής: \"Οδός Αριθμός\".");
                selected_address = "null";
            }
            if (radioButton4.Checked == false & radioButton5.Checked == false & radioButton6.Checked == false & radioButton7.Checked == false & (radioButton8.Checked == false || comboBox4.Text == ""))
            {
                MessageBox.Show("Διάλεξε έναν τρόπο μεταφοράς.");
                selected_transportation = "null";
            }
            if (radioButton9.Checked == false & radioButton10.Checked == false & (radioButton11.Checked == false || textBox3.Text == ""))
            {
                MessageBox.Show("Συμπλήρωσε το ρόφημα της αρεσκείας σου.");
                selected_beverage = "null";
            }
            //event added in planner
            if (Title != "null" & selected_activity != "null" & selected_address != "null" & selected_transportation != "null" & selected_beverage != "null")
            {
                event_info.Add("Title", Title);
                event_info.Add("StartTime", StartTime);
                event_info.Add("EndTime", EndTime);
                event_info.Add("Activity", selected_activity);
                event_info.Add("Address", selected_address);
                event_info.Add("Transportation", selected_transportation);
                event_info.Add("Beverage", selected_beverage);
                /*
                foreach (string value in event_info.Values)
                {
                    MessageBox.Show(value);
                }
                */
                //exit event form
                DailyPlan.submit_clicked = true;
                Parent.Hide();
                Hide();
                
            }
            
        }
    }
}
