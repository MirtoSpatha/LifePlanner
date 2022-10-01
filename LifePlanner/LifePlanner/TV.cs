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
        private ResourceManager rm = new ResourceManager("LifePlanner.Resource1", Assembly.GetExecutingAssembly());
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
            rm = new ResourceManager("LifePlanner.Resource1", Assembly.GetExecutingAssembly());
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

            /*string resxFile = @"..\..\Resource1.resx";
            ResXResourceReader resxReader = new ResXResourceReader(resxFile);
            foreach (DictionaryEntry entry in resxReader)
            {
                if (((string)entry.Key).StartsWith(gif_name))
                {
                    tvscreen.Image = form.gif_channel = (Bitmap)entry.Value;
                    form.channel = channel.ToString();
                }
                    
            }*/

            /*switch (gif_name)
            {
                case ("ch1"):
                    tvscreen.Image = form.gif_channel = Resource1.ch1;
                    break;

                case ("ch2"):
                    tvscreen.Image = form.gif_channel = Resource1.ch2;
                    break;

                case ("ch3"):
                    tvscreen.Image = form.gif_channel = Resource1.ch3;
                    break;

                case ("ch4"):
                    tvscreen.Image = form.gif_channel = Resource1.ch4;
                    break;

                case ("ch5"):
                    tvscreen.Image = form.gif_channel = Resource1.ch5;
                    break;

                case ("ch6"):
                    tvscreen.Image = form.gif_channel = Resource1.ch6;
                    break;
            }*/

            tvscreen.Image = form.gif_channel = (Bitmap)rm.GetObject(gif_name);
            form.channel = channel.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
