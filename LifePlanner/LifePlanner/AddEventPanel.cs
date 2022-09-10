using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            Date_label.Text = Program.Date.ToString();
            comboBox1.Text = StartTime;
            comboBox2.Text = DateTime.ParseExact(StartTime, "HH:mm",null).AddHours(1).ToString();
            EndTime = comboBox2.Text;
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

        public string plan_Event()
        {
            return;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
