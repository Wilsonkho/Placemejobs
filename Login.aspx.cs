﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Click(object sender, EventArgs e)
    {
        try
        {
            User ReturnUser = new User();
            ReturnUser.UserEmail = UserEmail.Text;
            ReturnUser.UserPassword = UserPass.Text;

            PRMS con = new PRMS();

            if (con.GetUser(ReturnUser))
            {
                //Createthe authentication ticket
                string UserRole = con.GetRoles(ReturnUser);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, UserEmail.Text, DateTime.Now, DateTime.Now.AddMinutes(60), false, UserRole);
                //Encrypt the ticket
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                //Create a cookie and add the encrypted ticket to the cookie as data
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                //Add the cookie to the cookies collection 
                Response.Cookies.Add(authCookie);
                //FormsAuthentication.RedirectFromLoginPage(UserEmail.Text, Persist.Checked);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(UserEmail.Text, false));
            }
            else
            {
                //Msg.Text = "Invalid credentials. Please try again.";
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with logging into the account. Please contact customer support for assistance if this issue persists.’)", true);
        }

    }

    protected void RegisterLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegisterAccount.aspx");
    }
}