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

        public Shoes()
        {
            InitializeComponent();

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

            //foreach (var item in DailyPlan.panel_events.Where(x => x.Value["Activity"] == "Καθημερινή" ).ToList())
            foreach (var item in DailyPlan.panel_events.Values)
            {
                var timh = item["Activity"];
            }
        }
    }
}
