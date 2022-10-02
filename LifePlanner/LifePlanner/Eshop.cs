using System;
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
    public partial class Eshop : Form
    {
        private ResourceManager rm = new ResourceManager("LifePlanner.Resource1", Assembly.GetExecutingAssembly());
        private String Eshopcategory;
        private Color titlecolor;
        private String[] Eshopsoldout;

        public Eshop(String Eshopcategory, int Eshopcolor, String[] Eshopsoldout)
        {
            InitializeComponent();
            if(Eshopcategory.Equals("Εντός Σπιτιού"))
                this.Eshopcategory = "Εντός_Σπιτιού";
            else
                this.Eshopcategory = Eshopcategory;
            titlecolor = Color.FromArgb(Eshopcolor);
            this.Eshopsoldout = Eshopsoldout;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Eshop_Load(object sender, EventArgs e)
        {
            label1.Padding = new Padding(this.Width / 2 - label1.Width / 2, label1.Padding.Top, this.Width / 2 - label1.Width / 2, label1.Padding.Bottom);
            label1.BackColor = titlecolor;

            label7.Text += Eshopcategory;
            label7.Location = new Point(this.Width / 2 - label7.Width / 2, label7.Location.Y);

            String[] price_list = rm.GetString(Eshopcategory + "τιμές").Split(',');
            label9.Text += (3 - Eshopsoldout.Where(v => v!=null).Count()).ToString();

            label2.Text += " " + price_list[0] + "€";
            label3.Text += " " + price_list[1] + "€";
            label4.Text += " " + price_list[2] + "€";
            label5.Text += " " + price_list[3] + "€";
            if(price_list.Count() == 5)
                label6.Text += " " + price_list[4] + "€";
            else
                label6.Text += " 50€";

            String gender_letter = Program.gender.Equals("Θυληκό") ? "Γ" : "Α";

            //set picturebox images
            for(int i = 1; i<=5; i++)
            {
                PictureBox p = (PictureBox)Controls["picturebox" + i.ToString()];

                var img = rm.GetObject(Eshopcategory + i.ToString());
                if (img != null)
                {
                    p.Image = Eshopsoldout.Contains(Eshopcategory + i.ToString()) ? Resource1.sold_out : (Bitmap)img;
                    continue;
                }

                img = rm.GetObject(Eshopcategory + gender_letter + i.ToString());
                if (img != null)
                {
                    p.Image = Eshopsoldout.Contains(Eshopcategory + gender_letter + i.ToString()) ? Resource1.sold_out : (Bitmap)img;
                    continue;
                }

                p.Image = Resource1.sold_out;
            }
        }
    }
}