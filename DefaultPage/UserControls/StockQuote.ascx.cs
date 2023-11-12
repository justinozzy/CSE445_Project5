using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DefaultPage.ServiceReference1;

namespace WebApplication1.User_Controls
{
    public partial class StockQuote : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["StockQuoteInfo"];

            if (cookie != null)
            {
                price.Text = cookie["stockQuote"];
                //symbolBox.Text = cookie["stockSymbol"];
            }
        }

        protected void SymbolBtn_Click(object sender, EventArgs e)
        {
            Service1Client s = new Service1Client();
            price.Text = s.StockQuote(symbolBox.Text).ToString();

            HttpCookie cookie = new HttpCookie("StockQuoteInfo");
            cookie["stockQuote"] = price.Text;
            //cookie["stockSymbol"] = symbolBox.Text;
            cookie.Expires = DateTime.Now.AddHours(2);
            Response.Cookies.Add(cookie);

        }
    }
}