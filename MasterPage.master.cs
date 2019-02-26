using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
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
            DefaultLink.Attributes.Add("class", "active");
        }
        else if (activepage.Contains("RegisterCandidate.aspx"))
        {
            RegisterCandidateLink.Attributes.Add("class", "active");
        }
        else if (activepage.Contains("AddJobPosting.aspx"))
        {
            AddJobPostingLink.Attributes.Add("class", "active");
        }
        else if (activepage.Contains("CandidateManagement.aspx"))
        {
            CandidateManagementLink.Attributes.Add("class", "active");
        }
    }
}
