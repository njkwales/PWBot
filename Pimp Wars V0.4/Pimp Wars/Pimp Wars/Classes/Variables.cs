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
        public ulong Thugs { get; set; }
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
        public ulong NoOfRolls { get; set; }
        public ulong Payout { get; set; }
        public int check { get; set; }
        public ulong CrackTurnsToRoll { get; set; }

        public int RollPosition { get; set; }

        List<string> Log = new List<string>();

        #region Tek9 Variables

        public ulong PriceOfPistols = 500;
        public ulong PriceOfAKs = 5000;
        public ulong GunsToBuy { get; set; }
        public ulong PistolsToBuy { get; set; }
        public ulong AKsToBuy { get; set; }
        public ulong TotalSpend { get; set; }
        public ulong PistolToAKRatio;
        public ulong ThugsToBuy { get; set; }
        public ulong MedsToBuy { get; set; }

        #endregion


        public void GunsToBuyCalc()
        {
            Subtract_Uint subtract = new Subtract_Uint();

            PistolToAKRatio = (PriceOfAKs / PriceOfPistols);
            GunsToBuy = subtract.Subtract(Thugs, Weapons);
            AKsToBuy = GunsToBuy;
            PistolsToBuy = 0;
            TotalSpend = GunsToBuy * PriceOfAKs;

            if(Money > GunsToBuy * PriceOfPistols)
            {
                while (TotalSpend > Money && AKsToBuy > 0)
                {
                    AKsToBuy--;
                    TotalSpend = AKsToBuy * PriceOfAKs;
                }

                while ((AKsToBuy + PistolsToBuy) < GunsToBuy && AKsToBuy > 0)
                {
                    AKsToBuy--;
                    PistolsToBuy = PistolsToBuy + Convert.ToUInt64(PistolToAKRatio);
                    TotalSpend = (AKsToBuy * PriceOfAKs) + (PistolsToBuy * PriceOfPistols);
                }
            }
            else if(Money < GunsToBuy * PriceOfPistols)
            {
                AKsToBuy = 0;
                PistolsToBuy = Money / PriceOfPistols;
            }



        }

        public void ThugsToBuyCalc()
        {
            Subtract_Uint Maths = new Subtract_Uint();
            ThugsToBuy = Maths.Subtract((Money / 1000), 1);
        }

        public void MedsToBuyCalc()
        {
            Subtract_Uint Maths = new Subtract_Uint();
            MedsToBuy = Maths.Subtract((Whores * 5), Medicine);
        }

        public void CalcRolls(ulong TotalTurns, ulong TurnsPerRoll)
        {
            NoOfRolls = TotalTurns / TurnsPerRoll;
        }

        public void CrackTurnsToRollCalc()
        {
            CrackTurnsToRoll = ((Whores / 15) * NoOfRolls) / (Thugs + (Thugs / 2) + (Thugs / 10));
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
