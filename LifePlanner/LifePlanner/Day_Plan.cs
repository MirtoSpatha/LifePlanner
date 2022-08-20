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
    public partial class Day_Plan : Form
    {
        int month, year;
        public Day_Plan()
        {
            InitializeComponent();
        }

        private void previous_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void next_pictureBox_Click(object sender, EventArgs e)
        {
            month++;
            DateTime now = DateTime.Now;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            for (int i = 1; i <= dayoftheweek; i++)
            {
                Blank b = new Blank();
                flowLayoutPanel1.Controls.Add(b);
            }

            for (int i = 1; i <= days; i++)
            {
                Day d = new Day();
                d.days(i);
                flowLayoutPanel1.Controls.Add(d);
            }
        }

        private void Day_Plan_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            for(int i=1; i<=dayoftheweek;i++)
            {
                Blank b = new Blank();
                flowLayoutPanel1.Controls.Add(b);
            }

            for(int i = 1; i <= days; i++) 
            {
                Day d = new Day();
                d.days(i);
                flowLayoutPanel1.Controls.Add(d);
            }
        } 
    }
}
