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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace LifePlanner
{
    public partial class DailyPlan : Form
    {
        AddEventPanel new_event_panel = new AddEventPanel();
        ModifyEventPanel old_event_panel = new ModifyEventPanel();
        public static bool submit_clicked = false;
        public static bool deleted = false;
        public static bool saved = false;
        public static HashSet<string> restricted_hours = new HashSet<string>();
        Dictionary<Panel,Dictionary<string,string>> panel_events = new Dictionary<Panel,Dictionary<string,string>>();

        public DailyPlan()
        {
            InitializeComponent();
        }

        private void DailyPlan_Load(object sender, EventArgs e)
        {
            label2.Text = Program.Date.ToString();
            panel2.Hide();
            panel4.Hide();
            tableLayoutPanel1.Dock = DockStyle.Right;
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
                update_planner(new_event_panel.event_info);
            submit_clicked = false;
        }

        private void panel4_VisibleChanged(object sender, EventArgs e)
        {
            if (panel4.Visible == false)
                update_planner(old_event_panel.event_info);
            saved = false;
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
                panel2.Visible = true;
                panel2.BringToFront();
                panel2.Show();
            }
            //modify event
            else
            {
                old_event_panel = new ModifyEventPanel(panel_events[(Panel) c], (Panel) c);
                panel4.Size = old_event_panel.Size;
                panel4.Anchor = AnchorStyles.None;
                old_event_panel.Parent = panel4;
                panel4.Visible = true;
                panel4.BringToFront();
                panel4.Show();
            }
            
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            //e.Cancel = true;
            this.Hide();
        }

        private void update_planner(Dictionary<string,string> event_info)
        {
            // recently created event
            if (submit_clicked == true)
            {
                display_event(event_info);
            }
            // recently modified event
            else if (saved == true)
            {
                // when the user modifies the hour of the event, the previous event has to be deleted
                Dictionary<string,string> old_event = panel_events[ModifyEventPanel.provoker];
                foreach (var item in panel_events.Where(kvp => kvp.Value == old_event).ToList())
                {
                    TimeSpan t1 = TimeSpan.Parse(old_event["StartTime"]);
                    TimeSpan t2 = TimeSpan.Parse(old_event["EndTime"]);
                    TimeSpan t = t2.Subtract(t1);
                    int d = (int)t.TotalHours;
                    int start_hour = (int)t1.TotalHours;
                    for (int i = 0; i < d; i++)
                    {
                        int k = start_hour + i;
                        if (k / 10 >= 1)
                        {
                            string k1 = k + ":00";
                            restricted_hours.Remove(k1);
                        }
                        else
                        {
                            string k1 = "0" + k + ":00";
                            restricted_hours.Remove(k1);
                        }
                    }
                    item.Key.BackColor = Color.LightCyan;
                    item.Key.Controls.Clear();
                    panel_events.Remove(item.Key);
                }
                display_event(event_info);
            }
            // recently deleted event
            else if (deleted == true)
            {
                foreach (var item in panel_events.Where(kvp => kvp.Value == event_info).ToList())
                {
                    TimeSpan t1 = TimeSpan.Parse(event_info["StartTime"]);
                    TimeSpan t2 = TimeSpan.Parse(event_info["EndTime"]);
                    TimeSpan t = t2.Subtract(t1);
                    int d = (int)t.TotalHours;
                    int start_hour = (int)t1.TotalHours;
                    for (int i = 0; i < d; i++)
                    {
                        int k = start_hour + i;
                        if (k / 10 >= 1)
                        {
                            string k1 = k + ":00";
                            restricted_hours.Remove(k1);
                        }
                        else
                        {
                            string k1 = "0" + k + ":00";
                            restricted_hours.Remove(k1);
                        }
                    }
                    item.Key.BackColor = Color.LightCyan;
                    item.Key.Controls.Clear();
                    panel_events.Remove(item.Key);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //238, 142, 180
            CheckBox currentCheckBox = (sender as CheckBox);
            if (currentCheckBox.Checked)
            {
                currentCheckBox.Image = Resource1.check_everyday;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Καθημερινή")
                        {
                            p.BackColor = Color.FromArgb(238, 142, 180);
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Show();
                            }
                        }
                        
                    }
                }
            }
            else
            {
                currentCheckBox.Image = Resource1._unchecked;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Καθημερινή")
                        {
                            p.BackColor = Color.LightCyan;
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Hide();
                            }
                        }
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //222, 125, 255
            CheckBox currentCheckBox = (sender as CheckBox);
            if (currentCheckBox.Checked)
            {
                currentCheckBox.Image = Resource1.check_sport;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Αθλητική")
                        {
                            p.BackColor = Color.FromArgb(222, 125, 255);
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Show();
                            }
                        }
                        
                    }
                }

            }
            else
            {
                currentCheckBox.Image = Resource1._unchecked;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Αθλητική")
                        {
                            p.BackColor = Color.LightCyan;
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Hide();
                            }
                        }
                    }
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //125, 142, 158
            CheckBox currentCheckBox = (sender as CheckBox);
            if (currentCheckBox.Checked)
            {
                currentCheckBox.Image = Resource1.check_formal;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Επίσημη")
                        {
                            p.BackColor = Color.FromArgb(125, 142, 158);
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Show();
                            }
                        }
                        
                    }
                }

            }
            else
            {
                currentCheckBox.Image = Resource1._unchecked;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Επίσημη")
                        {
                            p.BackColor = Color.LightCyan;
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Hide();
                            }
                        }    
                    }
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            //125, 152, 255
            CheckBox currentCheckBox = (sender as CheckBox);
            if (currentCheckBox.Checked)
            {
                currentCheckBox.Image = Resource1.check_house;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Εντός Σπιτιού")
                        {
                            p.BackColor = Color.FromArgb(125, 152, 255);
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Show();
                            }
                        }
                        
                    }
                }
            }
            else
            {
                currentCheckBox.Image = Resource1._unchecked;
                foreach (Panel p in tableLayoutPanel1.Controls.OfType<Panel>())
                {
                    if (panel_events.ContainsKey(p))
                    {
                        if (panel_events[p]["Activity"] == "Εντός Σπιτιού")
                        {
                            p.BackColor = Color.LightCyan;
                            foreach (Control c in p.Controls.OfType<Control>())
                            {
                                c.Hide();
                            }
                        }
                        
                    }
                }
            }
        }
    
        private void display_event(Dictionary<string, string> event_info)
        {
            TimeSpan t1 = TimeSpan.Parse(event_info["StartTime"]);
            TimeSpan t2 = TimeSpan.Parse(event_info["EndTime"]);
            TimeSpan t = t2.Subtract(t1);
            int d = (int)t.TotalHours;
            int start_hour = (int)t1.TotalHours;
            for (int i = 0; i < d; i++)
            {
                string panelname = "panelt" + (start_hour + i);
                Panel parent = this.tableLayoutPanel1.Controls.Find(panelname, false).FirstOrDefault() as Panel;
                panel_events.Add(parent, event_info);

                int k = start_hour + i;
                if (k/10 >= 1)
                {
                    string k1 = k + ":00";
                    restricted_hours.Add(k1);
                }
                else
                {
                    string k1 = "0" + k + ":00";
                    restricted_hours.Add(k1);
                }

                Label l1 = new Label();
                l1.Text = event_info["Title"];
                l1.Font = new Font("Bookman Old Style", (float)10.2, FontStyle.Bold);
                parent.Controls.Add(l1);
                l1.Parent = parent;
                l1.Dock = DockStyle.Left;
                l1.BringToFront();

                Label l2 = new Label();
                l2.Text = event_info["Address"];
                l2.Font = new Font("Bookman Old Style", (float)10.2, FontStyle.Regular);
                parent.Controls.Add(l2);
                l2.Parent = parent;
                l2.Location = new Point(l1.Location.X, l1.Location.Y + 18);
                l2.BringToFront();

                if (event_info["Activity"] != "Εντός Σπιτιού")
                {
                    Button b1 = new Button();
                    b1.Text = "Διαδρομή";
                    b1.Font = new Font("Bookman Old Style", (float)10.2, FontStyle.Bold);
                    parent.Controls.Add(b1);
                    b1.Parent = parent;
                    b1.MouseClick += b1_MouseClick;
                    b1.Location = new Point(l1.Location.X + 400, l1.Location.Y + 5);
                    b1.BackColor = Color.White;
                    b1.AutoSize = true;
                    b1.BringToFront();
                    b1.Tag = event_info;
                }  

                // panel coloring
                switch (event_info["Activity"])
                {
                    case "Καθημερινή":
                        parent.BackColor = Color.FromArgb(238, 142, 180);
                        break;
                    case "Αθλητική":
                        parent.BackColor = Color.FromArgb(222, 125, 255);
                        break;
                    case "Επίσημη":
                        parent.BackColor = Color.FromArgb(125, 142, 158);
                        break;
                    case "Εντός Σπιτιού":
                        parent.BackColor = Color.FromArgb(125, 152, 255);
                        break;
                }
            }
        }

        private void b1_MouseClick(object sender, MouseEventArgs e)
        {
            Button b1 = sender as Button;
            Dictionary<string,string> event_info = b1.Tag as Dictionary<string, string>;
            panel5.Visible = true;
            panel5.BringToFront();
            switch (event_info["Transportation"])
            {
                case "Αυτοκίνητο":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.car_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.car_map;
                    }
                    break;
                case "Λεωφορείο":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.bus_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.bus_map;
                    }
                    break;
                case "Μετρό":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_map;
                    }
                    break;
                case "Περπάτημα":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.walk_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.walk_map;
                    }
                    break;
                case "Λεωφορείο, Περπάτημα":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.bus_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.bus_map;
                    }
                    break;
                case "Λεωφορείο, Μετρό":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_bus_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_bus_map;
                    }
                    break;
                case "Λεωφορείο, Μετρό, Περπάτημα":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_bus_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_bus_map;
                    }
                    break;
                case "Μετρό, Περπάτημα":
                    if (event_info["Beverage"] != "Όχι")
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_coffee_map;
                    }
                    else
                    {
                        panel5.Show();
                        pictureBox2.Image = Resource1.metro_map;
                    }
                    break;
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {
            panel5.Hide();
        }
    }

}
