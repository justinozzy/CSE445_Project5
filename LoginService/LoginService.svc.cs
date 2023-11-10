using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public int verifyUser(string username, string password)
        {
            try
            {
                byte[] passtoBytes = Encoding.UTF8.GetBytes(password);
                string base64Password = Convert.ToBase64String(passtoBytes);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Users.xml"));

                XmlNodeList usernameNodes = xmlDoc.SelectNodes($"/Users/User[username='{username}']");

                if (usernameNodes.Count > 0 )
                {
                    foreach (XmlNode usernameNode in usernameNodes )
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
                Console.WriteLine("Error: " + e.Message);
                return -1;
            }
        }
    }
}
