using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IsLoggedIn"] == null || !(bool)Session["IsLoggedIn"])
                {
                    string script = "setTimeout(function() { alert('Must be logged in to interact with page.'); window.location.href = 'Default.aspx'; }, 50);";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                    //Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "StockBuild.ascx";
            string fileLocation = "UserControls";
            string filepath = Path.Combine(directory, fileLocation);
            filepath = Path.Combine(filepath, filename);
            Response.Redirect(filepath);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "StockQuote.ascx";
            string fileLocation = "UserControls";
            string filepath = Path.Combine(directory, fileLocation);
            filepath = Path.Combine(filepath, filename);
            Response.Redirect(filepath);
        }
    }
}