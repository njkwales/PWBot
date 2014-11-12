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
        public List<String> GetStatsAll(String Source)
        {
            List<string> Stats = new List<string>();
            try
            {
                Source = Source.Replace("\r", "").Replace("\n", "").Replace("\r", "");

                var logFile1 = File.ReadAllLines(@"Data\StatSearch1.Dat");
                var logFile2 = File.ReadAllLines(@"Data\StatSearch2.Dat");
                var i = 0;
                foreach (string elements in logFile1)
                {
                    var index1 = Source.IndexOf(elements) + 62;
                    var index2 = Source.IndexOf(logFile2[i], index1);
                    var length = index2 - index1;
                    var Statvalue = Source.Substring(index1, length);
                    Statvalue = Statvalue.Replace(",", "");
                    Stats.Add(Statvalue);
                    i++;
                }
                return Stats;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return Stats;
            }
        }

        public List<String> GetStatsSmall(String Source)
        {
            List<string> Stats = new List<string>();
            try
            {
                Source = Source.Replace("\r", "").Replace("\n", "").Replace("\r", "");

                var logFile1 = File.ReadAllLines(@"Data\StatSearch1.Dat");
                var logFile2 = File.ReadAllLines(@"Data\StatSearch2.Dat");
                var i = 0;
                foreach (string elements in logFile1)
                {
                    var index1 = Source.IndexOf(elements) + 62;
                    var index2 = Source.IndexOf(logFile2[i], index1);
                    var length = index2 - index1;
                    var Statvalue = Source.Substring(index1, length);
                    Statvalue = Statvalue.Replace(",", "");
                    Stats.Add(Statvalue);
                    i++;
                }
                return Stats;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return Stats;
            }
        }
    }
}
