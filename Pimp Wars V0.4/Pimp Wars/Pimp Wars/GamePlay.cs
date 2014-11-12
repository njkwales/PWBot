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
            //doc.GetElementById("p").SetAttribute("Value", turns);
            //doc.GetElementById("cow").InvokeMember("Click");

            var inputvars = doc.GetElementsByTagName("input");

            //loop through each htmlelement in inputvars and save any that contain the partial phase "pass" or "user" to the list inputvars
            foreach (HtmlElement elements in inputvars)
            {
                if (elements.Name.Contains("t_"))
                {
                    doc.GetElementById(elements.Name.ToString()).SetAttribute("Value", turns);
                }
                //else if (elements.Name.Contains("user"))
                //{
                //    doc.GetElementById(elements.Name.ToString()).SetAttribute("Value", Username);
                //}
                else if (elements.Name.Equals("Is+It+Hoe+Smackin+Time+Yet?"))
                {
                    elements.InvokeMember("Click");
                }
            }

        }
    }
}
