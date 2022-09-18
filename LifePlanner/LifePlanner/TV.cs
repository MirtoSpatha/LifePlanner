using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class TV : Form
    {
        private PictureBox tvscreen;
        private LivingRoom form;
        private string channel;

        public TV(string channel, LivingRoom form, PictureBox tvscreen)
        {
            InitializeComponent();
            this.tvscreen = tvscreen;
            this.form = form;
            this.channel = channel;
        }

        private void TV_Load(object sender, EventArgs e)
        {
            textBox1.Text = channel;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Length == 2)
                return;

            textBox1.Text += ((Button)sender).Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                return;
            }

            int channel = Convert.ToInt32(textBox1.Text);
            String gif_name = (channel % 6 != 0) ? "ch" + (channel % 6).ToString() : "ch6";

            string resxFile = @"..\..\Resource1.resx";
            ResXResourceReader resxReader = new ResXResourceReader(resxFile);
            foreach (DictionaryEntry entry in resxReader)
            {
                if (((string)entry.Key).StartsWith(gif_name))
                {
                    tvscreen.Image = form.gif_channel = (Bitmap)entry.Value;
                    form.channel = channel.ToString();
                }
                    
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
