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
            ulong Turns = Convert.ToUInt64(textBox1.Text) - 90;
            Turns = Turns / Convert.ToUInt64(textBox2.Text);
            RollTurns(Turns);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            variables.turnstouse = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            variables.Update();
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
                variables.Update();
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
            //string URL = webBrowser8.Url.ToString();

            //if (URL == variables.URL + "go/online.pimp")
            //{
            //    webBrowser8.Navigate(variables.URL + "go/online.pimp");
            //}
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
            richTextBox1.Text = "";
            foreach (ulong K in stats)
            {
                richTextBox1.Text = richTextBox1.Text + K.ToString() + "\r\n";
            }

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
            variables.turnstouse = turnstoroll;
            GamePlay GP = new GamePlay();
            GP.SetPayOut("1", webBrowser8.Document);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region varibles

            bool ready;
            GamePlay GP = new GamePlay();

            #endregion

            #region Condom Check

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
            }
            //If you dont have enough money to buy condoms roll 1 turn
            else if (ready == true &&  variables.Whores > variables.Condoms && variables.Money < variables.Whores * 20)
            {
                //send wepage 3 unavailable signal
                rdy.wp3done = false;
                //Scout 5 Turn
                GP.Scout("5", webBrowser3.Document);
            }

            #endregion

            #region Buy Thugs

            ready = rdy.ReadyCheck();
            ulong Turnskk = variables.turnstouse * Convert.ToUInt64(textBox2.Text) + 90;
            if (ready == true && Turnskk > Convert.ToUInt64(textBox3.Text) && variables.Money > 2000)
            {
                rdy.wp6done = false;
                ulong thugstobuy = (variables.Money / 1000) - 1;
                GP.Tek9Buy(thugstobuy.ToString(), "", "", "", "", webBrowser6.Document);
            }

            #endregion 

            switch(variables.RollPosition)
            {

                #region
                case 1:
                    ready = rdy.ReadyCheck();

                    if (ready == true && variables.Whores > 1500)
                    {
                        if (variables.turnstouse > Convert.ToUInt64(textBox3.Text))
                        {
                            rdy.wp4done = false;
                            GP.MakeCrack(textBox3.Text, webBrowser4.Document);
                            variables.RollPosition++;
                        }
                        else
                        {
                            variables.RollPosition++;
                        }

                    }
                    break;
                #endregion

                #region

                case 2:
                    ready = rdy.ReadyCheck();

                    if (ready == true && variables.turnstouse > 0)
                    {
                        rdy.wp3done = false;
                        GP.Scout(textBox2.Text, webBrowser3.Document);
                        variables.turnstouse--;
                    }
                    break;
                #endregion

                #region
                case 3:
                    ready = rdy.ReadyCheck();

                    if (ready == true)
                    {
                        rdy.wp8done = false;
                        GP.SetPayOut("100", webBrowser8.Document);
                        variables.RollPosition++;
                    }
                    break;
                #endregion

                #region
                case 4:
                    ready = rdy.ReadyCheck();

                    if (ready == true && variables.Beer < variables.Thugs)
                    {
                        ulong beer = variables.Thugs - variables.Beer;

                        if (beer > 0)
                        {
                            GP.CornerStore("", "", beer.ToString(), webBrowser5.Document);
                        }

                        variables.RollPosition++;

                }
                    break;
                #endregion

                #region
                case 5:
                    //Check if webpages are available to use
                    ready = rdy.ReadyCheck();

                    //if webpages are available and there are less condoms than whores and you have enough money buy condoms
                    if (ready == true && variables.Whores * 5 < variables.Medicine && variables.Money > (subtract.Subtract(variables.Whores, variables.Medicine) * 5) * 20)
                    {
                        //send wepage 5 unavailable signal
                        rdy.wp5done = false;
                        //calculate how many condoms to buy
                        ulong meds = (subtract.Subtract(variables.Whores, variables.Medicine) * 5);
                        //buy condoms *This looks doggy as your buying exactly 5 time your whores need to find a way to round ulong up*
                        GP.CornerStore("", meds.ToString(), "", webBrowser5.Document);
                        variables.RollPosition++;
                    }
                    else if (ready == true && variables.Whores < variables.Medicine && variables.Money >= subtract.Subtract(variables.Whores, variables.Medicine) * 20 && subtract.Subtract(variables.Whores, variables.Medicine) != 0)
                    {
                        //send wepage 5 unavailable signal
                        rdy.wp5done = false;
                        //calculate how many condoms to buy
                        ulong meds = subtract.Subtract(variables.Whores, variables.Medicine);
                        //buy condoms *This looks doggy as your buying exactly 5 time your whores need to find a way to round ulong up*
                        GP.CornerStore("", meds.ToString(), "", webBrowser5.Document);
                        variables.RollPosition++;
                    }
                    //else if (ready == true)
                    //{

                    //    rdy.wp2done = false;
                    //    webBrowser2.Navigate(variables.URL + "go/");
                    //    variables.RollPosition++;
                    //}
                    break;
                #endregion

                #region
                case 6:
                    ready = rdy.ReadyCheck();
                
                    if (ready == true)
                    {
                        GP.Tek9Buy("", variables.PistolsToBuy.ToString(), "", "", variables.AKsToBuy.ToString(), webBrowser6.Document);
                        variables.RollPosition++;
                    }
                    break;
                #endregion

                #region
                case 8:
                    variables.RollPosition = 0;
                    timer1.Enabled = false;
                    break;
                #endregion

            }

            #region Use Turns *1*

            //if (variables.RollPosition == 1)
            //{
            //    ready = rdy.ReadyCheck();

            //    if (ready == true && variables.turnstouse > 0)
            //    {
            //        rdy.wp3done = false;
            //        GP.Scout(textBox2.Text, webBrowser3.Document);
            //        variables.turnstouse--;
            //    }
            //}

            #endregion

            #region roll for crack *2*

            //ready = rdy.ReadyCheck();

            //if (variables.RollPosition == 2)
            //{
            //    ready = rdy.ReadyCheck();

            //    if (ready == true && variables.Whores > 1500)
            //    {
            //        if (variables.turnstouse > Convert.ToUInt64(textBox3.Text))
            //        {
            //            rdy.wp4done = false;
            //            GP.MakeCrack(textBox3.Text, webBrowser4.Document);
            //            variables.RollPosition++;
            //        }
            //        else
            //        {
            //            variables.RollPosition++;
            //        }

            //    }

            //}

            #endregion

            #region Post Jump Set Pay out *2*

            //if (variables.RollPosition == 2)
            //{
            //    ready = rdy.ReadyCheck();

            //    if (ready == true)
            //    {
            //        rdy.wp8done = false;
            //        GP.SetPayOut("100", webBrowser8.Document);
            //        variables.RollPosition++;
            //    }
            //}
            

            #endregion 

            #region Post Jump Buy Beer *3*

            //if (variables.RollPosition == 3)
            //{
            //    ready = rdy.ReadyCheck();

            //    if (ready == true && variables.Beer < variables.Thugs)
            //    {
            //        ulong beer = variables.Thugs - variables.Beer;

            //        if (beer > 0)
            //        {
            //            GP.CornerStore("", "", beer.ToString(), webBrowser5.Document);
            //        }

            //        variables.RollPosition++;

            //    }
            //}

            #endregion 

            #region Post Jump Meds *4*

            if (variables.RollPosition == 4)
            {
                //Check if webpages are available to use
                ready = rdy.ReadyCheck();

                //if webpages are available and there are less condoms than whores and you have enough money buy condoms
                if (ready == true && variables.Whores * 5 < variables.Medicine && variables.Money > (subtract.Subtract(variables.Whores, variables.Medicine) * 5) * 20)
                {
                    //send wepage 5 unavailable signal
                    rdy.wp5done = false;
                    //calculate how many condoms to buy
                    ulong meds = (subtract.Subtract(variables.Whores, variables.Medicine) * 5);
                    //buy condoms *This looks doggy as your buying exactly 5 time your whores need to find a way to round ulong up*
                    GP.CornerStore("", meds.ToString(), "", webBrowser5.Document);
                    variables.RollPosition++;
                }
                else if (ready == true && variables.Whores < variables.Medicine && variables.Money >= subtract.Subtract(variables.Whores, variables.Medicine) * 20 && subtract.Subtract(variables.Whores, variables.Medicine) != 0)
                {
                    //send wepage 5 unavailable signal
                    rdy.wp5done = false;
                    //calculate how many condoms to buy
                    ulong meds = subtract.Subtract(variables.Whores, variables.Medicine);
                    //buy condoms *This looks doggy as your buying exactly 5 time your whores need to find a way to round ulong up*
                    GP.CornerStore("", meds.ToString(), "", webBrowser5.Document);
                    variables.RollPosition++;
                }
                //else if (ready == true)
                //{

                //    rdy.wp2done = false;
                //    webBrowser2.Navigate(variables.URL + "go/");
                //    variables.RollPosition++;
                //}
            }

            #endregion 

            #region Post Jump Buy Guns *5*

            //if(variables.RollPosition == 5)
            //{
            //    ready = rdy.ReadyCheck();
                
            //    if (ready == true)
            //    {
            //        GP.Tek9Buy("", variables.PistolsToBuy.ToString(), "", "", variables.AKsToBuy.ToString(), webBrowser6.Document);
            //        variables.RollPosition++;
            //    }
                
            //}

            #endregion 

            #region Finish

            //if (variables.RollPosition == 5)
            //{
            //    variables.RollPosition = 0;
            //    timer1.Enabled = false;
            //}

            #endregion
        }

    }
}
