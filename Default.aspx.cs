using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Welcome.Text = " Hello, " + Context.User.Identity.Name + "<br/>";
        CustomPrincipal cp = HttpContext.Current.User as CustomPrincipal;

        Response.Write("Authenticated Identity is: " + cp.Identity.Name);
        Response.Write("<p>");
        
        if (cp.IsInRole("Administrator"))
        {
            Response.Write(cp.Identity.Name + " is a Admin <br/>");
        }
        if (cp.IsInRole("Candidate"))
        {
            Response.Write(cp.Identity.Name + " is a Candidate <br/>");
        }

    }

    protected void Signout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}