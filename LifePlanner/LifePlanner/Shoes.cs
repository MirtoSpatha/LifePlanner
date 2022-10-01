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
        private static String activity_loss;
        List<Dictionary<string, string>> unique_events;
        String gender_letter = Program.gender.Equals("Θυληκό") ? "Γ" : "Α";

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
            //if there are no activities 
            if (DailyPlan.panel_events.Count == 0)
            {
                label2.Visible = true;
                return;
            }

            tableLayoutPanel1.Visible = true;

            initial_height = tableLayoutPanel1.Size.Height;

            unique_events = returnUniquedicsOf(DailyPlan.panel_events);

            Random r = new Random();
            int rand_int = r.Next(0, unique_events.Count);

            activity_loss = unique_events[rand_int]["Activity"];
            Console.WriteLine(activity_loss);


            drawForm();
        }

        private void drawForm()
        {
            for (int i = 0; i < unique_events.Count; i++)
            {
                //table has 2 rows at the begining so in first itteration we dont want to add rows
                if (i != 0)
                {
                    //add 2 rows
                    tableLayoutPanel1.RowCount += 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel1.Size.Height + initial_height);
                }

                //set labels for first imported row
                tableLayoutPanel1.Controls.Add(new Label() { Text = unique_events[i]["Title"], AutoSize = true }, 0, 2 * i);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Ώρα έναρξης: " + unique_events[i]["StartTime"] + "\nΏρα λήξης: " + unique_events[i]["EndTime"], AutoSize = true }, 1, 2 * i);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Κατηγορία: " + unique_events[i]["Activity"], AutoSize = true }, 2, 2 * i);


                //Activity: Καθημερινή, Επίσημη, Αθλητική, Εντός Σπιτιού

                //if the activity is the one that has to have no shoes, set pictureboxes to empty
                if (activity_loss.Equals(unique_events[i]["Activity"]))
                {
                    tableLayoutPanel1.Controls.Add(new PictureBox() {Image = null, BorderStyle = BorderStyle.FixedSingle}, 0, 2 * i + 1);
                    tableLayoutPanel1.Controls.Add(new PictureBox() {Image = null, BorderStyle = BorderStyle.FixedSingle }, 1, 2 * i + 1);
                    tableLayoutPanel1.Controls.Add(new PictureBox() {Image = null, BorderStyle = BorderStyle.FixedSingle }, 2, 2 * i + 1);
                }
                else
                {
                    //look for the resource images depending on activity and gender.
                    //set the first two shoe pictureboxes only

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

                    PictureBox shoe1 = new PictureBox(){ SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle };
                    PictureBox shoe2 = new PictureBox() { SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle };


                    //if we have gender shoes for this activity -> No exception
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
                        
                    

                    //if we dont have gender shoes for this activity -> exception
                    
                    

                    tableLayoutPanel1.Controls.Add(shoe1, 0, 2 * i + 1);
                    tableLayoutPanel1.Controls.Add(shoe2, 1, 2 * i + 1);
                    //third picturebox is empty
                    tableLayoutPanel1.Controls.Add(new PictureBox() { Image = null, BorderStyle = BorderStyle.FixedSingle }, 2, 2 * i + 1);
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



        private void Shoes_Shown(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
