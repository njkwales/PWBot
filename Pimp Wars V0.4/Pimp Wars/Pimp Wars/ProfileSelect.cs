using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pimp_Wars
{
    public partial class ProfileSelect : Form
    {
        List<string> Alias = new List<string>();
        List<string> URL = new List<string>();
        List<string> Username = new List<string>();
        List<string> Password = new List<string>();

        public ProfileSelect()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProfile np = new NewProfile();
            np.Show();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            refresh();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = Alias[comboBox1.SelectedIndex];
            label2.Text = URL[comboBox1.SelectedIndex];
            label3.Text = Username[comboBox1.SelectedIndex];
            label4.Text = Password[comboBox1.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Main main = new Main(Alias[comboBox1.SelectedIndex], URL[comboBox1.SelectedIndex], Username[comboBox1.SelectedIndex], Password[comboBox1.SelectedIndex]);
                main.Show();
            }
            catch(Exception er)
            {
                MessageBox.Show("Opps did you select a profile ??");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void refresh()
        {
            var items = File.ReadAllLines(@"Data\GameRegister.dat");
            comboBox1.Items.Clear();
            foreach (string item in items)
            {
                string[] words = item.Split(',');
                comboBox1.Items.Add(words[0]);
                Alias.Add(words[0]);
                URL.Add(words[1]);
                Username.Add(words[2]);
                Password.Add(words[3]);
                
            }
        }

        public void Delete()
        {
            var items = File.ReadAllLines(@"Data\GameRegister.dat");
            List<string> list = new List<string>();
            list = items.ToList();
            list.RemoveAt(comboBox1.SelectedIndex);
            System.IO.File.Delete(@"Data\GameRegister.dat");
            System.IO.File.AppendAllLines(@"Data\GameRegister.dat", list);
            comboBox1.Items.Clear();
            refresh();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v0.2");
        }
    }
}
