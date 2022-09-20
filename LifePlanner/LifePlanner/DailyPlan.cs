using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    public partial class DailyPlan : Form
    {
        AddEventPanel new_event_panel = null;
        List<object> containers = new List<object>();
        public static bool submit_clicked = false;
        public static List<List<object>> day_schedule = new List<List<object>>();
        public static HashSet<string> restricted_hours = new HashSet<string>();

        public DailyPlan()
        {
            InitializeComponent();
        }

        private void DailyPlan_Load(object sender, EventArgs e)
        {
            label2.Text = Program.Date.ToString();
            panel2.Hide();
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.Dock = DockStyle.Right;
            //tableLayoutPanel1.Height = 699;
            tableLayoutPanel1.VerticalScroll.Visible = true;
            tableLayoutPanel1.HorizontalScroll.Visible = false;
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.ResumeLayout();
            tableLayoutPanel1.PerformLayout();
            vScrollBar1.Parent = tableLayoutPanel1;
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                Color.Transparent, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid);
            
        }

        private void panelt5_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt5, "05:00");
        }

        private void panelt6_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt6, "06:00");
        }

        private void panelt7_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt7, "07:00");
        }

        private void panelt8_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt8, "08:00");
        }

        private void panelt9_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt9, "09:00");
        }

        private void panelt10_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt10, "10:00");
        }

        private void panelt11_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt11, "11:00");
        }

        private void panelt12_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt12, "12:00");
        }

        private void panelt13_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt13, "13:00");
        }

        private void panelt14_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt14, "14:00");
        }

        private void panelt15_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt15, "15:00");
        }

        private void panelt16_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt16, "16:00");
        }

        private void panelt17_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt17, "17:00");
        }

        private void panelt18_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt18, "18:00");
        }

        private void panelt19_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt19, "19:00");
        }


        private void panelt20_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt20, "20:00");
        }


        private void panelt21_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt21, "21:00");
        }


        private void panelt22_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt22, "22:00");
        }


        private void panelt23_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt23, "23:00");
        }

        private void panelt0_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt0, "00:00");
        }


        private void panelt1_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt1, "01:00");
        }


        private void panelt2_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt2, "02:00");
        }


        private void panelt3_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt3, "03:00");
        }


        private void panelt4_MouseClick(object sender, MouseEventArgs e)
        {
            event_handler(panelt4, "04:00");
        }


        private void panel2_VisibleChanged(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            // check if event exists in these time slots
            if (submit_clicked == true)
            {
                TimeSpan t1 = TimeSpan.Parse(new_event_panel.event_info["StartTime"]);
                TimeSpan t2 = TimeSpan.Parse(new_event_panel.event_info["EndTime"]);
                TimeSpan t = t2.Subtract(t1);
                int d = (int)t.TotalHours;
                int start_hour = (int)t1.TotalHours;
                for (int i = 0; i < d; i++)
                {
                    string panelname = "panelt" + (start_hour + i);
                    Label l1 = new Label();
                    l1.Text = new_event_panel.event_info["Title"];
                    l1.Font = new Font ("Bookman Old Style", (float)10.2, FontStyle.Bold);
                    l1.Parent = this.tableLayoutPanel1.Controls.Find(panelname, false).FirstOrDefault() as Panel;
                    l1.Location = l1.Parent.Location;
                    Label l2 = new Label();
                    l2.Text = new_event_panel.event_info["Address"];
                    l2.Font = new Font("Bookman Old Style", 10, FontStyle.Regular);
                    l2.Parent = l1.Parent;
                    l2.Location = new Point (l1.Location.X, l1.Location.Y + l1.Height);
                    //TimeSpan p = TimeSpan.FromHours(i);
                    //p = t1.Add(p);
                    //restricted_hours.Add(p.ToString(@"hh\:mm"));
                }
                //containers.Add(new_event_panel.event_info);
                /*
                foreach (CheckBox c in panel1.Controls)
                {
                    if (c.Text == new_event_panel.event_info["Activity"])
                    {
                        containers.Add(c.Text);
                        // change color
                    }
                }*/
                //day_schedule.Add(containers);
                MessageBox.Show("ok");
            }
            //event_panel.event_info.Clear();
            containers.Clear();
            if (day_schedule.Count == 24)
            MessageBox.Show("There are more than 24 events");
        }

        private void event_handler(Control c, string StartTime)
        {
            //add event
            if (!c.HasChildren)
            {
                new_event_panel = new AddEventPanel(StartTime);
                panel2.Size = new_event_panel.Size;
                panel2.Anchor = AnchorStyles.None;
                new_event_panel.Parent = panel2;
                //containers.Add(panelt5);
                //containers.Add(panel2);
                panel2.Show();
            }
            //modify event
            else
            {
                //event_panel = new AddEventPanel(StartTime);
                //old_event_panel = 
                //panel4.Size = old_event_panel.Size;
                panel4.Anchor = AnchorStyles.None;
                //old_event_panel.Parent = panel2;
                panel4.Show();
            }
            
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            //e.Cancel = true;
            this.Hide();
        }

        public static HashSet<string> find_restricted_hours()
        {
            
            foreach (List<object> l in day_schedule)
            {
                int index = day_schedule.IndexOf(l);
                MessageBox.Show(l[0].ToString());
                //MessageBox.Show(l[1][1].ToString());
                restricted_hours.Add("s");
                /*
                Dictionary<string, string> information = (Dictionary<string, string>) day_schedule[index][1];
                restricted_hours.Add(information["StartTime"]);
                restricted_hours.Add(information["EndTime"]);
                TimeSpan t1 = TimeSpan.Parse(information["StartTime"]);
                TimeSpan t2 = TimeSpan.Parse(information["EndTime"]);
                TimeSpan t = t2.Subtract(t1);
                int d = (int) t.TotalHours;
                for(int i=1; i<d+1; i++)
                {
                    TimeSpan p = TimeSpan.FromHours(i);
                    p = t1.Add(p);
                    restricted_hours.Add(p.ToString(@"hh\:mm"));
                }*/
            }
            return restricted_hours;
        }
    }
}
