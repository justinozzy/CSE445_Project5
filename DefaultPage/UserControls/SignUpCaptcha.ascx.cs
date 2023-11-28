using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Net;

namespace DefaultPage.UserControls
{
    public partial class SignUpCaptcha : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string recaptchaResponse = Request.Form["g-recaptcha-response"];

                // Verify reCAPTCHA
                if (!string.IsNullOrEmpty(recaptchaResponse) && VerifyReCaptcha(recaptchaResponse))
                {
                    // Get input values from form fields
                    string name = txtName.Text;
                    string email = txtEmail.Text;
                    string password = txtPassword.Text;

                    // Encrypt the password (you may want to use a more secure method in a real application)
                    string encryptedPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));

                    string directory = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = "Users.xml";
                    string fileLocation = "App_Data";
                    string xmlFilePath = Path.Combine(directory, fileLocation);
                    xmlFilePath = Path.Combine(xmlFilePath, filename);
                    // Create or load the Users.xml file

                    XmlDocument xmlDoc = new XmlDocument();
                    if (File.Exists(xmlFilePath))
                    {
                        xmlDoc.Load(xmlFilePath);
                    }
                    else
                    {
                        // If the file doesn't exist, create a new XML document
                        XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        xmlDoc.AppendChild(xmlDeclaration);

                        XmlElement rootElement = xmlDoc.CreateElement("Users");
                        xmlDoc.AppendChild(rootElement);
                    }

                    // Create a new user node
                    XmlElement userElement = xmlDoc.CreateElement("User");
                    userElement.SetAttribute("type", "member");

                    XmlElement nameElement = xmlDoc.CreateElement("name");
                    nameElement.InnerText = name;

                    XmlElement emailElement = xmlDoc.CreateElement("email");
                    emailElement.InnerText = email;

                    XmlElement passwordElement = xmlDoc.CreateElement("password");
                    passwordElement.InnerText = encryptedPassword;

                    userElement.AppendChild(nameElement);
                    userElement.AppendChild(emailElement);
                    userElement.AppendChild(passwordElement);

                    // Append the new user node to the Users.xml file
                    xmlDoc.DocumentElement?.AppendChild(userElement);

                    // Save the changes to the file
                    xmlDoc.Save(xmlFilePath);

                    // Display a success message
                    lblMessage.Text = "User registered successfully!";

                }
                else
                {
                    lblMessage.Text = "Validation Failed";
                }
            }catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private bool VerifyReCaptcha(string response)
        {
            string secretKey = "6Lee7h4pAAAAANyO8FikXM5rMU1j72Wxs-ZCLSZf"; // Replace with your reCAPTCHA secret key

            using (WebClient client = new WebClient())
            {
                string apiUrl = $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}";
                string jsonResult = client.DownloadString(apiUrl);

                // Parse the JSON result
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult);

                // Check if the verification was successful
                return result.success;
            }
        }

    }
}