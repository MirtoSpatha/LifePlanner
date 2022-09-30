using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlanner
{
    internal static class Program
    {
        public static bool NewUser = false;
        public static List<string> items = new List<string> { "Αυτοκίνητο", "Λεωφορείο", "Μετρό", "Περπάτημα" };
        
        // retrieve user data from file
        public static string username = null;
        public static string gender = null;
        public static string age = null;
        public static string address = null;
        public static string work_address = null;
        public static string transportation = null;
        public static string shoe_size = null;
        public static string beverage = null;
        public static string pet = null;
        public static string Date = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                username = File.ReadLines("UserData.txt").Skip(0).Take(1).First();

                if (username != null)
                {
                    //Otherwise username exists as well as the other data

                    gender = File.ReadLines("UserData.txt").Skip(1).Take(1).First();
                    age = File.ReadLines("UserData.txt").Skip(2).Take(1).First();
                    address = File.ReadLines("UserData.txt").Skip(3).Take(1).First();
                    work_address = File.ReadLines("UserData.txt").Skip(4).Take(1).First();
                    transportation = File.ReadLines("UserData.txt").Skip(5).Take(1).First();
                    shoe_size = File.ReadLines("UserData.txt").Skip(6).Take(1).First();
                    beverage = File.ReadLines("UserData.txt").Skip(7).Take(1).First();
                    pet = File.ReadLines("UserData.txt").Skip(8).Take(1).First();
                    Date = File.ReadLines("UserData.txt").Last();
                    DateTime myDate = DateTime.ParseExact(Date, "D", null);
                    myDate = myDate.AddDays(1);
                    Date = myDate.ToString("D");

                    string path = "UserData.txt";
                    var fileContent = File.ReadLines(path).ToList();
                    fileContent[fileContent.Count - 1] = Date;
                    File.WriteAllLines(path, fileContent);

                    NewUser = false;
                    Application.Run(new LoadingPage());
                }   
                
            }
            //if file is empty
            catch (InvalidOperationException)
            {
                Date = DateTime.Today.ToString("D");
                Console.WriteLine("Empty File");
                NewUser = true;
                Application.Run(new LoadingPage());
            }
            //if file does not exist
            catch (FileNotFoundException)
            {
                Date = DateTime.Today.ToString("D");
                Console.WriteLine("File not found");
                NewUser = true;
                Application.Run(new LoadingPage());
            }

        }
    }
}
