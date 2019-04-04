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
        //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        //{
            CustomPrincipal cp = HttpContext.Current.User as CustomPrincipal;
            String activepage = Request.RawUrl;
            if (cp != null && cp.IsInRole("Admin"))
            {
                AdminPanel.Visible = true;
                CandidatePanel.Visible = false;
            }
            if (cp == null || cp.IsInRole("Candidate") )
            {
                if (activepage.Contains("RegisterCandidate.aspx")
                    || activepage.Contains("ViewCandidate.aspx")
                    || activepage.Contains("CandidateManagement2.aspx")
                    || activepage.Contains("AddProfession.aspx")
                    || activepage.Contains("AddSkillSet.aspx")
                    || activepage.Contains("AddRegion.aspx")
                    || activepage.Contains("AddJobPosting.aspx")
                    || activepage.Contains("ViewJobPosting.aspx")
                    || activepage.Contains("ModifyJobPosting.aspx")
                    || activepage.Contains("ViewReports.aspx"))
                {
                    Response.Redirect("/Default.aspx");
                }

                AdminPanel.Visible = false;
                CandidatePanel.Visible = true;


        }

            if(cp == null)
            {
                CandidateProfileLink.Visible = false;
                LinkButton1.Visible = false;
                RegisterCandidateLink.Visible = true;
                LoginLink.Visible = true;
                RegisterAccountLink.Visible = true;
            }


            #region ActiveLinkCheck
            if (activepage.Contains("Default.aspx"))
            {
                DefaultLink.Attributes.Add("class", "nav-link active");
                DefaultLink2.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("RegisterCandidate.aspx"))
            {
                RegisterCandidateLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("ViewCandidate.aspx"))
            {
                ViewCandidateLink.Attributes.Add("class", "nav-link active");
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
            else if (activepage.Contains("CandidateProfile.aspx"))
            {
                CandidateProfileLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("Contact.aspx"))
            {
                ContactLink.Attributes.Add("class", "nav-link active");
                ContactLink2.Attributes.Add("class", "nav-link active");
            }           
            else if (activepage.Contains("ViewReports.aspx"))
            {
                ReportLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("AddProfession.aspx"))
            {
                AddProfessionLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("AddSkillSet.aspx"))
            {
                AddSkillsetLink.Attributes.Add("class", "nav-link active");
            }
            else if (activepage.Contains("AddRegion.aspx"))
            {
                AddRegionLink.Attributes.Add("class", "nav-link active");
            }
            else
            {
                DefaultLink.Attributes.Add("class", "nav-link active");
                DefaultLink2.Attributes.Add("class", "nav-link active");
            }
            #endregion
        //}
        //else
        //{
        //    SignOut.Text = "Sign In";
        //}
    }
    public void SignOut_Click(object sender, EventArgs args)
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }else
        {
            Response.Redirect("/Default.aspx");
        }
    }


}
