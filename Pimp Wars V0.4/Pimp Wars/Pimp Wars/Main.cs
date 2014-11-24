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
        Ready rdy = new Ready();
        Subtract_Uint subtract = new Subtract_Uint();
        Log _log = new Log();


        public Main(String Alias, String URL, String Username, String Password)
        {
            InitializeComponent();
            variables.Alias = Alias;
            variables.URL = URL;
            variables.Username = Username;
            variables.Password = Password;
            _log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            variables.CalcRolls(Convert.ToUInt64(textBox1.Text), Convert.ToUInt64(textBox2.Text));
            RollTurns(variables.NoOfRolls);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{`}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            variables.GunsToBuyCalc();
            MessageBox.Show(variables.AKsToBuy.ToString() + " AK's " + variables.PistolsToBuy.ToString() + " Pistols " + ((variables.AKsToBuy * 5000) + (variables.PistolsToBuy * 500)));
        }

        private void Main_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;
            webBrowser3.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(variables.URL);
        }

        #region Webbrowsers

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
                webBrowser8.Navigate(variables.URL + "go/");
            }
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser2.Url.ToString();

            if (URL != variables.URL + "go/")
            {
                rdy.wp2done = false;
                webBrowser2.Navigate(variables.URL + "go/");
            }
            else
            {
                webBrowser2.Document.ExecCommand("SelectAll", false, null);
                webBrowser2.Document.ExecCommand("Copy", false, null);
                getStats(Clipboard.GetText());
                variables.SaveStats();

                rdy.wp2done = true;
            }
        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser3.Url.ToString();

            if (URL != variables.URL + "go/action.pimp?menu=scout")
            {
                rdy.wp3done = false;
                webBrowser3.Navigate(variables.URL + "go/action.pimp?menu=scout");
            }
            else
            {
                rdy.wp2done = false;
                webBrowser2.Navigate(variables.URL + "go/");
                rdy.wp3done = true;
            }

        }

        private void webBrowser4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser4.Url.ToString();

            if (URL != variables.URL + "go/action.pimp?menu=mkcrack")
            {
                rdy.wp4done = false;
                webBrowser4.Navigate(variables.URL + "go/action.pimp?menu=mkcrack");
            }
            else
            {
                rdy.wp2done = false;
                webBrowser2.Navigate(variables.URL + "go/");
                rdy.wp4done = true;
            }
        }

        private void webBrowser5_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser5.Url.ToString();

            if (URL != variables.URL + "go/buy.pimp?menu=corner")
            {
                rdy.wp5done = false;
                webBrowser5.Navigate(variables.URL + "go/buy.pimp?menu=corner");
            }
            else
            {
                rdy.wp2done = false;
                webBrowser2.Navigate(variables.URL + "go/");
                rdy.wp5done = true;
            }
        }

        private void webBrowser6_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser6.Url.ToString();

            if (URL != variables.URL + "go/buy.pimp?menu=tommy")
            {
                rdy.wp6done = false;
                webBrowser6.Navigate(variables.URL + "go/buy.pimp?menu=tommy");
            }
            else
            {
                rdy.wp2done = false;
                webBrowser2.Navigate(variables.URL + "go/");
                rdy.wp6done = true;
            }
        }

        private void webBrowser7_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser7.Url.ToString();

            if (URL != variables.URL + "go/buy.pimp?menu=deals")
            {
                rdy.wp7done = false;
                webBrowser7.Navigate(variables.URL + "go/buy.pimp?menu=deals");
            }
            else
            {
                rdy.wp2done = false;
                webBrowser2.Navigate(variables.URL + "go/");
                rdy.wp7done = true;
            }
        }

        private void webBrowser8_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string URL = webBrowser8.Url.ToString();

            if (URL != variables.URL + "go/index.pimp")
            {
                rdy.wp8done = false;
                webBrowser7.Navigate(variables.URL + "go/index.pimp");
            }
            else
            {
                rdy.wp2done = false;
                webBrowser2.Navigate(variables.URL + "go/index.pimp");
                rdy.wp8done = true;
            }
        }

        #endregion

        private void getStats(string text)
        {
            StatGrabber sg = new StatGrabber();
            var stats = sg.GetStatsbig(text);

            _log.Stats(stats);

            string payout = webBrowser2.Document.GetElementById("p").GetAttribute("value");
            ulong Payout = Convert.ToUInt64(payout);

            variables.Worth = stats[0];
            variables.Money = stats[1];
            variables.Turns = stats[2];
            variables.Reserve = stats[3];
            variables.Whores = stats[4];
            variables.Thugs = stats[5];
            variables.Condoms = stats[6];
            variables.Weapons = stats[7];
            variables.Crack = stats[8];
            variables.Beer  = stats[9];
            variables.Medicine = stats[10];
            variables.Lowriders = stats[11];
            variables.Pistols = stats[12];
            variables.Shotguns = stats[13];
            variables.MP5s = stats[14];
            variables.AK47s = stats[15];
            variables.Payout = Payout;
        }

        private void RollTurns(ulong turnstoroll)
        {
            GamePlay GP = new GamePlay();
            GP.SetPayOut("1", webBrowser8.Document);
            _log.LogEntry("Setting Pay out To 1");
            timer1.Enabled = true;
            variables.RollPosition = 1;
            _log.LogEntry("Using " + textBox1.Text + " turns at " + textBox2.Text + " turns per roll for a total of " + variables.NoOfRolls + " Rolls");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region varibles

            bool ready;
            GamePlay GP = new GamePlay();

            #endregion

            switch(variables.RollPosition)
            {

                #region Roll Crack

                case 1:
                    ready = rdy.ReadyCheck();
                    variables.CrackTurnsToRollCalc();

                    if (ready == true && variables.Whores > 1500)
                    {
                        rdy.wp4done = false;
                        GP.MakeCrack(variables.CrackTurnsToRoll.ToString(), webBrowser4.Document);
                        variables.NoOfRolls = variables.NoOfRolls - variables.CrackTurnsToRoll;
                        variables.RollPosition++;
                        _log.LogEntry("Rolling " + variables.CrackTurnsToRoll.ToString() + " for crack");
                    }
                    else if (variables.Whores <= 1500)
                    {
                        variables.RollPosition++;
                        _log.LogEntry("Under 1500 Whores skipping crack rolls");
                    }

                    break;

                #endregion

                #region Roll Turns

                case 2:
                    ready = rdy.ReadyCheck();

                    if (ready == true && variables.NoOfRolls > 0)
                    {
                        rdy.wp3done = false;
                        GP.Scout(textBox2.Text, webBrowser3.Document);
                        _log.LogEntry("Rolling : " + textBox2.Text + " turns" + " - Rolls left : " + variables.NoOfRolls);
                        variables.NoOfRolls--;
                        variables.RollPosition = 99;
                    }
                    else if (variables.NoOfRolls <= 0)
                    {
                        variables.RollPosition++;
                        _log.LogEntry("Finished rolling turns");
                    }
                    break;

                #endregion

                #region Set Payout High
                case 3:
                    ready = rdy.ReadyCheck();

                    if (ready == true)
                    {
                        rdy.wp8done = false;
                        GP.SetPayOut("100", webBrowser8.Document);
                        _log.LogEntry("Setting payout to 100");
                        variables.RollPosition++;
                    }
                    break;
                #endregion

                #region Spare

                case 4:
                    ready = rdy.ReadyCheck();

                    if (ready == true && variables.Beer < variables.Thugs)
                    {
                        
                    }

                    variables.RollPosition++;

                    break;
                #endregion

                #region Buy Meds
                case 5:

                    ready = rdy.ReadyCheck();
                    variables.MedsToBuyCalc();

                    if (ready == true && variables.MedsToBuy > 0)
                    {
                        //send webpage 5 unavailable signal
                        rdy.wp5done = false;
                        //buy condoms *This looks doggy as your buying exactly 5 time your whores need to find a way to round ulong up*
                        GP.CornerStore("", variables.MedsToBuy.ToString(), variables.Thugs.ToString(), webBrowser5.Document);
                        _log.LogEntry("Bought " + variables.MedsToBuy.ToString() + " meds & " + variables.Thugs.ToString() + "Beer");
                        variables.RollPosition++;
                    }
                    else if (ready == true && variables.MedsToBuy == 0)
                    {
                        rdy.wp5done = false;
                        GP.CornerStore("", "", variables.Thugs.ToString(), webBrowser5.Document);
                        _log.LogEntry("No meds needed " + variables.Thugs.ToString() + " Beer bought");
                        variables.RollPosition++;
                    }

                    break;
                #endregion

                #region Buy Guns
                case 6: 
                    ready = rdy.ReadyCheck();

                    if (ready == true)
                    {
                        variables.GunsToBuyCalc();
                        GP.Tek9Buy("", variables.PistolsToBuy.ToString(), "", "", variables.AKsToBuy.ToString(), webBrowser6.Document);
                        _log.LogEntry("Buying : " + variables.PistolsToBuy.ToString() + " Pistols & " + variables.AKsToBuy.ToString() + " AK's");
                        variables.RollPosition++;
                    }
                    break;
                #endregion

                #region
                case 7:
                    variables.RollPosition = 0;
                    timer1.Enabled = false;
                    _log.LogEntry("Finshed");
                    break;
                #endregion

                #region Checker

                case 99:

                    if (variables.Condoms < variables.Whores)
                    {
                        variables.RollPosition = 101;
                    }
                    else if ((Convert.ToUInt64(textBox1.Text) * Convert.ToUInt64(textBox2.Text)) > Convert.ToUInt64(textBox3.Text) && variables.Money > 5000)
                    {
                        variables.RollPosition = 100;
                    }
                    else
                    {
                        variables.RollPosition = 2;
                    }

                    break;

                #endregion

                #region Thugs

                case 100:

                    ready = rdy.ReadyCheck();
                    variables.ThugsToBuyCalc();
                    if (ready == true)
                    {
                        rdy.wp6done = false;
                        GP.Tek9Buy(variables.ThugsToBuy.ToString(), "", "", "", "", webBrowser6.Document);
                        _log.LogEntry("Buying : " + variables.ThugsToBuy.ToString() + " thugs");
                        variables.RollPosition = 2;
                    }

                    break;

                #endregion

                #region Condoms

                case 101:

                    //Check if webpages are available to use
                    ready = rdy.ReadyCheck();
                    //if webpages are available and there are less condoms than whores and you have enough money buy condoms
                    if (ready == true && variables.Whores > variables.Condoms && variables.Money >= variables.Whores * 20)
                    {
                        //send wepage 5 unavailable signal
                        rdy.wp5done = false;
                        //calculate how many condoms to buy
                        ulong condoms = variables.Whores * 20;
                        //buy condoms *This looks doggy as your buying exactly 20 time your whores need to find a way to round ulong up*
                        GP.CornerStore(condoms.ToString(), "", "", webBrowser5.Document);
                        _log.LogEntry("Buying : " + condoms.ToString() + " Condoms");
                        variables.RollPosition = 2;
                    }
                    //If you dont have enough money to buy condoms roll 1 turn
                    else if (ready == true && variables.Whores > variables.Condoms && variables.Money < variables.Whores * 20)
                    {
                        //send wepage 3 unavailable signal
                        rdy.wp3done = false;
                        //Scout 5 Turn
                        GP.Scout("5", webBrowser3.Document);
                        _log.LogEntry("Not enough cash for condoms rolling turns");
                    }

                    break;

                #endregion
            }


        }

    }
}
