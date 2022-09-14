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
    class Misc
    {
        /**
         * Function that shows/hides the menu at House functions.
         * returns a boolean value which indicates if the menu has
         * been closed(false) or opened(true)
         */

        public static bool ShowHide(Form form, Button menubutton, Panel menupanel, bool menu_open)
        {
            if (!menu_open)
            {
                foreach (Control c in form.Controls)
                {
                    if (c.Parent != menupanel && c != menubutton)
                        c.Enabled = false;
                }

                menubutton.Location = new Point(menupanel.Location.X + menupanel.Width, menupanel.Location.Y);
                menupanel.Visible = menupanel.Enabled = true;
                menubutton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128); //red
                return true;
            }
            else
            {
                foreach (Control c in form.Controls)
                {
                    if (c.Parent != menupanel && c != menubutton)
                        c.Enabled = true;
                }

                menubutton.Location = new Point(menupanel.Location.X, menupanel.Location.Y);
                menupanel.Visible = menupanel.Enabled = false;
                menubutton.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128); //green
                return false;
            }
        }
    }
}
