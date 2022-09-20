using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class Feeder : Form
    {
        private int robot_clicks = 0;
        private String message = "";
        private bool first_visit;

        //specifies the form that called the feeder
        private Form caller;

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

        public Feeder(Form caller)
        {
            InitializeComponent();
            this.caller = caller;
        }

        private void Feeder_Load(object sender, EventArgs e)
        {
            //get percentages from global variables and set them to labels
            food_percentage.Text = Misc.food_percentage.ToString() + "%";
            water_percentage.Text = Misc.water_percentage.ToString() + "%";

            //set the images depending on the label percentages
            food.Image = getImagefromPercentage("Food", food_percentage.Text);
            water.Image = getImagefromPercentage("Water", water_percentage.Text);

            Misc.manageAssistantfromFile(this, chatbot_panel, "first_feeder");

            //set message if something was over(food or water)
            if (Misc.food_percentage == 0 && Misc.water_percentage == 0)
                message = "Το φαγητό και το νερό του κατοικίδιού σου τελείωσε!";
            else if (Misc.food_percentage == 0)
                message = "Το φαγητό του κατοικίδιού σου τελείωσε!";
            else if (Misc.water_percentage == 0)
                message = "Το νερό του κατοικίδιού σου τελείωσε!";

            //show message on chatbot depending if its the first time of viewing feeder or not
            if (chatbot_panel.Visible == true && !message.Equals(""))
            {
                label1.Text = message;
                first_visit = true;
            }

            else if (chatbot_panel.Visible == false && !message.Equals(""))
            {
                //disable form controls except robot's to interact with robot
                foreach (Control c in Controls)
                {
                    if (c.Parent != chatbot_panel && c != chatbot_panel)
                        c.Enabled = false;
                }

                //show chatbot
                label1.Text = message;
                chatbot_panel.Show();

                first_visit = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //in case its the first time visiting feeder and pet needs food/water,
            //after the missing food/water message we show the first time dialog
            if (!message.Equals("") && first_visit)
            {
                label1.Text = "Καλοσήρθες στην αυτόματη ταΐστρα!\n" +
                "Εδώ μπορείς να ρυθμίσεις μία ώρα που\n" +
                "θες να ταΐσεις το κατοικίδιο σου\n" +
                "αυτόματα, να ελέγξεις τη ποσότητα του\n" +
                "φαγητού και του νερού του και να\n" +
                "προσθέσεις άμεσα λίγο νερό ή και\n" +
                "φαγητό!";

                message = "";

                return;
            }
            //in case its not the first time visiting feeder,
            //just hide assistant after missing food/water message
            else if (!message.Equals("") && !first_visit)
            {
                //hide robot and enable the other controls
                chatbot_panel.Hide();
                foreach (Control c in Controls)
                {
                    if (c.Parent != chatbot_panel && c != chatbot_panel)
                        c.Enabled = true;
                }

                return;
            }

            switch (robot_clicks)
            {
                case 0:
                    label1.Text = "Για να γεμίσεις το μπολ του φαγητού\n" +
                                    "πάτα 'Γέμισμα φαγητού'.Για να\n" +
                                    "γεμίσεις το μπολ του νερού\n" +
                                    "πάτα 'Γέμισμα νερού'.";
                    robot_clicks += 1;
                    break;

                case 1:
                    label1.Text = "Έχεις την επιλογή να ορίσεις εσύ σε\n" +
                                    "πόση ώρα και πόσα λεπτά θες να\nγεμίσεις τα " +
                                    "μπολ του νερού\nκαι του φαγητού " +
                                    "ορίζοντας τις\nαντίστοιχες τιμές " +
                                    "στα πεδία\nτου πίνακα!";
                    robot_clicks += 1;
                    break;

                case 2:
                    label1.Text = "Μόλις τελειώσεις, πάτα\n'Oρισμός αυτόματης " +
                                    "ταΐστρας' και η\nαντίστροφη μέτρηση για το\n" +
                                    "γέμισμα των μπολ θα ξεκινήσει.\nΕγώ θα σε " +
                                    "ιδοποιήσω\nόταν γεμίσουν!";
                    robot_clicks += 1;
                    break;

                case 3:
                    label1.Text = "Εάν θέλεις να ακυρώσεις το\n" +
                                    "αυτόματο τάισμα, πάτα\nξανά το κουμπί.Σε οποιαδήποτε\nάλλη περίπτωση που κάτι " +
                                    "παέι\nστραβά, εγώ θα σε ιδοποιήσω!";
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

                    //change the file variable for this assistant
                    Misc.changeAssistantStateInFile("first_feeder");

                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (food_percentage.Text.Equals("100%"))
            {
                MessageBox.Show("Το φαγητό είναι ήδη γεμάτο!", "Προϊδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            food_percentage.Text = "100%";
            Misc.food_percentage = 100;
            //some sound effects
            food.Image = Resource1.full_bowl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (water_percentage.Text.Equals("100%"))
            {
                MessageBox.Show("Το νερό είναι ήδη γεμάτο!", "Προϊδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            water_percentage.Text = "100%";
            Misc.water_percentage = 100;
            //some sound effects
            water.Image = Resource1.full_water_bowl;
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

                timer_btn.Text = "Ορισμός αυτόματης ταΐστρας";

                foreach (Control c in panel1.Controls)
                {
                    c.Enabled = true;
                }
            }
        }

        private void food_clock_Tick(object sender, EventArgs e)
        {
            int mins = Convert.ToInt32(food_timer.Text.Split(':')[0]);
            int secs = Convert.ToInt32(food_timer.Text.Split(':')[1]);

            if (secs == 0 && mins == 0)
            {
                this.Show();

                food_clock.Enabled = false;

                food_percentage.Text = "100%";
                Misc.food_percentage = 100;

                food.Image = Resource1.full_bowl;

                message = "Το φαγητό του κατοικίδιού\nσου γέμισε!";
                food_timer.Visible = label14.Visible = false;

                if (food_clock.Enabled == false && water_clock.Enabled == false)
                    timer_btn.Text = "Ορισμός αυτόματης ταΐστρας";

                //in case while informing user for something,
                //something else occurs
                if (chatbot_panel.Visible == true)
                {
                    MessageBox.Show("Ο έξυπνος βοηθός λέει: " + message, "Ector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                label1.Text = message;

                //disable form controls except robot's to interact with robot
                foreach (Control c in Controls)
                {
                    if (c.Parent != chatbot_panel && c != chatbot_panel)
                        c.Enabled = false;
                }

                //some sound effects

                chatbot_panel.Show();

                foreach (Control c in panel1.Controls)
                {
                    c.Enabled = true;
                }

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

            if (secs == 0 && mins == 0)
            {
                this.Show();

                water_clock.Enabled = false;

                water_percentage.Text = "100%";
                Misc.water_percentage = 100;

                water.Image = Resource1.full_water_bowl;

                message = "Το νερό του κατοικίδιού\nσου γέμισε!";
                water_timer.Visible = label17.Visible = false;

                if (food_clock.Enabled == false && water_clock.Enabled == false)
                    timer_btn.Text = "Ορισμός αυτόματης ταΐστρας";

                //in case while informing user for something,
                //something else occurs
                if (chatbot_panel.Visible == true)
                {
                    MessageBox.Show("Ο έξυπνος βοηθός λέει: " + message,"Ector",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                label1.Text = message;

                //disable form controls except robot's to interact with robot
                foreach (Control c in Controls)
                {
                    if (c.Parent != chatbot_panel && c != chatbot_panel)
                        c.Enabled = false;
                }

                //some sound effects

                chatbot_panel.Show();

                foreach (Control c in panel1.Controls)
                {
                    c.Enabled = true;
                }

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

        private void Feeder_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
