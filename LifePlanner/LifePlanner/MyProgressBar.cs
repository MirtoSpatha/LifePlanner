using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner.Controls
{
    public partial class MyProgressBar : UserControl
    {
        public MyProgressBar()
        {
            InitializeComponent();
            this.Size = new Size(425, 25);
            this.BackColor = Color.DimGray;
            DoubleBuffered = true;
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {

        }

        int pb_value = 30, pb_max = 100, pb_min = 0;
        float per = 0f;
        Color barcolor = Color.FromArgb(161, 166, 203);
        public Color BarColor { get { return barcolor; } set { barcolor = value; Invalidate(); }}
        public int Min { get { return pb_min; } set { pb_min = value; Invalidate(); } }
        public int Max { get { return pb_max; } set { pb_max = value; Invalidate(); } }
        public int Value { get { return pb_value; } set { pb_value = value; Invalidate(); } }

        private void ProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Color clr = Color.FromArgb(10, barcolor);
            SolidBrush br = new SolidBrush(barcolor);
            Brush bb = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, barcolor, clr, 100);
            e.Graphics.FillRectangle(bb, ClientRectangle);

            per = (float)ClientSize.Width / pb_max;
            e.Graphics.FillRectangle(br, new RectangleF(0, 0, pb_value * per, ClientSize.Height));
            
            Pen pen = new Pen(Color.Black, 2);
            e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width, ClientSize.Height);
        }
    }
}
