using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            CustomPrincipal cp = HttpContext.Current.User as CustomPrincipal;

            if (cp.IsInRole("Administrator"))
            {

            }
            if (cp.IsInRole("Candidate"))
            {
                //Response.Write(cp.Identity.Name + " is a Candidate <br/>");
                //HtmlAnchor h = Master.FindControl("RegisterCandidate") as HtmlAnchor;
                //h.Visible = false;
            }

            String activepage = Request.RawUrl;
            if (activepage.Contains("Default.aspx"))
            {
                DefaultLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("RegisterCandidate.aspx"))
            {
                RegisterCandidateLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("AddJobPosting.aspx"))
            {
                AddJobPostingLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("ModifyJobPosting.aspx"))
            {
                ModifyJobPostingLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("ViewJobPosting.aspx"))
            {
                ViewJobpostingLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("CandidateManagement.aspx"))
            {
                CandidateManagementLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("Contact.aspx"))
            {
                ContactLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("ViewReports.aspx"))
            {
                ReportLink.Attributes.Add("class", "nav-link active");
            }
            else
            {
                DefaultLink.Attributes.Add("class", "nav-link active");
            }
        }else
        {
            SignOut.Text = "Sign In";
        }
    }
    public void SignOut_Click(object sender, EventArgs args)
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }else
        {
            Response.Redirect("/Login.aspx");
        }
    }


}
