using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Pimp_Wars
{
    class Variables
    {
        public Variables()
        {

        }

        public string Alias { get; set; }
        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void SaveStats()
        {
            List<String> Vars = new List<string>();
            Vars.Add(Username);
            Vars.Add(Password);


            if (File.Exists(@"Data\Data.dat"))
            {
                // WriteAllLines creates a file, writes a collection of strings to the file, 
                // and then closes the file.
                System.IO.File.WriteAllLines(@"Data\Data.dat", Vars);
            }
            else
            {
                String Currentdirector = System.Environment.CurrentDirectory.ToString();
                string PathString = System.IO.Path.Combine(Currentdirector, @"Data\");
                System.IO.Directory.CreateDirectory(PathString);
                PathString = System.IO.Path.Combine(Currentdirector, @"Data.dat");
                System.IO.FileStream fs = System.IO.File.Create(PathString);
                System.IO.File.WriteAllLines(@"Data\Data.dat", Vars);
                fs.Close();
            }
        
        }

        public void Load()
        {
            var logFile1 = File.ReadAllLines(@"Data\Data.Dat");
        }
    }
}
