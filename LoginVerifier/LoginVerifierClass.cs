using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LoginVerifier
{
    public class LoginVerifierClass
    {
        //Takes in a username and password and searches through an XML file to find a match for both of them - Returns 1 if found, 0 if not found, and -1 for error
        public static int verifyUser(string username, string password)
        {
            try
            {
                //Convert password into base64 (encoding)
                byte[] passtoBytes = Encoding.UTF8.GetBytes(password);
                string base64Password = Convert.ToBase64String(passtoBytes);

                //Load XML Document
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Users.xml"));

                //Find all nodes with matching usernames
                XmlNodeList usernameNodes = xmlDoc.SelectNodes($"/Users/User[username='{username}']");

                if (usernameNodes.Count > 0)
                {
                    //Search all nodes with matching username and see if their encoded passwords match
                    foreach (XmlNode usernameNode in usernameNodes)
                    {
                        string currPassword = usernameNode.SelectSingleNode("password").InnerText;

                        if (currPassword == base64Password)
                        {
                            return 1;
                        }
                    }
                }

                //User not found
                return 0;
            }
            catch (Exception e)
            {
                //Something very bad happened
                Console.WriteLine("Error: " + e.Message);
                return -1;
            }
        }
    }
}
