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
            foreach (Control c in data_panel.Controls)
            {
                c.Hide();
            }
            foreach (Control c in chatbot_panel.Controls)
            {
                c.Show();
                c.BringToFront();
            }
        }

        private void UserData_Load(object sender, EventArgs e)
        {
            
            //chatbot_panel.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
            //data_panel.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
            //data_panel.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            //data_panel.Show();
        }

        private void chatbot_panel_Paint(object sender, PaintEventArgs e)
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
            //data_panel.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //System.Resources.IResourceWriter writer = new System.Resources.IResourceWriter();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("UserData.txt", true);
            sw.WriteLine("Username: " + textBox1.Text);
            sw.WriteLine("Gender: " + comboBox1.Text);
            sw.WriteLine("Age: " + textBox2.Text);
            sw.WriteLine("Address: " + textBox3.Text);
            sw.WriteLine("Work Address: " + textBox4.Text);
            sw.WriteLine("Means of Transport: " + comboBox2.Text);
            sw.WriteLine("Shoe Size: " + textBox5.Text);
            sw.WriteLine("Favorite Beverage: " + textBox6.Text);
            sw.WriteLine("Pet: " + comboBox3.Text);
            sw.Close();

            Form form = new Options();
            form.Show();
        }
    }
}
