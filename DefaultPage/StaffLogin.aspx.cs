using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginVerifier;

namespace DefaultPage
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void staffLogin_Click(object sender, EventArgs e)
        {
            int loginStatus = LoginVerifierClass.verifyStaff(UsernameBox.Text, PasswordBox.Text);

            if (loginStatus == 0 || loginStatus == -1)
            {
                errResponse.Text = "Incorrect Information - Try again";
            }
            else if (loginStatus == 1)
            {
                Session["IsStaff"] = true;
                Response.Redirect("Staff.aspx", true);
            }
        }
    }
}