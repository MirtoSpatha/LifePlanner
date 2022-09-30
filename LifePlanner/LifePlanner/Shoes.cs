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
    public partial class Shoes : Form
    {
        private static int initial_height;

        public Shoes()
        {
            InitializeComponent();
            initial_height = tableLayoutPanel1.Size.Height;
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

        private void drawForm()
        {
            if (DailyPlan.panel_events.Count == 0)
            {
                label2.Visible = true;
                return;
            }

            List<Dictionary<string, string>> unique_events = returnUniquedicsOf(DailyPlan.panel_events);

            for (int i = 0; i < unique_events.Count; i++)
            {
                if (i != 0)
                {
                    tableLayoutPanel1.RowCount += 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel1.Size.Height + initial_height);
                }

                tableLayoutPanel1.Controls.Add(new Label() { Text = unique_events[i]["Title"], AutoSize = true }, 0, 2 * i);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Ώρα έναρξης: " + unique_events[i]["StartTime"] + "\nΏρα λήξης: " + unique_events[i]["EndTime"], AutoSize = true }, 1, 2 * i);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Κατηγορία: " + unique_events[i]["Activity"], AutoSize = true }, 2, 2 * i);

                String gender = Program.gender;

                Random r = new Random();
                int rand_int = r.Next(0, unique_events.Count);
                String activity_loss = unique_events[rand_int]["Activity"];



                //Activity: Καθημερινή, Επίσημη, Αθλητική, Εντός Σπιτιού

                tableLayoutPanel1.Controls.Add(new PictureBox() { }, 0, 2 * i + 1);
                tableLayoutPanel1.Controls.Add(new PictureBox() { }, 1, 2 * i + 1);
                tableLayoutPanel1.Controls.Add(new PictureBox() { }, 2, 2 * i + 1);

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

        private void Shoes_Load(object sender, EventArgs e)
        {
           
        }

        private void Shoes_Shown(object sender, EventArgs e)
        {
            drawForm();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
