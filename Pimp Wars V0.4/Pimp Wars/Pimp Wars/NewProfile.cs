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
    public partial class NewProfile : Form
    {
        public NewProfile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.AppendAllText(@"Data\GameRegister.dat", textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "\r\n");
            MessageBox.Show("Profile Created");
            this.Close();
        }
    }
}
