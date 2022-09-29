using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class Feeder : Form
    {
        private int robot_clicks = 0;
        private bool first_visit;

        //some  variables for feeder
        private static int food_percentage = 70;
        private static int water_percentage = 70;
        private static int old_food_percentage = 0;
        private static int old_water_percentage = 0;

        private static void soundThread(String type)
        {
            Console.WriteLine("Thread running");
            if (!type.Equals("None"))
            {
                new SoundPlayer("./sounds/" + type + ".wav").Play();

                if(type.Equals("kick"))
                    Thread.Sleep(2000);
                else
                    Thread.Sleep(4000);
            }

            if (Program.pet == "Γάτα")
                new SoundPlayer("./sounds/cat.wav").Play();
            else if (Program.pet == "Σκύλος")
                new SoundPlayer("./sounds/dog.wav").Play();
        }

        private static Bitmap getImagefromPercentage(String type, String percentage)
        {
            int percentage_int = Convert.ToInt32(percentage.Replace("%", ""));
            if (percentage_int == 0)
            {
                return Resource1.empty_bowl;
            }
            else if (percentage_int > 0 && percentage_int <= 40)
            {
                return (type.Equals("Food")) ? Resource1.little_bowl : Resource1.little_water_bowl;
            }
            else if (percentage_int > 40 && percentage_int <= 80)
            {
                return (type.Equals("Food")) ? Resource1.middle_bowl : Resource1.middle_water;
            }
            else
            {
                return (type.Equals("Food")) ? Resource1.full_bowl : Resource1.full_water_bowl;
            }

        }

        public Feeder()
        {
            InitializeComponent();
        }

        private void Feeder_Load(object sender, EventArgs e)
        {
            first_visit = Misc.manageAssistantfromFile(this, chatbot_panel, "first_feeder");
            //skip to the 7th robot event if we already visited feeder before
            if (!first_visit)
                robot_clicks = 8;
        }       

        private void label1_Click(object sender, EventArgs e)
        {
            switch (robot_clicks)
            {
                case 0:
                    label1.Text = "Για να ενεργοποιήσεις την\nαυτόματη ταΐστρα, πάτα" +
                                  "\n'Ενεργοποίηση αυτόματης ταΐστρας'.";
                    robot_clicks += 1;
                    break;

                case 1:
                    chatbot_panel.Hide();
                    set_feeder.Enabled = true;
                    label1.Text = "Ας ξεκινήσουμε!";
                    robot_clicks += 1;
                    break;

                case 2: 
                    label1.Text =   "Για να γεμίσεις το μπολ του φαγητού\n" +
                                    "πάτα 'Γέμισμα φαγητού'.Για να\n" +
                                    "γεμίσεις το μπολ του νερού\n" +
                                    "πάτα 'Γέμισμα νερού'.\nΜπορεις να" +
                                    "επιλέξεις εσύ την\nποσότητα που θέλεις να\n" +
                                    "προσθέσεις!";
                    robot_clicks += 1;
                    break;

                case 3:
                    label1.Text =   "Έχεις την επιλογή να ορίσεις εσύ σε\n" +
                                    "πόση ώρα και πόσα λεπτά θες να\nγεμίσεις τα " +
                                    "μπολ του νερού\nκαι του φαγητού " +
                                    "ορίζοντας τις\nαντίστοιχες τιμές " +
                                    "στα πεδία\nτου πίνακα!";
                    robot_clicks += 1;
                    break;

                case 4:
                    label1.Text =   "Μόλις τελειώσεις, πάτα\n'Oρισμός αυτόματης " +
                                    "ταΐστρας' και η\nαντίστροφη μέτρηση για το\n" +
                                    "γέμισμα των μπολ θα ξεκινήσει.\nΕγώ θα σε " +
                                    "ιδοποιήσω\nόταν γεμίσουν!";
                    robot_clicks += 1;
                    break;

                case 5:
                    label1.Text = "Εάν θέλεις να ακυρώσεις το\n" +
                                  "αυτόματο τάισμα, πάτα 'Ακύρωση'.\nΣε οποιαδήποτε άλλη περίπτωση που κάτι\n" +
                                  "παέι στραβά, εγώ θα σε ιδοποιήσω!";
                    robot_clicks += 1;
                    break;

                case 6:
                    label1.Text = "Για να απενεργοποιήσεις την αυτόματη\n" +
                                  "ταΐστρα, πάτα \n'Απενεργοποίηση αυτόματης ταΐστρας'";
                    robot_clicks += 1;
                    break;


                default:
                    //hide robot and enable the other controls
                    chatbot_panel.Hide();
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = true;
                    }

                    if(robot_clicks == 7)
                    {
                        //change the file variable for this assistant
                        Misc.changeAssistantStateInFile("first_feeder");
                        first_visit = false;

                        //start pet timer for pet events
                        pet_timer.Enabled = true;
                    }

                    robot_clicks += 1;

                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pet_timer.Enabled = true;

            if (food_percentage_lbl.Text.Equals("100%"))
            {
                MessageBox.Show("Το φαγητό είναι ήδη γεμάτο!", "Προϊδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            food_percentage += (int)numericUpDown5.Value;

            if (food_percentage > 100)
                food_percentage = 100;

            food_percentage_lbl.Text = food_percentage.ToString() + "%";

            new Thread(() => soundThread("food")).Start();

            food.Image = getImagefromPercentage("Food", food_percentage_lbl.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pet_timer.Enabled = true;

            if (water_percentage_lbl.Text.Equals("100%"))
            {
                MessageBox.Show("Το νερό είναι ήδη γεμάτο!", "Προϊδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            water_percentage += (int)numericUpDown6.Value;

            if (water_percentage > 100)
                water_percentage = 100;

            water_percentage_lbl.Text = water_percentage.ToString() + "%";

            new Thread(() => soundThread("water")).Start();

            water.Image = getImagefromPercentage("Water", water_percentage_lbl.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!timer_btn.Text.Equals("Ακύρωση"))
            {
                int food_mins = Convert.ToInt32(numericUpDown1.Value); //displayed as hours
                int food_seconds = Convert.ToInt32(numericUpDown3.Value); //displayed as minutes

                int water_mins = Convert.ToInt32(numericUpDown2.Value); //displayed as hours
                int water_seconds = Convert.ToInt32(numericUpDown4.Value); //displayed as minutes

                if (food_mins != 0 || food_seconds != 0)
                {
                    food_timer.Text = ((food_mins.ToString().Length == 1) ? "0" + food_mins.ToString() : food_mins.ToString()) + ":" + ((food_seconds.ToString().Length == 1) ? "0" + food_seconds.ToString() : food_seconds.ToString());
                    label14.Visible = food_timer.Visible = true;

                    food_clock.Enabled = true;
                }

                if (water_mins != 0 || water_seconds != 0)
                {
                    water_timer.Text = ((water_mins.ToString().Length == 1) ? "0" + water_mins.ToString() : water_mins.ToString()) + ":" + ((water_seconds.ToString().Length == 1) ? "0" + water_seconds.ToString() : water_seconds.ToString());
                    label17.Visible = water_timer.Visible = true;

                    water_clock.Enabled = true;
                }

                if (food_mins == 0 && food_seconds == 0 && water_mins == 0 && water_seconds == 0)
                {
                    MessageBox.Show("Παρακαλώ ρυθμίστε σωστά τουλάχιστον ένα χρονόμετρο", "Προϊδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                timer_btn.Text = "Ακύρωση";

                foreach (Control c in panel1.Controls)
                {
                    if (!c.Name.Equals("timer_btn"))
                        c.Enabled = false;
                }
            }
            else
            {
                label14.Visible = food_timer.Visible = false;
                label17.Visible = water_timer.Visible = false;
                food_clock.Enabled = water_clock.Enabled = false;

                timer_btn.Text = "Ορισμός αυτόματης ταΐστρας";

                foreach (Control c in panel1.Controls)
                {
                    c.Enabled = true;
                }
            }
        }

        private void set_feeder_Click(object sender, EventArgs e)
        {
            set_feeder.FlatAppearance.MouseOverBackColor = set_feeder.Text.Equals("Απενεργοποίηση αυτόματης ταΐστρας") ? Color.FromArgb(128, 255, 128) : Color.FromArgb(255, 128, 128);
            set_feeder.Text = set_feeder.Text.Equals("Απενεργοποίηση αυτόματης ταΐστρας") ? "Eνεργοποίηση αυτόματης ταΐστρας" : "Απενεργοποίηση αυτόματης ταΐστρας";

            //if its first visit we show assistant and disable the button
            if (first_visit)
            {
                chatbot_panel.Show();
                set_feeder.Enabled = false;
                return;
            }

            //Otherwise we have to enable/disable the feeder controls
            foreach (Control c in Controls)
            {
                if (c.Parent != chatbot_panel && c != chatbot_panel && !c.Name.Equals("set_feeder"))
                    c.Enabled = set_feeder.Text.Equals("Απενεργοποίηση αυτόματης ταΐστρας");
            }

            //enable/disable pet timer for pet events
            pet_timer.Enabled = set_feeder.Text.Equals("Απενεργοποίηση αυτόματης ταΐστρας");
        }

        private void food_clock_Tick(object sender, EventArgs e)
        {
            int mins = Convert.ToInt32(food_timer.Text.Split(':')[0]);
            int secs = Convert.ToInt32(food_timer.Text.Split(':')[1]);

            String message;

            if (secs == 0 && mins == 0)
            {
                this.Show();

                pet_timer.Enabled = true;
                food_clock.Enabled = false;

                int old_percentage = food_percentage;
                food_percentage += (int)numericUpDown5.Value;

                if (food_percentage > 100)
                    food_percentage = 100;

                food_percentage_lbl.Text = food_percentage.ToString() + "%";

                food.Image = getImagefromPercentage("Food", food_percentage_lbl.Text);

                message = "Το φαγητό του κατοικίδιού\nσου γέμισε! Το φαγητό ανέβηκε\nαπό " + old_percentage + "% σε " + food_percentage + "%.";

                food_timer.Visible = label14.Visible = false;              

                if (food_clock.Enabled == false && water_clock.Enabled == false)
                {
                    timer_btn.Text = "Ορισμός αυτόματης ταΐστρας";
                    foreach (Control c in panel1.Controls)
                    {
                        c.Enabled = true;
                    }
                }

                new Thread(() => soundThread("food")).Start();

                //in case while informing user for something,
                //something else occurs
                if (chatbot_panel.Visible == true)
                {
                    new Messagebox("Ο έξυπνος βοηθός λέει:\n" + message, this).Show();
                    return;
                }

                label1.Text = message;

                //disable form controls except robot's to interact with robot
                foreach (Control c in Controls)
                {
                    if (c.Parent != chatbot_panel && c != chatbot_panel)
                        c.Enabled = false;
                }

                chatbot_panel.Show();

                return;
            }
            else if (secs == 0 && mins != 0)
            {
                secs = 59;
                mins -= 1;
            }
            else
            {
                secs -= 1;
            }

            food_timer.Text = ((mins.ToString().Length == 1) ? "0" + mins.ToString() : mins.ToString()) + ":" + ((secs.ToString().Length == 1) ? "0" + secs.ToString() : secs.ToString());

        }

        private void water_clock_Tick(object sender, EventArgs e)
        {
            int mins = Convert.ToInt32(water_timer.Text.Split(':')[0]);
            int secs = Convert.ToInt32(water_timer.Text.Split(':')[1]);

            String message;

            if (secs == 0 && mins == 0)
            {
                this.Show();

                pet_timer.Enabled = true;
                water_clock.Enabled = false;

                int old_percentage = water_percentage;
                water_percentage += (int)numericUpDown6.Value;

                if (water_percentage > 100)
                    water_percentage = 100;

                water_percentage_lbl.Text = water_percentage.ToString() + "%";

                water.Image = getImagefromPercentage("Water", water_percentage_lbl.Text);

                message = "Το νερό του κατοικίδιού\nσου γέμισε! Το νερό ανέβηκε\nαπό " + old_percentage + "% σε " + water_percentage + "%.";

                water_timer.Visible = label17.Visible = false;

                if (food_clock.Enabled == false && water_clock.Enabled == false)
                {
                    timer_btn.Text = "Ορισμός αυτόματης ταΐστρας";

                    foreach (Control c in panel1.Controls)
                    {
                        c.Enabled = true;
                    }
                }

                new Thread(() => soundThread("water")).Start();

                //in case while informing user for something,
                //something else occurs
                if (chatbot_panel.Visible == true)
                {
                    new Messagebox("Ο έξυπνος βοηθός λέει:\n" + message, this).Show();
                    return;
                }

                label1.Text = message;

                //disable form controls except robot's to interact with robot
                foreach (Control c in Controls)
                {
                    if (c.Parent != chatbot_panel && c != chatbot_panel)
                        c.Enabled = false;
                }

                chatbot_panel.Show();

                return;
            }
            else if (secs == 0 && mins != 0)
            {
                secs = 59;
                mins -= 1;
            }
            else
            {
                secs -= 1;
            }

            water_timer.Text = ((mins.ToString().Length == 1) ? "0" + mins.ToString() : mins.ToString()) + ":" + ((secs.ToString().Length == 1) ? "0" + secs.ToString() : secs.ToString());
        }

        private void pet_timer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int rand_int = r.Next(1, 11);
            StringBuilder message = new StringBuilder("");

            bool lock_food = food_percentage == 0;
            bool lock_water = water_percentage == 0;

            //40% propability at every tick to eat food
            //20% to drop by 10% and 20% to drop by 20%
            if (rand_int >= 1 && rand_int <= 4)
            {                    
                double result = (double)rand_int / 2;
                food_percentage -= (int)Math.Ceiling(result) * 10;
            }
            //40% propability at every tick to drink water
            //20% to drop by 10% and 20% to drop by 20%
            else if (rand_int >= 5 && rand_int <= 8)
            {
                double result = (double)rand_int / 6;
                water_percentage -= (int)Math.Ceiling(result) * 10;               
            }
            //20% propability at every tick for pet to kick something
            //10% to kick food and 10% to kick water
            //loss is 40%
            else if (rand_int == 9)
            {
                //cancel food kick if food = 0
                if (lock_food)
                    return;
                old_food_percentage = food_percentage;
                food_percentage -= 40;
            }
            else
            {
                //cancel water kick if water = 0
                if (lock_water)
                    return;
                old_water_percentage = water_percentage;
                water_percentage -= 40;
            }

            if (food_percentage < 0)
                food_percentage = 0;

            if (water_percentage < 0)
                water_percentage = 0;

            //if food percentage drops to 0(only during timeticking)
            if (food_percentage == 0 && !lock_food)
            {
                String type = "None";

                food_percentage_lbl.Text = food_percentage.ToString() + "%";

                message.Append("Το φαγητό του κατοικίδιού σου τελείωσε!\n");
                //if food has been kicked
                if(old_food_percentage != 0)
                {
                    message.Append("Το κατοικίδιο σου έριξε\nτο μπολάκι με το φαγητό του!\nΤο φαγητό έπεσε από " + old_food_percentage + "% σε " + food_percentage + "%.");
                    type = "kick";
                }

                old_food_percentage = 0;

                //show form with chatbot if no message is displaying
                //if there is already a message displaying, show message box
                this.Show();

                new Thread(() => soundThread(type)).Start();

                if (chatbot_panel.Visible)
                {
                    //MessageBox.Show("Ο έξυπνος βοηθός λέει:\n" + message, "Ector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Messagebox("Ο έξυπνος βοηθός λέει:\n" + message, this).Show();
                }
                else
                {
                    //disable form controls except robot's to interact with robot
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = false;
                    }
                    label1.Text = message.ToString();
                    chatbot_panel.Show();                  
                }
            }

            //if water percentage drops to 0(only during timeticking)
            if (water_percentage == 0 && !lock_water)
            {
                String type = "None";

                water_percentage_lbl.Text = water_percentage.ToString() + "%";

                message.Append("Το νερό του κατοικίδιού σου τελείωσε!\n");
                //if water had been kicked
                if (old_water_percentage != 0)
                {
                    message.Append("Το κατοικίδιο σου έριξε\nτο μπολάκι με το νερό του!\nΤο νερό έπεσε από " + old_water_percentage + "% σε " + water_percentage + "%.");
                    type = "kick";
                }

                old_water_percentage = 0;

                new Thread(() => soundThread(type)).Start();

                //show form with chatbot if no message is displaying
                //if there is already a message displaying, show message box
                this.Show();

                if (chatbot_panel.Visible)
                    new Messagebox("Ο έξυπνος βοηθός λέει:\n" + message, this).Show();
                //MessageBox.Show("Ο έξυπνος βοηθός λέει:\n" + message, "Ector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //disable form controls except robot's to interact with robot
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = false;
                    }
                    label1.Text = message.ToString();
                    chatbot_panel.Show();
                }
            }

            //if food/water had been kicked without finishing
            if (old_food_percentage != 0)
            {
                message.Append("Ο έξυπνος βοηθός λέει: Το κατοικίδιο σου\nέριξε το μπολάκι με το φαγητό του!\nΤο φαγητό έπεσε από " + old_food_percentage + "% σε " + food_percentage + "%.");
                this.Show();

                old_food_percentage = 0;

                new Thread(() => soundThread("kick")).Start();

                if (chatbot_panel.Visible)
                    new Messagebox(message.ToString(), this).Show();
                    //MessageBox.Show(message.ToString(), "Ector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //disable form controls except robot's to interact with robot
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = false;
                    }
                    label1.Text = message.ToString();
                    chatbot_panel.Show();
                }
            }

            if(old_water_percentage != 0)
            {
                message.Append("Ο έξυπνος βοηθός λέει: Το κατοικίδιο σου\nέριξε το μπολάκι με το νερό του!\nΤο νερό έπεσε από " + old_water_percentage + "% σε " + water_percentage + "%.");
                this.Show();

                old_water_percentage = 0;

                new Thread(() => soundThread("kick")).Start();

                if (chatbot_panel.Visible)
                    new Messagebox(message.ToString(), this).Show();
                    //MessageBox.Show(message.ToString(), "Ector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //disable form controls except robot's to interact with robot
                    foreach (Control c in Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = false;
                    }
                    label1.Text = message.ToString();
                    chatbot_panel.Show();
                }
            }

            food_percentage_lbl.Text = food_percentage.ToString() + "%";
            water_percentage_lbl.Text = water_percentage.ToString() + "%";

            food.Image = getImagefromPercentage("Food", food_percentage_lbl.Text);
            water.Image = getImagefromPercentage("Water", water_percentage_lbl.Text);

            //stop pet event timer if everything is done
            if (food_percentage == 0 && water_percentage == 0)
                pet_timer.Enabled = false;
        }

        private void Feeder_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        
    }
}
