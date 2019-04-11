using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Web.Security;

public partial class CandidateProfile : System.Web.UI.Page
{
    List<Profession> professions;
    List<Skillset> skillsets;
    List<Region> regions;
    int CurrentUserID;
    string CurrentUserCoverLetter;
    string CurrentUserResume;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            User CurrentUser = new User();
            CustomPrincipal cp = HttpContext.Current.User as CustomPrincipal;
            PRMS UserController = new PRMS();
            CurrentUser = UserController.ViewProfile(cp.Identity.Name);
            CurrentUserID = CurrentUser.UserID;
            CurrentUserCoverLetter = CurrentUser.CoverLetter;
            CurrentUserResume = CurrentUser.Resume;           


            if (!IsPostBack)
            {
                FirstName.Text = CurrentUser.FirstName;
                LastName.Text = CurrentUser.LastName;
                Phone.Text = CurrentUser.Phone;
                EmailTextBox.Text = CurrentUser.UserEmail;
                if (CurrentUser.ActiveInactive)
                {
                    Active.Checked = true;
                }
                else
                {
                    Active.Checked = false;
                }

                BindDropDowns();
                PopulateSkillsTable();
                PopulateProfessionTable();
                PopulateRegionTable();

                Session["FileUpload1"] = null;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred while obtaining data. Please contact customer support for assistance if this issue persists.’)", true);
        }

    }

    protected void BindDropDowns()
    {
        PRMS controller = new PRMS();

        Profession.DataSource = controller.GetProfessions();
        Profession.DataTextField = "Description";
        Profession.DataValueField = "ProfessionID";
        Profession.Items.Insert(0, new ListItem("Select Profession...", "0"));
        Profession.DataBind();

        Skillset.DataSource = controller.GetSkillsets();
        Skillset.DataTextField = "Description";
        Skillset.DataValueField = "SkillsetID";
        Skillset.Items.Insert(0, new ListItem("Select Skillset...", "0"));
        Skillset.DataBind();

        Region.DataSource = controller.GetRegions();
        Region.DataTextField = "Description";
        Region.DataValueField = "RegionID";
        Region.Items.Insert(0, new ListItem("Select Region...", "0"));
        Region.DataBind();

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            User UpdateCandidate = new User();
            UpdateCandidate.UserID = CurrentUserID;
            UpdateCandidate.FirstName = FirstName.Text;
            UpdateCandidate.LastName = LastName.Text;
            UpdateCandidate.Phone = Phone.Text;
            if (Active.Checked)
            {
                UpdateCandidate.ActiveInactive = true;
            }
            else
            {
                UpdateCandidate.ActiveInactive = false;
            }


            PRMS controller = new PRMS();
            if (controller.UpdateProfile(UpdateCandidate))
            {
                UpdatedLabel.Text = "Your information has been updated";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your profile was updated successfully.')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating your profile. Please contact customer support for assistance if this issue persists.’)", true);
                UpdatedLabel.Text = "Sorry we could not update your information at this time.";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }


    protected void AddRegion_Click(object sender, EventArgs e)
    {
        List<int> regionsList;
        regionsList = (List<int>)Session["regions"];
        if (regionsList == null)
        {
            Session["regions"] = regionsList;
            regionsList = new List<int>();
        }

        if (!regionsList.Contains(int.Parse(Region.SelectedValue)) && int.Parse(Region.SelectedValue) != 0)
        {
            regionsList.Add(int.Parse(Region.SelectedValue));
            regionsLabel.Visible = true;
            regionsLabel.ForeColor = System.Drawing.Color.White;
            regionsLabel.Text = regionsLabel.Text + Region.SelectedItem + "<br/>";
        }


        Session["regions"] = regionsList;
    }

    protected void AddSkill_Click(object sender, EventArgs e)
    {
        List<int> skillsList;
        skillsList = (List<int>)Session["skills"];
        if (skillsList == null)
        {
            Session["skills"] = skillsList;
            skillsList = new List<int>();
        }

        if (!skillsList.Contains(int.Parse(Skillset.SelectedValue)) && int.Parse(Skillset.SelectedValue) != 0)
        {
            skillsList.Add(int.Parse(Skillset.SelectedValue));
            skillsetsLabel.Visible = true;
            skillLabel.Visible = true;
            skillsetsLabel.ForeColor = System.Drawing.Color.White;
            skillsetsLabel.Text = skillsetsLabel.Text + Skillset.SelectedItem + "<br/>";
        }

        Session["skills"] = skillsList;

    }
    protected void AddProfession_Click(object sender, EventArgs e)
    {
        List<int> professionList;
        professionList = (List<int>)Session["professions"];
        if (professionList == null)
        {
            Session["professions"] = professionList;
            professionList = new List<int>();
        }

        if (!professionList.Contains(int.Parse(Profession.SelectedValue)) && int.Parse(Profession.SelectedValue) != 0)
        {
            professionList.Add(int.Parse(Profession.SelectedValue));
            professionsLabel.Visible = true;
            professionsLabel.ForeColor = System.Drawing.Color.White;
            professionsLabel.Text = professionsLabel.Text + Profession.SelectedItem + "<br/>";
        }

        Session["professions"] = professionList;
    }
    protected void ViewCoverLetterButton_Click(object sender, EventArgs e)
    {
        try
        {
            string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + CurrentUserID + "/CoverLetter/" + CurrentUserCoverLetter;

            Response.Redirect(path);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘File does not exist.’)", true);
        }
    }

    protected void ViewResumeButton_Click(object sender, EventArgs e)
    {
        try
        {
            string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + CurrentUserID + "/Resume/" + CurrentUserResume;

            Response.Redirect(path);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘File does not exist.’)", true);
        }

    }


    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            User NewUser = new User();
            NewUser.UserID = CurrentUserID;
            NewUser.UserEmail = EmailTextBox.Text;
            PRMS UserController = new PRMS();
            if (UserController.ChangePassword(NewUser, OldPassword.Text, NewPassword.Text))
            {
                PasswordConfirmation.Text = "Your password has been updated.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password has updated successfully')", true);
            }
            else
            {
                PasswordConfirmation.Text = "Your old password is incorrect.";
            }
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ChangePasswordModal').modal('show')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with changing password. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }

    protected void ChangeCoverLetter_Click(object sender, EventArgs e)
    {
        try
        {
            if (CoverLetterUpload.HasFile)
            {

                string fileExtension = Path.GetExtension(CoverLetterUpload.PostedFile.FileName);

                if (fileExtension == ".pdf" || fileExtension == ".docx")
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/" + CurrentUserID + "/CoverLetter/"));

                    DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files/" + CurrentUserID + "/CoverLetter/"));
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo di in directory.GetDirectories())
                    {
                        di.Delete(true);
                    }

                    CoverLetterUpload.SaveAs(Server.MapPath("~/Files/" + CurrentUserID + "/" + "CoverLetter/" + CoverLetterUpload.FileName));

                    PRMS Controller = new PRMS();
                    if (Controller.UpdateCoverLetter(CurrentUserID, CoverLetterUpload.FileName))
                    {
                        CoverLetterMsg.Text = "Your cover letter has been updated.";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cover letter has been updated')", true);
                    }
                    else
                    {
                        CoverLetterMsg.Text = "Your cover letter could not be udpated.";
                    }

                }
                else
                {
                    CoverLetterMsg.Text = "Only .pdf and .docx cover letter files are accepted.";
                }
            }
            else
            {
                CoverLetterMsg.Text = "Please select a file to upload.";
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating the cover letter. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }

    protected void ChangeResume_Click(object sender, EventArgs e)
    {
        try
        {
            if (ResumeUpload.HasFile)
            {

                string fileExtension = Path.GetExtension(ResumeUpload.PostedFile.FileName);

                if (fileExtension == ".pdf" || fileExtension == ".docx")
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/" + CurrentUserID + "/Resume/"));

                    DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files/" + CurrentUserID + "/Resume/"));
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo di in directory.GetDirectories())
                    {
                        di.Delete(true);
                    }

                    ResumeUpload.SaveAs(Server.MapPath("~/Files/" + CurrentUserID + "/" + "Resume/" + ResumeUpload.FileName));
                    PRMS Controller = new PRMS();
                    if (Controller.UpdateResume(CurrentUserID, ResumeUpload.FileName))
                    {
                        ResumeMsg.Text = "Your resume has been updated.";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Resume has been updated')", true);
                    }
                    else
                    {
                        ResumeMsg.Text = "Your resume could not be udpated.";
                    }
                    ResumeMsg.Text = "Your resume has been updated.";
                }
                else
                {
                    ResumeMsg.Text = "Only .pdf and .docx resume files are accepted.";
                }
            }
            else
            {
                ResumeMsg.Text = "Please select a file to upload.";
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating the resume. Please contact customer support for assistance if this issue persists.’)", true);
        }

    }
    protected void ClearSkillsButton_Click(object sender, EventArgs e)
    {
        Session.Clear();
        skillsetsLabel.Text = "";
    }

    protected void ClearProfession_Click(object sender, EventArgs e)
    {
        Session.Clear();
        professionsLabel.Text = "";
    }
    protected void ClearRegion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        regionsLabel.Text = "";
    }
    private void PopulateSkillsTable()
    {
        PRMS RequestDirector;
        RequestDirector = new PRMS();

        List<Skillset> Skills = RequestDirector.GetUserSkills(CurrentUserID);
        

        skillsetsLabel.Text = "";
        foreach (Skillset s in Skills)
        {
            AddSkill_Click(s.SkillsetID, s.Description);
        }

    }

    private void PopulateProfessionTable()
    {
        PRMS RequestDirector;
        RequestDirector = new PRMS();

        List<Profession> Professions = RequestDirector.GetUserProfessions(CurrentUserID);

        professionsLabel.Text = "";
        foreach (Profession p in Professions)
        {
            AddProfession_Click(p.ProfessionID, p.Description);
        }

    }
    private void PopulateRegionTable()
    {
        PRMS RequestDirector;
        RequestDirector = new PRMS();

        List<Region> Regions = RequestDirector.GetUserRegions(CurrentUserID);

        regionsLabel.Text = "";
        foreach (Region r in Regions)
        {
            AddRegion_Click(r.RegionID, r.Description);
        }

    }
    protected void AddProfession_Click(int ProfessionID, string ProfessionText)
    {
        List<int> ProfessionsList;
        ProfessionsList = (List<int>)Session["professions"];
        if (ProfessionsList == null)
        {
            Session["professions"] = ProfessionsList;
            ProfessionsList = new List<int>();
        }

        ProfessionsList.Add(ProfessionID);
        professionsLabel.Visible = true;
        professionsLabel.Visible = true;
        professionsLabel.ForeColor = System.Drawing.Color.White;
        professionsLabel.Text = professionsLabel.Text + ProfessionText + "<br/> ";

        Session["professions"] = ProfessionsList;

    }
    protected void AddSkill_Click(int skillsetID, string skillText)
    {
        List<int> skillsList;
        skillsList = (List<int>)Session["skills"];
        if (skillsList == null)
        {
            Session["skills"] = skillsList;
            skillsList = new List<int>();
        }

        skillsList.Add(skillsetID);
        skillsetsLabel.Visible = true;
        skillsetsLabel.Visible = true;
        skillsetsLabel.ForeColor = System.Drawing.Color.White;
        skillsetsLabel.Text = skillsetsLabel.Text + skillText + "<br/> ";


        Session["skills"] = skillsList;

    }
    protected void AddRegion_Click(int regionID, string regionText)
    {
        List<int> regionList;
        regionList = (List<int>)Session["regions"];
        if (regionList == null)
        {
            Session["regions"] = regionList;
            regionList = new List<int>();
        }

        regionList.Add(regionID);
        regionsLabel.Visible = true;
        regionsLabel.Visible = true;
        regionsLabel.ForeColor = System.Drawing.Color.White;
        regionsLabel.Text = regionsLabel.Text + regionText + "<br/> ";

        Session["regions"] = regionList;

    }

    protected void EditCategories_Click(object sender, EventArgs e)
    {
        try
        {
            PRMS controller = new PRMS();
            controller.DeleteUserCategories(CurrentUserID);

            #region add professions
            List<int> professions = (List<int>)Session["professions"];
            foreach (int profession in professions)
            {
                controller.AddUserProfessions(CurrentUserID, profession);
            }

            #endregion

            #region add skills
            List<int> skills = (List<int>)Session["skills"];
            foreach (int skill in skills)
            {
                controller.AddUserSkills(CurrentUserID, skill);
            }

            #endregion
            #region add regions
            List<int> regions = (List<int>)Session["regions"];
            foreach (int region in regions)
            {
                controller.AddUserRegions(CurrentUserID, region);
            }
            #endregion
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Categories have been updated successfully.')", true);
        }
        catch {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with udpating categories. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }

    protected void ChangeEmail_Click(object sender, EventArgs e)
    {
        try
        {
            PRMS Controller = new PRMS();
            if(Controller.ChangeEmail(CurrentUserID, EmailTextBox.Text))
            {
                EmailConfirmation.Text = "Your email has been successfully changed. Please login again with your new email.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your email has been updated. Please login again with your new email.')", true);
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                EmailConfirmation.Text = "That email is registered under a different user.";
            }
        }
        catch (Exception)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating email. Please contact customer support for assistance if this issue persists.’)", true);

        }

    }
}