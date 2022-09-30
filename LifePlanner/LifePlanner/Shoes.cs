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

            //Activity: Καθημερινή, Επίσημη, Αθλητική, Εντός Σπιτιού

            /*event_info.Add("Title", Title);
            event_info.Add("StartTime", StartTime);
            event_info.Add("EndTime", EndTime);
            event_info.Add("Activity", selected_activity);
            event_info.Add("Address", selected_address);
            event_info.Add("Transportation", selected_transportation);
            event_info.Add("Beverage", selected_beverage);*/

            //Print dicts:

            /*foreach (var item in DailyPlan.panel_events)
            {
                Console.WriteLine(item.Key.Name);
                foreach (var item2 in item.Value)
                    Console.WriteLine(item2.Key + ": " + item2.Value);
                Console.WriteLine();
            }*/


            //foreach (var item in DailyPlan.panel_events.Where(x => x.Value["Activity"] == "Καθημερινή").ToList()) 
        }

        private void Shoes_Load(object sender, EventArgs e)
        {
 
        }

        private void Shoes_Shown(object sender, EventArgs e)
        {
            if (DailyPlan.panel_events.Count == 0)
            {
                label2.Visible = true;
                return;
            }

            var dict_list = DailyPlan.panel_events.SelectMany(x => x.Value).ToList();

            for (int i = 0; i < DailyPlan.panel_events.Count; i++)
            {
                if (i != 0 && dict_list[i].Equals(dict_list[i - 1]))
                    continue;

                if (i != 0)
                {
                    Console.WriteLine("Mphka");
                    tableLayoutPanel1.RowCount += 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel1.Size.Height + initial_height);
                }
                    

                /*for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                    tableLayoutPanel1.Controls.Add(new Label() { Text = "xxxxxxx@gmail.com" }, j, i);*/
            }

            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
