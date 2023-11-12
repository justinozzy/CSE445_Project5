using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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