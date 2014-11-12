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
    public partial class Main : Form
    {
        Variables variables = new Variables();
        GamePlay GP = new GamePlay();

        public Main(String Alias, String URL, String Username, String Password)
        {
            InitializeComponent();
            variables.Alias = Alias;
            variables.URL = URL;
            variables.Username = Username;
            variables.Password = Password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GP.Scout("1", webBrowser3.Document);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser3.Refresh();
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void Main_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;
            webBrowser3.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(variables.URL);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser1.Url.ToString();
            if (URL == variables.URL + "?reason=idle" || URL == variables.URL)
            {
                HtmlDocument doc = webBrowser1.Document;
                Login login = new Login();
                login.GetLoginIDs(doc, variables.Username, variables.Password);
            }
            else if (URL == variables.URL + "go/")
            {
                webBrowser2.Navigate(variables.URL + "go/");
                webBrowser3.Navigate(variables.URL + "go/action.pimp?menu=scout");
                webBrowser4.Navigate(variables.URL + "go/action.pimp?menu=mkcrack");
                webBrowser5.Navigate(variables.URL + "go/buy.pimp?menu=corner");
                webBrowser6.Navigate(variables.URL + "go/buy.pimp?menu=tommy");
                webBrowser7.Navigate(variables.URL + "go/buy.pimp?menu=deals");
            }
        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser3.Url.ToString();

            if (URL != variables.URL + "go/whorescout.pimp")
            {

            }
            else if (URL != variables.URL + "go/action.pimp?menu=scout")
            {
                webBrowser3.Navigate(variables.URL + "go/action.pimp?menu=scout");
            }
        }

    }
}
