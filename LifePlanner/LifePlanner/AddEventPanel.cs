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
            this.StartTime = StartTime;
        }

        private void AddEventPanel_Load(object sender, EventArgs e)
        {
            // date and time
            Date_label.Text = Program.Date.ToString();
            comboBox1.Text = StartTime;
            comboBox2.Text = DateTime.ParseExact(StartTime, "HH:mm",null).AddHours(1).ToString();
            EndTime = comboBox2.Text;
            // transportation
            StreamReader sr = new StreamReader("names.txt");
            try
            {
                String s = sr.ReadLine();
                while (s != null)
                {
                    if (Program.items.Contains(s))
                    {
                        break;
                    }
                    s = sr.ReadLine();
                }
                if (s == null)
                {
                    MessageBox.Show("Fatal Error, Null Value");
                }
                radioButton4.Text = s;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
            int index = Program.items.IndexOf(radioButton4.Text);
            List<string> result = Program.items;
            result.RemoveAt(index);
            radioButton5.Text = result[0];
            radioButton6.Text = result[1];
            radioButton7.Text = result[2];
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
            Hide();
        }
    }
}
