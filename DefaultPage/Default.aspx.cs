﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginVerifier;

namespace DefaultPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if the user is logged in and display the corresponding buttons based on state
            if ((bool)Session["IsLoggedIn"] == true)
            {
                btnOpenModal.Visible = false;
                logOutButton.Visible = true;
                StatusLabel.Text = "Current logged in as {SET USER WITH COOKIE}";
            }
            else
            {
                logOutButton.Visible = false;
                btnOpenModal.Visible = true;
                StatusLabel.Text = "Not logged in...";
            }
        }

        //Logs a user in and saves their username inside of a cookie for state management
        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                //Use the LoginVerifier DLL to see if the user currently exists
                int loginStatus = LoginVerifierClass.verifyUser(loginUsername.Text, loginPassword.Text);

                //User not found in the XML file or passwords mismatch
                if (loginStatus == 0)
                {
                    StatusLabel.Text = "Login failed: Username not found or Password is incorrect.";
                }
                //Successful login - Create a new cookie that stores their username and sets the logged in state to true
                else if (loginStatus == 1)
                {
                    Session["IsLoggedIn"] = true;
                    HttpCookie authCookie = new HttpCookie("UserLoginCookie");
                    authCookie.Values["Username"] = loginUsername.Text;
                    
                    //Save login for future revisits to site if box is checked
                    if (saveInfoBox.Checked)
                    {
                        authCookie.Expires = DateTime.Now.AddYears(100);
                    }

                    Response.Cookies.Add(authCookie);

                    StatusLabel.Text = "Current logged in as {SET USER WITH COOKIE}";
                }
                //Error somewhere in code - See console for information
                else
                {
                    StatusLabel.Text = "Login failed: Error occured, please try again.";
                }

                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
            }
        }

        //Logs the user out and resets session state
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["IsLoggedIn"] = false;

            //Delete the UserLoginCookie as it's no longer needed
            HttpCookie authCookie = Request.Cookies["UserLoginCookie"];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(authCookie);
            }

            Response.Redirect("Default.aspx");
        }
    }
}