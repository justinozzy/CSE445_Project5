using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using DefaultPage.ServiceReference1;

namespace WebApplication1
{
    public partial class StockBuild : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["StockBuildInfo"];

            if(cookie != null)
            {

                // Your input string with cookies
                string cookies = cookie["stockBuild"]; // (Your full string here)

                // Replace the specified substring
                string replacedCookies = cookies.Replace("%0a%0d%0a", "\n");

                StockBuildBox.Text = replacedCookies;

                //limitBox.Text = cookie["stockLimit"];
            }
        }

        protected void Enter_Click(object sender, EventArgs e)
        {
            Service1Client s = new Service1Client();
            int limit = int.Parse(limitBox.Text);
            s.StockBuild(limit);
            string data = s.getData();
            StockBuildBox.Text = data;


            XmlDocument xmlDoc = ParseStockStringToXml(data);

            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "Member.xml";
            string fileLocation = "App_Data";
            string filepath = Path.Combine(directory, fileLocation);
            filepath = Path.Combine(filepath, filename);

            xmlDoc.Save(filepath);

            HttpCookie cookie = new HttpCookie("StockBuildInfo");
            cookie["stockBuild"] = StockBuildBox.Text;
            //cookie["stockLimit"] = limitBox.Text;
            cookie.Expires = DateTime.Now.AddHours(2);
            Response.Cookies.Add(cookie);
        }

        static XmlDocument ParseStockStringToXml(string inputString)
        {
            // Create an XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));

            // Create the root element
            XmlElement rootElement = xmlDoc.CreateElement("stockList");
            xmlDoc.AppendChild(rootElement);

            // Split the input string into lines
            string[] lines = inputString.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                // Split each line into symbol and quote
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    // Create the stock element
                    XmlElement stockElement = xmlDoc.CreateElement("stock");

                    // Create and append the name element
                    XmlElement nameElement = xmlDoc.CreateElement("name");
                    nameElement.InnerText = parts[0];
                    stockElement.AppendChild(nameElement);

                    // Create and append the price element
                    XmlElement priceElement = xmlDoc.CreateElement("price");
                    priceElement.InnerText = parts[1];
                    stockElement.AppendChild(priceElement);

                    // Append the stock element to the root element
                    rootElement.AppendChild(stockElement);
                }
                else
                {
                    Console.WriteLine($"Invalid format in line: {line}. Skipping.");
                }
            }

            return xmlDoc;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "Member.xml";
            string fileLocation = "App_Data";
            string filepath = Path.Combine(directory, fileLocation);
            filepath = Path.Combine(filepath, filename);
            Response.Redirect(filepath);
        }
    }
}