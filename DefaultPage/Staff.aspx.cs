using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using DefaultPage.SOAPServicesLikhit;

namespace Yarramsetti_A6_Components
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IsStaff"] == null || !(bool)Session["IsStaff"])
                {
                    Response.Redirect("~/StaffLogin.aspx");
                }
            }

            HttpCookie cookie = Request.Cookies["NewsArticles"];
            if (cookie != null)
            {
                SOAPServicesLikhitClient myClient = new SOAPServicesLikhitClient();
                string[] URLs = myClient.NewsFocus(cookie.Values["articles"].Split(','));
                string result = $"<p><b>Recently searched topics: </b>{cookie.Values["articles"]}</p><ul>";
                foreach (string url in URLs)
                {
                    result += "<li>" + url + "</li>";
                }
                result += "</ul>";
                NewsFocusResults.Text = result;
            }
        }

        protected void staffLogout_Click(object sender, EventArgs e)
        {
            Session["IsStaff"] = false;
            Response.Redirect("Default.aspx", true);
        }

        protected void NewsFocusButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] topics = TopicsInput.Text.Split(',');
                SOAPServicesLikhitClient myClient = new SOAPServicesLikhitClient();
                string[] URLs = myClient.NewsFocus(topics);
                string result = $"<p><b>Recently searched topics: </b>{TopicsInput.Text}</p><ul>";
                foreach (string url in URLs)
                {
                    result += "<li>" + url + "</li>";
                }
                result += "</ul>";
                NewsFocusResults.Text = result;

                HttpCookie cookie = new HttpCookie("NewsArticles");
                cookie.Values["articles"] = TopicsInput.Text;
                Response.Cookies.Add(cookie);

                //Response.Redirect("Staff.aspx", false);

            }
            catch (Exception ex)
            {
                NewsFocusResults.Text = ex.Message.ToString();
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // Convert password to base64
            byte[] passwordBytes = Encoding.UTF8.GetBytes(Password.Text);
            string b64password = Convert.ToBase64String(passwordBytes);

            string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Staff.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                string currAttribute = node.LocalName;
                if (currAttribute == "username")
                {
                    // Get user
                    string currUser = node.InnerText;
                    if (currUser == Username.Text)
                    {
                        RegisterResults.Text = "Error: a user with this username already exists.";
                        return;
                    }
                }
            }

            // Create a new user node
            XmlNode newUser = xmlDoc.CreateElement("Staff");

            // Create username and password elements
            XmlNode usernameNode = xmlDoc.CreateElement("username");
            usernameNode.InnerText = Username.Text;

            XmlNode passwordNode = xmlDoc.CreateElement("password");
            passwordNode.InnerText = b64password;

            // Append username and password elements to the new user node
            newUser.AppendChild(usernameNode);
            newUser.AppendChild(passwordNode);

            // Append the new user node to the StaffUsers root node
            xmlDoc.DocumentElement.AppendChild(newUser);

            // Save the modified XML document
            xmlDoc.Save(xmlFilePath);

            RegisterResults.Text = $"User {Username.Text} registered.";
        }
    }
}