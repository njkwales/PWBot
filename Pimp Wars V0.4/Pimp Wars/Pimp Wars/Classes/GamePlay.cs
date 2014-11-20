using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Pimp_Wars
{
    class GamePlay
    {
        public void SetPayOut(string HiLo, HtmlDocument doc)
        {
            doc.GetElementById("p").SetAttribute("Value", HiLo);
            doc.GetElementById("cow").InvokeMember("Click");
        }

        public void Scout(string turns, HtmlDocument doc)
        {

            var inputvars = doc.GetElementsByTagName("input");

            //loop through each htmlelement in inputvars and save any that contain the partial phase "pass" or "user" to the list inputvars
            foreach (HtmlElement elements in inputvars)
            {
                if (elements.Name.Contains("t_"))
                {
                    doc.GetElementById(elements.Name.ToString()).SetAttribute("Value", turns);
                }
                else if (elements.Name.Equals("Is+It+Hoe+Smackin+Time+Yet?"))
                {
                    elements.InvokeMember("Click");
                }
            }

        }

        public void CornerStore(string Condoms, string Medicine, string Beer, HtmlDocument doc)
        {
            doc.GetElementById("numcondoms").SetAttribute("Value", Condoms);
            doc.GetElementById("nummedicine").SetAttribute("Value", Medicine);
            doc.GetElementById("numbeer").SetAttribute("Value", Beer);
            
            var inputvars = doc.GetElementsByTagName("input");

            foreach (HtmlElement elements in inputvars)
            {
                if (elements.GetAttribute("OuterHTML").Equals("<INPUT class=button type=submit value=\"Buy items\">"))
                {
                    elements.InvokeMember("Click");
                }
            }
        }

        public void Tek9Buy(string Thugs, string Pistols, string Shotgun, string MP5, string AK47, HtmlDocument doc)
        {
            if (Thugs != "")
            {
                doc.GetElementById("bt").SetAttribute("Value", Thugs);
                //doc.GetElementById("bt").Focus();
                //System.Windows.Forms.SendKeys.Send("{`}");
            }

            if (Pistols != "")
            {
                doc.GetElementById("bw1").SetAttribute("Value", Pistols);

            }

            if (Shotgun != "")
            {
                doc.GetElementById("bw2").SetAttribute("Value", Shotgun);
            }

            if (MP5 != "")
            {
                doc.GetElementById("bw3").SetAttribute("Value", MP5);
            }

            if (AK47 != "")
            {
                doc.GetElementById("bw4").SetAttribute("Value", AK47);
            }


            var inputvars = doc.GetElementsByTagName("input");

            foreach (HtmlElement elements in inputvars)
            {
                if (elements.GetAttribute("OuterHTML").Equals("<INPUT class=button type=submit value=\"Buy items\">"))
                {
                    elements.InvokeMember("Click");
                }
            }
        }

        public void Tek9sell(string Pistols, string Shotgun, string MP5, string AK47, HtmlDocument doc)
        {
            doc.GetElementById("sw1").SetAttribute("Value", Pistols);
            doc.GetElementById("sw2").SetAttribute("Value", Shotgun);
            doc.GetElementById("sw3").SetAttribute("Value", MP5);
            doc.GetElementById("sw4").SetAttribute("Value", AK47);

            var inputvars = doc.GetElementsByTagName("input");

            foreach (HtmlElement elements in inputvars)
            {
                if (elements.GetAttribute("OuterHTML").Equals("<INPUT class=button type=submit value=\"Sell items\">"))
                {
                    elements.InvokeMember("Click");
                }
            }
        }

        public void DealsOnWheels(string Crack, HtmlDocument doc)
        {
            doc.GetElementById("numcrack").SetAttribute("Value", Crack);


            var inputvars = doc.GetElementsByTagName("input");

            foreach (HtmlElement elements in inputvars)
            {
                if (elements.GetAttribute("OuterHTML").Equals("<input type=\"submit\" class=\"button\" value=\"Buy drugs\">"))
                {
                    elements.InvokeMember("Click");
                }
            }
        }

        public void MakeCrack(string Crack, HtmlDocument doc)
        {
            var inputvars = doc.GetElementsByTagName("input");

            //loop through each htmlelement in inputvars and save any that contain the partial phase "pass" or "user" to the list inputvars
            foreach (HtmlElement elements in inputvars)
            {
                if (elements.Name.Contains("t_"))
                {
                    doc.GetElementById(elements.Name.ToString()).SetAttribute("Value", Crack);
                }
                else if (elements.Name.Contains(",why+are+you+reading+html+source+you+hoe"))
                {
                    elements.InvokeMember("Click");
                }
            }
        }
    }
}
