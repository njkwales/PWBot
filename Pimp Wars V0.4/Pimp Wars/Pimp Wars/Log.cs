using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pimp_Wars
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }



        public void LogEntry(String Entry)
        {
            listBox1.Items.Add(Entry);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        public void Stats(List<ulong> stats)
        {
            string[] readText = File.ReadAllLines(@"Data\StatsNames.Dat");

            listBox2.Items.Clear();
            int i = 0;
            foreach (ulong K in stats)
            {
                listBox2.Items.Add(readText[i] + " : " + K.ToString());
                i++;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
