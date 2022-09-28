using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class UserData : Form
    {
        public UserData()
        {
            InitializeComponent();
        }

        private void UserData_Load(object sender, EventArgs e)
        {
            foreach (Control c in data_panel.Controls)
            {
                c.Hide();
            }
            foreach (Control c in chatbot_panel.Controls)
            {
                c.Show();
                c.BringToFront();
            }

            submit_button.Enabled = false;
            submit_button.Hide();

            label1.Show();
            label1.BringToFront();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("UserData.txt", true);
            sw.WriteLine(textBox1.Text); //Username
            sw.WriteLine(comboBox1.Text); //Gender
            sw.WriteLine(textBox2.Text); //Age
            sw.WriteLine(textBox3.Text); //Address
            sw.WriteLine(textBox4.Text); //Work Address
            sw.WriteLine(comboBox2.Text); //Means of Transport
            sw.WriteLine(textBox5.Text); // Show Size
            sw.WriteLine(textBox6.Text); //Favorite Beverage
            sw.WriteLine(comboBox3.Text); //Pet
            sw.Write(Program.Date); //Date
            sw.Close();

            Form form = new Options();
            form.Show();
            Hide();
        }

        private void chatbot_panel_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Control c in data_panel.Controls)
            {
                c.Show();
            }
            foreach (Control c in chatbot_panel.Controls)
            {
                c.Hide();
                c.Enabled = false;
            }
            chatbot_panel.Enabled = false;
            chatbot_panel.Hide();

            submit_button.Enabled = true;
            submit_button.Show();

            label1.Hide();
        }
    }
}
