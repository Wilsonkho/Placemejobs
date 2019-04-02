using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Signout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}