using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    internal static class Program
    {
        public static string Date = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DailyPlan());
            /*
            StreamReader sr = new StreamReader("UserData.txt", true);
            string s = "0";
            try
            {
                s = sr.ReadLine();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
            if (s == null) 
            {
                Date = DateTime.Today.ToString("D");
                //Application.Run(new LoadingPage());
                Application.Run(new Start());
            }
            else if(s == "0")
            {
                MessageBox.Show("Mistake at reading file");
            }
            else 
            {
                //Wednesday, June 17, 2009
                Date = File.ReadLines("UserData.txt").Last();
                DateTime myDate = DateTime.ParseExact(Date, "D", null);
                myDate = myDate.AddDays(1);
                Date = myDate.ToString("D");
                
                string path = "UserData.txt";
                var fileContent = File.ReadLines(path).ToList();
                fileContent[fileContent.Count - 1] = Date;
                File.WriteAllLines(path, fileContent);
                
                //Application.Run(new LoadingPage());
                Application.Run(new Options());
            
            }
        */
            
                /*
                 A
Αρσενικό
34
fgrdc
cvb
Αυτοκίνητο
0
dcvf
Σκύλος
Sunday, September 4, 2022
                 */
        }
    }
}
