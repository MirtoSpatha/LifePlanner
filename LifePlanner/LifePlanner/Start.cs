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
    public partial class Start : Form
    {

        public Start()
        {
            InitializeComponent();
            //this.Hide();
            //form.Show();
            //form.BringToFront();
            //this.SendToBack();
        }        

        private void Start_Load(object sender, EventArgs e)
        {
            /*
            Form form = new LoadingPage();
            this.Hide();
            form.Show();
            form.BringToFront();
            this.SendToBack();
            if (form.Enabled == false)
            {
                form.Close();
                this.Show();
            }
            */
        }

        private void chatbot_panel_MouseClick(object sender, MouseEventArgs e)
        {
            Form form = new UserData();
            form.Show();
            this.Hide();
        }
    }   
}
