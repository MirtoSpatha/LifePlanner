using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    class Misc
    {
        public static bool menu_open = false;

        /**
         * Function that shows/hides the menu at House forms.
         * returns a boolean value which indicates if the menu has
         * been closed(false) or opened(true)
         */

        public static void ShowHide(Form form, Button menubutton, Panel menupanel)
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
                menu_open = true;
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
                menu_open = false;
            }
        }

        /**
         * Disable the menu button that corresponds to the current room
         */
        public static void manageButtons(Form form, Panel panel)
        {
            String formname = form.Name;
            
            foreach(Control c in panel.Controls)
            {
                if (c is Button && c.Name.Equals(formname + "btn"))
                {
                    c.Enabled = false;
                    return;
                }
            }
        }

        /**
         * Check if current form's assistant has been viewed before. If yes, Disable interaction
         */
        public static void manageAssistantfromFile(Form form, Panel chatbot_panel, String variable)
        {
            try
            {
                StreamReader sr = new StreamReader("OtherData.txt", true);
                String[] lines = sr.ReadToEnd().Split('\n');
                sr.Close();

                //hide robot interaction if its not the first time
                if (lines.Contains(variable + ": false") )
                {
                    chatbot_panel.Hide();
                }                   
                else
                {
                    //disable form controls except robot's to interact with robot
                    foreach (Control c in form.Controls)
                    {
                        if (c.Parent != chatbot_panel && c != chatbot_panel)
                            c.Enabled = false;
                    }
                }              
            }
            catch (Exception)
            {
                Console.WriteLine("An Exception was occured while trying to read the file");
            }
        }

        /**
         * Change the given file variable to false.
         * This is for disabling the assistant interaction next time
         */
        public static void changeAssistantStateInFile(String variable)
        {            
            try
            {
                //read all the lines and change only the desirable one.
                //Then rewrite all lines again
                StreamReader sr = new StreamReader("OtherData.txt", true);
                String[] lines = sr.ReadToEnd().Split('\n');
                sr.Close();

                String vrb;

                for(int i=0; i<lines.Length; i++)
                {
                    if (lines[i].StartsWith(variable + ": true"))
                        lines[i] = lines[i].Replace("true","false");
                }

                StreamWriter sw = new StreamWriter("OtherData.txt");
                foreach (String line in lines)
                    sw.Write(line);
                sw.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An Exception was occured while trying to read/write the file");
            }
        }
    }
}
