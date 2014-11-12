using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Pimp_Wars
{
    class Login
    {
        public void GetLoginIDs(HtmlDocument doc, String Username, String Password)
        {
            //Aim :
            //The input box id's are dynamic and therfore need to be identified each time we try to log in
            //Breif:
            //Get all elements on page
            //loop through each one and identify the Username and Password input box
            //Set username in variables class
            //Set password in variables class

            List<string> List = new List<string>();

            //Get all the elements from the HTML document "doc" with the tag type Input and keep them in a var called inputvars
            var inputvars = doc.GetElementsByTagName("input");

            //loop through each htmlelement in inputvars and save any that contain the partial phase "pass" or "user" to the list inputvars
            foreach (HtmlElement elements in inputvars)
            {
                if (elements.Name.Contains("pass"))
                {
                    doc.GetElementById(elements.Name.ToString()).SetAttribute("Value", Password);
                }
                else if (elements.Name.Contains("user"))
                {
                    doc.GetElementById(elements.Name.ToString()).SetAttribute("Value", Username);
                }
                else if (elements.GetAttribute("OuterHTML").Equals("<INPUT class=button size=10 type=submit value=LOG-IN>"))
                {
                    elements.InvokeMember("Click");
                }
            }

        }
    }
}
