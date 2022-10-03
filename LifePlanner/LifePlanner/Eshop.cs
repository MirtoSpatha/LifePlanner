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
        private int Eshopcolor;
        private List<String> Eshopsoldout;
        private List<String> Eshopbought;

        private int btn_counter = 0;
        private int limit;
        private int total;

        public Eshop(String Eshopcategory, int Eshopcolor, List<String> Eshopsoldout)
        {
            InitializeComponent();
            
            this.Eshopcategory = Eshopcategory;
            this.Eshopcolor = Eshopcolor;
            this.Eshopsoldout = Eshopsoldout;
            Eshopbought = new List<String>();
        }

        private void Eshop_Load(object sender, EventArgs e)
        {
            label1.Padding = new Padding(this.Width / 2 - label1.Width / 2, label1.Padding.Top, this.Width / 2 - label1.Width / 2, label1.Padding.Bottom);
            label1.BackColor = Color.FromArgb(Eshopcolor);

            label7.Text += Eshopcategory;
            label7.Location = new Point(this.Width / 2 - label7.Width / 2, label7.Location.Y);

            if (Eshopcategory.Equals("Εντός Σπιτιού"))
                Eshopcategory = "Εντός_Σπιτιού";
            
            String[] price_list = rm.GetString(Eshopcategory + "τιμές").Split(',');
            limit = 3 - Eshopsoldout.Count();

            label9.Text += limit.ToString();

            label2.Text += " " + price_list[0] + "€";
            label3.Text += " " + price_list[1] + "€";
            label4.Text += " " + price_list[2] + "€";
            label5.Text += " " + price_list[3] + "€";
            if(price_list.Count() == 5)
                label6.Text += " " + price_list[4] + "€";
            else
                label6.Text += " 50€";

            String gender_letter = Program.gender.Equals("Θυληκό") ? "Γ" : "Α";

            //manage picturebox images and other controls depending on them
            for(int i = 1; i<=5; i++)
            {
                PictureBox p = (PictureBox)Controls["picturebox" + i.ToString()];

                var img = rm.GetObject(Eshopcategory + i.ToString());
                if (img != null)
                {                    
                    if (Eshopsoldout.Contains(Eshopcategory + i.ToString()))
                    {
                        
                        ((Label)Controls["label" + (i + 1).ToString()]).Hide();
                        ((CheckBox)Controls["checkBox" + i.ToString()]).Hide();

                        p.Image = Resource1.sold_out;
                        p.Tag = "soldout";
                    }
                    else
                    {
                        p.Image = (Bitmap)img;
                        p.Tag = Eshopcategory + i.ToString();
                    }
                        
                    continue;
                }

                img = rm.GetObject(Eshopcategory + gender_letter + i.ToString());
                if (img != null)
                {
                    if (Eshopsoldout.Contains(Eshopcategory + gender_letter + i.ToString()))
                    {

                        ((Label)Controls["label" + (i + 1).ToString()]).Hide();
                        ((CheckBox)Controls["checkBox" + i.ToString()]).Hide();

                        p.Image = Resource1.sold_out;
                        p.Tag = "soldout";
                    }
                    else
                    {
                        p.Image = (Bitmap)img;
                        p.Tag = Eshopcategory + gender_letter + i.ToString();
                    }

                    continue;
                }

                p.Image = Resource1.sold_out;
                p.Tag = "soldout";

                ((Label)Controls["label" + (i + 1).ToString()]).Hide();
                ((CheckBox)Controls["checkBox" + i.ToString()]).Hide();
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            int chkbox = Convert.ToInt32(((CheckBox)sender).Name[8].ToString()); //checkbox number
            int price = Convert.ToInt32(((Label)Controls["label" + (chkbox + 1).ToString()]).Text.Substring(6, 2)); //price that corresponds to that checkbox

            if (((CheckBox)sender).Checked)
            {
                btn_counter += 1;
                total += price;
            }
            else
            {
                btn_counter -= 1;
                total -= price;
            }


            if (limit < btn_counter)
            {
                btn_counter -= 1;
                total -= price;
                ((CheckBox)sender).Checked = false;
                MessageBox.Show("Έχεις φτάσει το όριο των παπουτσιών αυτής της κατηγορίας που χωράει η παπουτσοθήκη!", "Ector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Eshopbought.Add(Controls["pictureBox"+ chkbox.ToString()].Tag.ToString());
            label8.Text = "Σύνολο: " + total + "€";
            button2.Text = "Αγορά προϊόντων στο καλάθι(" + btn_counter + ")";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Misc.openForm("EshopConfirm", Eshopcategory, Eshopcolor, Eshopsoldout, Eshopbought, total);
            Hide();
        }
    }
}