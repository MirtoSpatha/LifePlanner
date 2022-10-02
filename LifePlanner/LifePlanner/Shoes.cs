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
    public partial class Shoes : Form
    {
        private ResourceManager rm = new ResourceManager("LifePlanner.Resource1", Assembly.GetExecutingAssembly());
        private static int initial_height;
        private static int initial_width;
        private static String activity_loss = null;
        List<Dictionary<string, string>> unique_events;
        String gender_letter = Program.gender.Equals("Θυληκό") ? "Γ" : "Α";

        private int robot_clicks = 0;

        public Shoes()
        {
            InitializeComponent();
            
            //10-12
            //{panelt10 : {Title : x , StartTime : 10, EndTime : 11, ...} , panelt11 : {Title : y , StartTime : 11, EndTime : 12, ...} }



            /*event_info.Add("Title", Title);
            event_info.Add("StartTime", StartTime);
            event_info.Add("EndTime", EndTime);
            event_info.Add("Activity", selected_activity);
            event_info.Add("Address", selected_address);
            event_info.Add("Transportation", selected_transportation);
            event_info.Add("Beverage", selected_beverage);*/

            //Print dicts:

            //1// for daily plan dic
            /*foreach (var item in DailyPlan.panel_events)
            {
                Console.WriteLine(item.Key.Name);
                foreach (var item2 in item.Value)
                    Console.WriteLine(item2.Key + ": " + item2.Value);
                Console.WriteLine();
            }*/

            //2// for list of dics
            /*foreach (var dict in dic_list)
            {
                foreach (var item in dict)
                    Console.WriteLine(item.Key + ": " + item.Value);
                Console.WriteLine();
            }*/


            //foreach (var item in DailyPlan.panel_events.Where(x => x.Value["Activity"] == "Καθημερινή").ToList()) 
        }
        private void Shoes_Load(object sender, EventArgs e)
        {
            label2.SendToBack();
            button2.SendToBack();
            label2.Location = new Point(this.Width/2 - label2.Width/2, this.Height / 2 - label2.Height / 2);

            initial_height = tableLayoutPanel1.Size.Height;
            initial_width = tableLayoutPanel1.Size.Width;

            drawForm();

            Misc.manageAssistantfromFile(this, chatbot_panel, "first_shoes");
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if(((PictureBox)sender).Tag.ToString().Equals("purchase"))
            {
                DialogResult result =  MessageBox.Show("Αυτή η θέση είναι κενή! Θες να μεταβείς στο ηλεκτρονικό κατάστημα παπουτσιών για να " +
                                    "αγοράσεις ένα νέο ζευγάρι παπούτσια;","Ector", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(result == DialogResult.Yes)
                    return; //go to shop
                else
                    return;
            }

            int pbrow = tableLayoutPanel1.GetRow((PictureBox)sender);
            //int pbcolumn = tableLayoutPanel1.GetColumn((PictureBox)sender);

            tableLayoutPanel1.GetControlFromPosition(0, pbrow).BackColor = Color.Transparent;
            tableLayoutPanel1.GetControlFromPosition(1, pbrow).BackColor = Color.Transparent;
            tableLayoutPanel1.GetControlFromPosition(2, pbrow).BackColor = Color.Transparent;

            ((PictureBox)sender).BackColor = Color.FromArgb(128, 255, 128); // green
        }

        public void drawForm()
        {
            //if there are no activities 
            if (DailyPlan.panel_events.Count == 0)
            {
                tableLayoutPanel1.Visible = false;
                label2.Visible = true;
                button1.Visible = false;
                button2.Location = new Point(this.Width / 2 - button2.Width / 2, this.Height / 2 - button2.Height / 2 + 50); ;
                return;
            }

            if (tableLayoutPanel1.HasChildren)
            {
                Console.WriteLine("katharisma");
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowStyles.Clear();
                tableLayoutPanel1.Size = new Size(initial_width, initial_height);
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.RowCount = 2;
            }

            tableLayoutPanel1.Visible = true;
            label2.Visible = false;
            button1.Visible = true;
            button2.Location = new Point(431, 12);

            unique_events = returnUniquedicsOf(DailyPlan.panel_events);

            if(activity_loss == null)
            {
                Random r = new Random();
                int rand_int = r.Next(0, unique_events.Count);
                activity_loss = unique_events[rand_int]["Activity"];
            }           

            for (int i = 0; i < unique_events.Count; i++)
            {
                //table has 2 rows at the begining so in first itteration we dont want to add rows
                if (i != 0)
                {
                    //add 2 rows
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.RowCount += 2;
                    tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel1.Size.Height + initial_height);
                }

                //set labels for first imported row
                tableLayoutPanel1.Controls.Add(new Label() 
                { Text = "Τίτλος: " + unique_events[i]["Title"], 
                  AutoSize = true, 
                  TextAlign = ContentAlignment.MiddleCenter, 
                  Anchor = AnchorStyles.None, 
                  Dock = DockStyle.Fill, 
                  BackColor = Color.FromArgb( Convert.ToInt32(unique_events[i]["Color"].Substring(0,3)), Convert.ToInt32(unique_events[i]["Color"].Substring(3, 3)), Convert.ToInt32(unique_events[i]["Color"].Substring(6, 3)) ),
                  Font = new Font("Bookman Old Style", 12, FontStyle.Bold) }, 
                  0, 2 * i);

                tableLayoutPanel1.Controls.Add(new Label()
                { Text = "Ώρα έναρξης: " + unique_events[i]["StartTime"] + "\nΏρα λήξης: " + unique_events[i]["EndTime"],
                  AutoSize = true, 
                  TextAlign = ContentAlignment.MiddleCenter, 
                  Anchor = AnchorStyles.None, 
                  Dock = DockStyle.Fill, 
                  BackColor = Color.FromArgb(Convert.ToInt32(unique_events[i]["Color"].Substring(0, 3)), Convert.ToInt32(unique_events[i]["Color"].Substring(3, 3)), Convert.ToInt32(unique_events[i]["Color"].Substring(6, 3)) ),
                  Font = new Font("Bookman Old Style", 12, FontStyle.Bold) },
                  1, 2 * i);

                tableLayoutPanel1.Controls.Add(new Label() 
                { Text = "Κατηγορία: " + unique_events[i]["Activity"], 
                  AutoSize = true, 
                  TextAlign = ContentAlignment.MiddleCenter, 
                  Anchor = AnchorStyles.None, 
                  Dock = DockStyle.Fill, 
                  BackColor = Color.FromArgb(Convert.ToInt32(unique_events[i]["Color"].Substring(0, 3)), Convert.ToInt32(unique_events[i]["Color"].Substring(3, 3)), Convert.ToInt32(unique_events[i]["Color"].Substring(6, 3)) ), 
                  Font = new Font("Bookman Old Style", 12, FontStyle.Bold) },
                  2, 2 * i);

                PictureBox shoe1 = new PictureBox() { SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle, Cursor = Cursors.Hand, Dock = DockStyle.Fill};
                PictureBox shoe2 = new PictureBox() { SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle, Cursor = Cursors.Hand, Dock = DockStyle.Fill};
                PictureBox shoe3 = new PictureBox() { SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle, Cursor = Cursors.Hand, Dock = DockStyle.Fill};
                shoe1.Click += new EventHandler(pictureBox_Click);
                shoe2.Click += new EventHandler(pictureBox_Click);
                shoe3.Click += new EventHandler(pictureBox_Click);

                //Activity: Καθημερινή, Επίσημη, Αθλητική, Εντός Σπιτιού

                //if the activity is the one that has to have no shoes, set pictureboxes to purchase icons
                if (activity_loss.Equals(unique_events[i]["Activity"]))
                {
                    shoe1.Image = shoe2.Image = shoe3.Image = Resource1.purchase;
                    shoe1.Tag = shoe2.Tag = shoe3.Tag = "purchase";
                    shoe1.BackColor = shoe2.BackColor = shoe3.BackColor = Color.Empty;

                    tableLayoutPanel1.Controls.Add(shoe1, 0, 2 * i + 1);
                    tableLayoutPanel1.Controls.Add(shoe2, 1, 2 * i + 1);
                    tableLayoutPanel1.Controls.Add(shoe3, 2, 2 * i + 1);
                }
                else
                {
                    /*string resxFile = @"..\..\Resource1.resx";
                    ResXResourceReader resxReader = new ResXResourceReader(resxFile);
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        //first picturebox
                        if ( ((string)entry.Key).Equals(unique_events[i]["Activity"]+gender_letter +"1") || 
                            ((string)entry.Key).Equals(unique_events[i]["Activity"] + "1") )
                        {
                            tableLayoutPanel1.Controls.Add(new PictureBox() { Image = (Bitmap)entry.Value, SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle }, 0, 2 * i + 1);
                        }
                        //second picturebox
                        else if ( ((string)entry.Key).Equals(unique_events[i]["Activity"] + gender_letter + "2") ||
                            ((string)entry.Key).Equals(unique_events[i]["Activity"] + "2") )
                        {
                            tableLayoutPanel1.Controls.Add(new PictureBox() { Image = (Bitmap)entry.Value, SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle }, 1, 2 * i + 1);
                        }

                    }*/
                    
                    //look for the resource images depending on activity and gender.
                    //set the first two shoe pictureboxes only

                    if (unique_events[i]["Activity"].Equals("Αθλητική"))
                    {
                        shoe1.Image = (Bitmap)rm.GetObject("Αθλητική1");
                        shoe2.Image = (Bitmap)rm.GetObject("Αθλητική2");
                    }
                    else if(unique_events[i]["Activity"].Equals("Εντός Σπιτιού"))
                    {
                        shoe1.Image = (Bitmap)rm.GetObject("Εντός_Σπιτιού1");
                        shoe2.Image = (Bitmap)rm.GetObject("Εντός_Σπιτιού2");
                    }
                    else
                    {
                        shoe1.Image = (Bitmap)rm.GetObject(unique_events[i]["Activity"] + gender_letter + "1");
                        shoe2.Image = (Bitmap)rm.GetObject(unique_events[i]["Activity"] + gender_letter + "2");
                    }
                    shoe1.BackColor = shoe2.BackColor = shoe3.BackColor = Color.Transparent;
                    shoe1.Tag = shoe2.Tag = "";
                    tableLayoutPanel1.Controls.Add(shoe1, 0, 2 * i + 1);
                    tableLayoutPanel1.Controls.Add(shoe2, 1, 2 * i + 1);

                    //third picturebox is empty
                    shoe3.Image = Resource1.purchase;
                    shoe3.Tag = "purchase";
                    tableLayoutPanel1.Controls.Add(shoe3, 2, 2 * i + 1);
                }
            }
        }

        private List<Dictionary<string, string>> returnUniquedicsOf(Dictionary<Panel, Dictionary<string, string>> dic)
        {
            List<Dictionary<string, string>> dic_list = new List<Dictionary<string, string>>();

            foreach (Dictionary<string, string> d in dic.Values)
            {
                if(!dic_list.Contains(d))
                    dic_list.Add(d);
            }

            return dic_list;

        }

        private void checkExit()
        {
            if (DailyPlan.panel_events.Count == 0)
            {
                this.Hide();
                return;
            }

            bool msg1 = false;
            bool msg2 = false;

            for(int i = 1; i<tableLayoutPanel1.RowCount; i += 2)
            {
                if( ((PictureBox)tableLayoutPanel1.GetControlFromPosition(0,i)).Tag.ToString().Equals("purchase")
                 && ((PictureBox)tableLayoutPanel1.GetControlFromPosition(1, i)).Tag.ToString().Equals("purchase")
                 && ((PictureBox)tableLayoutPanel1.GetControlFromPosition(2, i)).Tag.ToString().Equals("purchase")
                 && !msg1)
                {
                    MessageBox.Show("Καποιά/ες από τις δραστηριότητές σου δεν έχει/ουν κανένα διαθέσιμο ζευγάρι παπούτσια. Επέλεξε μία κενή θέση για να μεταβείς στο ηλεκτρονικό κατάστημα παπουτσιών!","Ector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msg1 = true;
                }

                if (((PictureBox)tableLayoutPanel1.GetControlFromPosition(0, i)).BackColor == Color.Transparent
                 && ((PictureBox)tableLayoutPanel1.GetControlFromPosition(1, i)).BackColor == Color.Transparent
                 && ((PictureBox)tableLayoutPanel1.GetControlFromPosition(2, i)).BackColor == Color.Transparent
                 && !msg2)
                {
                    MessageBox.Show("Επέλεξε παπούτσια για όλες τις δραστηριότητες του πλάνου σου!", "Ector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msg2 = true;
                }

                //Skip uneccessary iterations
                if (msg1 && msg2)
                    return;
            }

            if (!msg1 && !msg2)
            {                
                this.Hide();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //run checkExit function. In any case form is hiding
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Misc.openForm("DailyPlan");
        }

        private void Shoes_MouseEnter(object sender, EventArgs e)
        {
            if (DailyPlan.modified)
            {
                Misc.redrawShoes();
                MessageBox.Show("Η παπουτσοθήκη ενημερώθηκε!");
                DailyPlan.modified = false;
                BringToFront();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            switch (robot_clicks)
            {
                case 0:
                    label1.Text =   "Εάν δεν έχεις προσθέσει ακόμα δραστηριότητες\n" +
                                    "στο πλάνο σου, πάτα το κουμπί 'Έξυπνο πλάνο'.\n"+
                                    "Εάν έχεις προσθέσει, αυτή τη στιγμή βλέπεις\n" +
                                    "μπροστά σου τον πίνακα με τις δραστηριότητες\n" +
                                    "και τα προτεινόμενα παπούτσια.";
                    robot_clicks += 1;
                    break;

                case 1:
                    label1.Text =   "Για κάθε δραστηριότητα εγώ σου προτείνω τα\n" +
                                    "παπούτσια που είναι κατάλληλα για την\n" +
                                    "κατηγορία της. Μπορείς να διακρίνεις τον\n" +
                                    "τίτλο, το χρονικό διάστημα και την κατηγορία\n" +
                                    "της δραστηριότητας στη μία γραμμή και στην\n" +
                                    "άλλη τις επιλογές σου.";
                    robot_clicks += 1;
                    break;

                case 2:
                    label1.Text =   "Κάνοντας κλικ ένα ζευγάρι για μία\n" +
                                    "δραστηριότητα, αυτό γίνεται πράσινο, το όποίο\n" +
                                    "σημαίνει ότι έχεις επιβεβαιώσει την επιλογή\n" +
                                    "σου. Μπορείς να την αλλάξεις, πολυ απλα\n" +
                                    "κάνοντας κλικ σε ένα άλλο ζευγάρι!\n";
                    robot_clicks += 1;
                    break;

                case 3:
                    label1.Text =   "Κάνοντας κλικ σε μία κενή θέση που έχει το\n" +
                                    "εικονίδιο της αγοράς, έχεις την δυνατότητα\n" +
                                    "να μεταβείς στο ηλεκτρονικό κατάστημα που\n" +
                                    "θα σου προτείνω εγώ, για να αγοράσεις ένα\n" +
                                    "νέο ζευγάρι της αντίστοιχης κατηγορίας!";
                    robot_clicks += 1;
                    break;

                case 4:
                    label1.Text =   "Μην ξεχάσεις να επιλέξεις/αγοράσεις παπούτσια\n" +
                                    "για όλες σου τις δραστηριότητες! Ακόμα και αν\n" +
                                    "το κάνεις, εγώ θα σε ιδοποιήσω!";
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
                    //Misc.changeAssistantStateInFile("first_shoes");

                    break;
            }
        }

        private void Shoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            checkExit();
        }
    }
}
