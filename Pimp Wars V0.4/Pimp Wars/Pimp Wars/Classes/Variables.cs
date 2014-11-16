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

        public ulong Worth { get; set; }
        public ulong Money { get; set; }
        public ulong Turns { get; set; }
        public ulong Reserve { get; set; }
        public ulong Whores { get; set; }
        //public ulong Thugs { get; set; }
        public ulong Condoms { get; set; }
        public ulong Weapons { get; set; }
        public ulong Crack { get; set; }
        public ulong Beer { get; set; }
        public ulong Medicine { get; set; }
        public ulong Lowriders { get; set; }
        public ulong Pistols { get; set; }
        public ulong Shotguns { get; set; }
        public ulong MP5s { get; set; }
        public ulong AK47s { get; set; }
        public ulong turnstouse { get; set; }
        public ulong Payout { get; set; }
        public ulong MoneySpent { get; set; }
        public int check { get; set; }

        public int RollPosition { get; set; }

        public ulong Thugs 
        { 
            get;

            set
            {

            }

        }


        public void SaveStats()
        {
            String stats = Alias + "," +
                            URL + "," +
                            Username + "," +
                            Password + "," +
                            Worth + "," +
                            Money + "," +
                            Turns + "," +
                            Reserve + "," +
                            Whores + "," +
                            Thugs + "," +
                            Condoms + "," +
                            Weapons + "," +
                            Crack + "," +
                            Beer + "," +
                            Medicine + "," +
                            Lowriders + "," +
                            Pistols + "," +
                            Shotguns + "," +
                            MP5s + "," +
                            AK47s;

            String Header = "Alias,URL,Username,Password,Worth,Money,Turns,Reserve,Whores,Thugs,Condoms,Weapons,Crack,Beer,Medicine,Low-riders,Pistols,Shotguns,MP5s,AK-47s";

            if (!File.Exists(@"Data\" + Alias + ".dat"))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(@"Data\" + Alias + ".dat"))
                {
                    sw.WriteLine(DateTime.Now + "," + Header);
                }
            }
            else if (File.Exists(@"Data\" + Alias + ".dat"))
            {
                var lastLine = File.ReadLines(@"Data\" + Alias + ".dat").Last();
                int i = lastLine.IndexOf(",") + 1;
                lastLine = lastLine.Substring(i, lastLine.Length - i);

                if ( lastLine != stats )
                {
                    using (StreamWriter sw = File.AppendText(@"Data\" + Alias + ".dat"))
                    {
                        sw.WriteLine(DateTime.Now + "," + stats);
                    }
                }
            }
        
        }


    }
}
