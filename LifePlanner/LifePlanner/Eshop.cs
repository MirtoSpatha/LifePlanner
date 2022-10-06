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
        private int robot_clicks = 0;
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

            Misc.manageAssistantfromFile(this, chatbot_panel, "first_shop");
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

            if (btn_counter > 0)
                button2.Enabled = true;
            else
                button2.Enabled = false;
            
            if(((CheckBox)sender).Checked == true)
                Eshopbought.Add(Controls["pictureBox"+ chkbox.ToString()].Tag.ToString());
            else
                Eshopbought.Remove(Controls["pictureBox" + chkbox.ToString()].Tag.ToString());

            label8.Text = "Σύνολο: " + total + "€";
            button2.Text = "Επιβεβαίωση προϊόντων στο καλάθι(" + btn_counter + ")";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Misc.openForm("EshopConfirm", Eshopcategory, Eshopcolor, Eshopsoldout, Eshopbought, total);
            Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            switch (robot_clicks)
            {
                case 0:
                    label10.Text =   "Μπορείς να επιλέξεις να κάνεις προσθήκη στο\n" +
                                    "καλάθι ένα ζευγάρι, κάνοντας κλικ στο\n" +
                                    "αντίστοιχο checkbox του ζευγαριού. Πρόσεξε\n" +
                                    "όμως να μην ξεπεράσεις το όριο των διαθέσιμων\n" +
                                    "θέσεων στην παπουτσοθήκη, το οποίο αναγράφεται\n" +
                                    "κάτω αριστερά.";
                    robot_clicks += 1;
                    break;

                case 1:
                    label10.Text =   "Κάτω δεξιά θα διακρίνεις το σύνολικό ποσό\n" +
                                    "που ενδέχεται να χρεωθείς. Όταν τελειώσεις με\n" +
                                    "τις επιλογές σου, πάτα\n" +
                                    "'Επιβεβαίωση προϊόντων στο καλάθι'.";
                    robot_clicks += 1;
                    break;

                case 2:
                    label10.Text =   "Στη συνέχεια θα μεταβείς στην επιβεβαίωση της\n" +
                                    "αγοράς σου. Εκεί θα έχεις την δυνατότητα να\n" +
                                    "επιλέξεις τον τρόπο πληρωμής και παραλαβής των\n" +
                                    "προϊόντων σου! ";
                    robot_clicks += 1;
                    break;

                case 3:
                    label10.Text =   "Μπορείς να επιλέξεις να πληρώσεις με μετρητά,\n" +
                                    "ή κάρτα. Αν επιλέξεις να πληρώσεις με κάρτα,\n" +
                                    "σιγουρέψου ότι έχεις συμπληρώσει όλα τα\n" +
                                    "στοιχεία σωστά και ολοκληρώμένα!";
                    robot_clicks += 1;
                    break;

                case 4:
                    label10.Text =   "Οι τρόποι παραλαβής, είναι στο κατάστημα ή σε\n" +
                                    "μία διεύθυνση της επιλογής σου. Αν επιλέξεις\n" +
                                    "μία διεύθυνση πέρα του καταστήματος, σιγουρέψου\n" +
                                    "ότι την έχεις συμπληρώσει σωστά!";
                    robot_clicks += 1;
                    break;

                case 5:
                    label10.Text =   "Αφού επιλέξεις/συμπληρώσεις όλα τα προηγούμενα,\n" +
                                    "πάτα το κουμπί\n" +
                                    "'Αγορά προϊόντων/καταχώρηση παραγγελιας'.\n" +
                                    "Αν όλα είναι σωστά, το ποσό θα χρεωθεί στον\n" +
                                    "λογαριασμό σου αν επέλεξες να πληρώσεις με\n" +
                                    "κάρτα ηλεκτρονικά ή η παραγγελία σου θα\n" +
                                    "καταχωρηθεί αν επέλεξες να πληρώσεις με\n" +
                                    "μετρητά";
                    robot_clicks += 1;
                    break;

                case 6:
                    label10.Text = "Μόλις παραλάβεις τα παπούτσια, εγώ θα ενημερώσω\n" +
                                  "αυτόματα την παπουτσοθήκη!";
                    robot_clicks += 1;
                    break;

                default:
                    //hide robot and enable the other controls
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = true;
                        else if (c.Parent == chatbot_panel || c == chatbot_panel)
                            c.Enabled = c.Visible = false;
                    }

                    //change the file variable for this assistant
                    Misc.changeAssistantStateInFile("first_shop");

                    break;
            }
        }

        private void Eshop_FormClosing(object sender, FormClosingEventArgs e)
        {
            Misc.openForm("Shoes");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Misc.changeAssistantStateInFile("first_shop", true);
            Misc.manageAssistantfromFile(this, chatbot_panel, "first_shop");
            robot_clicks = 0;
            chatbot_panel.Show();
        }
    }
}