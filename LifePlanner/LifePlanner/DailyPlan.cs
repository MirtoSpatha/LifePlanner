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
        AddEventPanel new_event_panel = new AddEventPanel();
        ModifyEventPanel old_event_panel = new ModifyEventPanel();
        public static bool submit_clicked = false;
        public static bool deleted = false;
        public static HashSet<string> restricted_hours = new HashSet<string>();
        List<Label> labels = new List<Label>();
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
                display_event(new_event_panel.event_info);
            submit_clicked = false;
        }

        private void panel4_VisibleChanged(object sender, EventArgs e)
        {
            if (panel4.Visible == false)
                display_event(old_event_panel.event_info);
            submit_clicked = false;
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
                old_event_panel = new ModifyEventPanel(new_event_panel.event_info);
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

        public static HashSet<string> find_restricted_hours()
        {
            
            //foreach (List<object> l in day_schedule)
            {
                //int index = day_schedule.IndexOf(l);
                //MessageBox.Show(l[0].ToString());
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

        private void display_event(Dictionary<string,string> event_info)
        {
            // recently created or modified event
            if (submit_clicked == true)
            {
                TimeSpan t1 = TimeSpan.Parse(new_event_panel.event_info["StartTime"]);
                TimeSpan t2 = TimeSpan.Parse(new_event_panel.event_info["EndTime"]);
                TimeSpan t = t2.Subtract(t1);
                int d = (int)t.TotalHours;
                int start_hour = (int)t1.TotalHours;
                int count1 = 0;
                int count2 = 0;
                for (int i = 0; i < d; i++)
                {
                    string panelname = "panelt" + (start_hour + i);
                    Label l1 = new Label();
                    labels.Add(l1);
                    //Label l1 = new Label();
                    if (l1.Created)
                        count1++;
                    labels[i].Text = new_event_panel.event_info["Title"];
                    labels[i].Font = new Font("Bookman Old Style", (float)10.2, FontStyle.Bold);
                    Panel parent = this.tableLayoutPanel1.Controls.Find(panelname, false).FirstOrDefault() as Panel;
                    panel_events.Add(parent, event_info);
                    l1.Parent = parent;
                    labels[i].Parent.Visible = true;
                    labels[i].Parent.BringToFront();
                    labels[i].Location = labels[i].Parent.Location;
                    labels[i].Visible = true;
                    labels[i].BringToFront();


                    // panel coloring
                    switch(event_info["Activity"])
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
                        
                    
                    
                    
                    //MessageBox.Show(count1.ToString() + " new " + labels[i].Text);
                    /*
                    Label l2 = new Label();
                    if (l2.Created)
                        count2++;
                    l2.Text = new_event_panel.event_info["Address"];
                    l2.Font = new Font("Bookman Old Style", 10, FontStyle.Regular);
                    l2.Parent = l1.Parent;
                    l2.Parent.Visible = true;
                    l2.Parent.BringToFront();
                    l2.Location = new Point(l1.Location.X, l1.Location.Y + l1.Height);
                    l2.Visible = true;
                    l2.BringToFront();
                    MessageBox.Show(count2.ToString() + " new " + l2.Text);
                    */
                    /*
                    Label l1 = new Label();
                    if (l1.Created)
                        count1++;
                    l1.Text = new_event_panel.event_info["Title"];
                    l1.Font = new Font ("Bookman Old Style", (float)10.2, FontStyle.Bold);
                    l1.Parent = this.tableLayoutPanel1.Controls.Find(panelname, false).FirstOrDefault() as Panel;
                    l1.Parent.Visible = true;
                    l1.Parent.BringToFront();
                    l1.Location = l1.Parent.Location;
                    l1.Visible = true;
                    l1.BringToFront();
                    MessageBox.Show(count1.ToString() + " new " + l1.Text);
                    Label l2 = new Label();
                    if (l2.Created)
                        count2++;
                    l2.Text = new_event_panel.event_info["Address"];
                    l2.Font = new Font("Bookman Old Style", 10, FontStyle.Regular);
                    l2.Parent = l1.Parent;
                    l2.Parent.Visible = true;
                    l2.Parent.BringToFront();
                    l2.Location = new Point (l1.Location.X, l1.Location.Y + l1.Height);
                    l2.Visible = true;
                    l2.BringToFront();
                    MessageBox.Show(count2.ToString() + " new " + l2.Text);
                    */
                    //TimeSpan p = TimeSpan.FromHours(i);
                    //p = t1.Add(p);
                    //restricted_hours.Add(p.ToString(@"hh\:mm"));
                }
                //MessageBox.Show("ok");
            }
            // recently deleted event
            else if (deleted == true)
            {
                
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
    }
}
