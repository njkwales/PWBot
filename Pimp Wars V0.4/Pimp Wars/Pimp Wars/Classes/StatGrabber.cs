using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pimp_Wars
{
    class StatGrabber
    {
        public string[] GetStatsSmall(String Source)
        {
            Source = Source.Replace("\r", "").Replace("\n", "").Replace("\r", "").Replace(",", "").Replace("$", "");
            string First = "money ";
            string Last = " BACK";
            var index1 = Source.IndexOf(First) + 6;
            var index2 = Source.IndexOf(Last);
            var length = index2 - index1;
            var Statvalue = Source.Substring(index1, length);
            string[] word = Statvalue.Split(' ');
            return word;
        }

        public List<ulong> GetStatsbig(String Source)
        {
            Source = ClearSource(Source);
 
            //Read all the search pairs from the data file into string array
            string[] readText = File.ReadAllLines(@"Data\StatSearchVars.Dat");
            //Create lists to hold search terms
            List<string> firstSearch = new List<string>();
            List<string> lastSearch = new List<string>();
            //loop through each element of the array
            foreach (string s in readText)
            {
                //Split the string element at each ','
                var a = s.Split(',');
                //Put each part into it respective list
                firstSearch.Add(a[0]);
                lastSearch.Add(a[1]);
            }

            //Create lists to hold search terms
            List<ulong> Stats = new List<ulong>();
            int i = 0;
            foreach (string firstTerm in firstSearch)
            {
                var index1 = Source.IndexOf(firstTerm);
                var index2 = Source.IndexOf(lastSearch[i]);
                i++;
                if (index1 != -1 & index2 != -1)
                {
                    var length = index2 - index1;
                    var Statvalue = Source.Substring(index1, length);
                    Statvalue = Statvalue.Replace(firstTerm, "").Replace(" ", "");
                    Stats.Add(Convert.ToUInt64(Statvalue));
                }
                else
                {
                    ulong zero = 0;
                    Stats.Add(zero);
                }
            }
            
            

            return Stats;
        }

        private string ClearSource(String Source)
        {
            //Remove all unwanted charactors from the text
            try
            {
                if (Source.Contains("turns in reserve"))
                {
                    var index1 = Source.IndexOf("You have ");
                    var index2 = Source.IndexOf("turns in reserve.") + 17;
                    var length = index2 - index1;
                    Source = Source.Remove(index1, length);

                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Source);
            }

            Source = Source.Replace("\r", "").Replace("\n", "").Replace("\r", "").Replace(",", "").Replace("$", "");

            //Remove all awards
            string[] readText = File.ReadAllLines(@"Data\AwardVars.Dat");
            foreach (string award in readText)
            {
                Source = Source.Replace(award, "");
            }

            return Source;
        }
    }
}
