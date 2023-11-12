using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace DefaultPage
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Set logged in session to true or false depending on if a user saved their login information previously or not
        void Session_Start(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["UserLoginCookie"];
            if (authCookie != null && authCookie.Expires != DateTime.Now.AddDays(-1))
            {
                Session["IsLoggedIn"] = true;
            }
            else
            {
                Session["IsLoggedIn"] = false;
            }
        }
    }
}