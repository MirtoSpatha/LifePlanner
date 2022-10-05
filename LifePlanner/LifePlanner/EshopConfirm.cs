using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class EshopConfirm : Form
    {
        private ResourceManager rm = new ResourceManager("LifePlanner.Resource1", Assembly.GetExecutingAssembly());
        private String Eshopcategory;
        private int Eshopcolor;
        //this list contains the shoes we have so we are going to append Eshopbought here
        private List<String> Eshopsoldout;
        List<String> Eshopbought;

        private int total;
        private int validation_counter = 0;
        private bool end = false;

        private int initial_height;
        private int initial_width;

        public EshopConfirm(String Eshopcategory, int Eshopcolor, List<String> Eshopsoldout, List<String> Eshopbought, int total)
        {
            InitializeComponent();

            this.Eshopcategory = Eshopcategory;
            this.Eshopcolor = Eshopcolor;
            this.Eshopsoldout = Eshopsoldout;
            this.Eshopbought = Eshopbought;
            this.total = total;
        }

        private void EshopConfirm_Load(object sender, EventArgs e)
        {
            initial_height = this.Height;
            initial_width = this.Width;

            label1.BackColor = Color.FromArgb(Eshopcolor);

            String[] price_list = rm.GetString(Eshopcategory + "τιμές").Split(',');

            foreach (String name in Eshopbought)
            {
                PictureBox p = new PictureBox()
                {
                    Size = new Size(163, 150),
                    Image = (Bitmap)rm.GetObject(name),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label l = new Label()
                {
                    Size = new Size(50, 60),
                    Text = "Τιμή: " + price_list[Convert.ToInt32(name.Last().ToString()) - 1] + "€",
                    Padding = new Padding(0, 10, 0, 30),
                    Font = new Font("Bookman Old Style", 12, FontStyle.Bold),
                    AutoSize = true
                };

                flowLayoutPanel1.Controls.Add(p);
                flowLayoutPanel1.Controls.Add(l);
            }

            label5.Text += total.ToString() + "€";

        }

        private void EshopConfirm_Resize(object sender, EventArgs e)
        {
            //for size

            int diff_height = this.Height - initial_height;
            int diff_width = this.Width - initial_width;

            flowLayoutPanel1.Height += diff_height;
            flowLayoutPanel2.Height += diff_height;

            flowLayoutPanel1.Width += diff_width/2;
            button1.Width += diff_width/2;
            button2.Width += diff_width/2;

            foreach (Control cg in flowLayoutPanel1.Controls)
            {
                cg.Height += diff_height / 3;
                cg.Width += diff_width / 3;
            }

            initial_height = this.Height;
            initial_width = this.Width;

            //for location

            button1.Location = new Point(button1.Location.X, button1.Location.Y + diff_height);
            flowLayoutPanel2.Location = new Point(flowLayoutPanel2.Location.X + diff_width, flowLayoutPanel2.Location.Y);
            button2.Location = new Point(button2.Location.X + diff_width, button2.Location.Y + diff_height);
            label5.Location = new Point(button2.Location.X + button2.Width + 20, button2.Location.Y + button2.Height / 2 - label5.Height /2);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            bool msg1 = false, msg2 = false, msg3 = false; 

            //if any of the card details are not complete and we chose to pay by card
            if (groupBox3.Visible && groupBox3.Controls.OfType<MaskedTextBox>().Any(txt => !txt.MaskFull))
            {
                MessageBox.Show("Παρακαλώ εισήγαγε όλα τα στοιχεία της κάρτας σου ολοκληρωμένα!", "Προϊδοποίηση!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msg1 = true;
            }

            if (!msg1 && groupBox3.Visible)
            {
                //if month is invalid
                int month = Convert.ToInt32(maskedTextBox3.Text.Substring(0, 2));

                if (month == 0 || month > 12)
                {
                    MessageBox.Show("Παρακαλώ εισήγαγε την σωστή ημερομηνία λήξης της κάρτας σου!", "Προϊδοποίηση!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msg2 = true;
                }
            }          

            //if we choose a custom address and its invalid
            if (groupBox4.Visible && radioButton6.Checked && !new Regex(@"^([a-zA-ZΑ-Ωα-ωίϊΐόάέύϋΰήώ]*[ ]\d{1,3})+$").IsMatch(textBox1.Text))
            {
                MessageBox.Show("Διάλεξε ή συμπλήρωσε μια διεύθυνση της ακόλουθης μορφής: \"Οδός Αριθμός\".", "Προϊδοποίηση!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msg3 = true;
            }

            if (msg1 || msg2 || msg3)
                return;

            //card validation
            if (radioButton5.Checked)
            {
                foreach(Control c in Controls)
                    c.Hide();

                label9.Location = new Point(this.Width / 2 - label9.Width /2, this.Height / 2 - label9.Height / 2);
                label9.Show();
                card_timer.Enabled = true;
                total = Convert.ToInt32(label5.Text.Split(' ')[1].Substring(0, 2)); //total amount fee
                return;
            }

            end = true;
            Eshopsoldout.AddRange(Eshopbought);
            Misc.redrawShoes();
            MessageBox.Show("Η παραγγελία σας καταχωρήθηκε! Ευχαριστούμε πολύ που μας προτιμήσατε!", "Το κατάστημα", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            MessageBox.Show("Μετά την παραλαβή των παπουτσιών...", "Σημείωση"); 
        }

        //for address
        private void radioButton7_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Text.Equals("Άλλο (προσδιόρισε):"))
                textBox1.Visible = true;
            else
                textBox1.Visible = false;
        }

        //for payment
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Text.Equals("Κάρτα(ηλεκτρονικά)"))
                groupBox3.Visible = true;
            else
                groupBox3.Visible = false;
        }

        //for send
        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Text.Equals("Αποστολή σε διεύθυνση"))
            {
                groupBox4.Visible = true;
                label2.Visible = true;
                label5.Text = "Σύνολο: "+(total+2).ToString() + "€";
            }
                
            else
            {
                groupBox4.Visible = false;
                label2.Visible = false;
                if(!label5.Text.Equals(total.ToString() + "€"))
                    label5.Text = "Σύνολο: "+total.ToString() + "€";
            }
                
        }

        private void card_timer_Tick(object sender, EventArgs e)
        {
            if(validation_counter == 12)
            {
                card_timer.Enabled = false;
                Eshopsoldout.AddRange(Eshopbought);
                Misc.redrawShoes();
                MessageBox.Show("Το ποσό των " + total + "€ έχει χρεωθεί στον λογαριασμό σας! Ευχαριστούμε πολύ που μας προτιμήσατε!", "Το κατάστημα", MessageBoxButtons.OK, MessageBoxIcon.Information);
                end = true;
                Close();
                MessageBox.Show("Μετά την παραλαβή των παπουτσιών...", "Σημείωση");
                return;
            }


            if (label9.Text.EndsWith("..."))
                label9.Text = "Παρακαλώ περιμένετε, γίνεται επαλήθευση των στοιχείων σας";
            else
                label9.Text += ".";

            validation_counter += 1;
        }

        private void EshopConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!end)
                Misc.openForm("Eshop", total: total);
            else
                Misc.openForm("Shoes");
        }
    }
}
