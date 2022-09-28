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
<<<<<<<< HEAD:LifePlanner/LifePlanner/Exit.cs
    public partial class Exit : UserControl
    {
        public Exit()
========
    public partial class Bathroom : Form
    {
        public Bathroom()
>>>>>>>> nick:LifePlanner/LifePlanner/Bathroom.cs
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
