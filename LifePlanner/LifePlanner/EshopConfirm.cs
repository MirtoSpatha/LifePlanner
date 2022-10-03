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
    public partial class EshopConfirm : Form
    {
        private String Eshopcategory;
        private Color titlecolor;
        //this list contains the shoes we have so we are going to append Eshopbought here
        private List<String> Eshopsoldout;
        List<String> Eshopbought;

        private int total;

        public EshopConfirm(String Eshopcategory, int Eshopcolor, List<String> Eshopsoldout, List<String> Eshopbought, int total)
        {
            InitializeComponent();

            this.Eshopcategory = Eshopcategory;
            titlecolor = Color.FromArgb(Eshopcolor);
            this.Eshopsoldout = Eshopsoldout;
            this.Eshopbought = Eshopbought;
            this.total = total;
        }

        private void EshopConfirm_Load(object sender, EventArgs e)
        {

        }

        private void EshopConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Misc.openForm("Eshop", total : total);
        }
    }
}
