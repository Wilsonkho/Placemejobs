﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.IO;

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
        User CurrentUser = new User();
        CustomPrincipal cp = HttpContext.Current.User as CustomPrincipal;
        PRMS UserController = new PRMS();
        CurrentUser = UserController.ViewProfile(cp.Identity.Name);
        CurrentUserID = CurrentUser.UserID;
        CurrentUserCoverLetter = CurrentUser.CoverLetter;
        CurrentUserResume = CurrentUser.Resume;

        Welcome.Text = "Hello " + CurrentUser.FirstName + " " + CurrentUser.LastName + "!";

  
        if (!IsPostBack)
        {
            FirstName.Text = CurrentUser.FirstName;
            LastName.Text = CurrentUser.LastName;
            Phone.Text = CurrentUser.Phone;
            EmailTextBox.Text = CurrentUser.UserEmail;
            //Password.Text = CurrentUser.UserPassword;
            //ConfirmPassword.Text = CurrentUser.UserPassword;
            if (CurrentUser.ActiveInactive)
            {
                Active.Checked = true;
            }
            else
            {
                Active.Checked = false;
            }
            BindDropDowns();
            professionsLabel.Visible = false;
            skillsetsLabel.Visible = false;
            regionsLabel.Visible = false;

            professions = new List<Profession>();
            skillsets = new List<Skillset>();
            regions = new List<Region>();

            Session["professions"] = null;
            Session["skills"] = null;
            Session["regions"] = null;
            Session["FileUpload1"] = null;
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
            UpdatedLabel.Text = "Your information has been update";
        }else
        {
            UpdatedLabel.Text = "Sorry we could not update your information at this time.";
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
            regionsLabel.ForeColor = System.Drawing.Color.Blue;
            regionsLabel.Text = regionsLabel.Text + " " + Region.SelectedItem + ",";
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
            skillsetsLabel.ForeColor = System.Drawing.Color.Blue;
            skillsetsLabel.Text = skillsetsLabel.Text + " " + Skillset.SelectedItem + ",";
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
            professionsLabel.ForeColor = System.Drawing.Color.Blue;
            professionsLabel.Text = professionsLabel.Text + " " + Profession.SelectedItem + ",";
        }

        Session["professions"] = professionList;
    }
    protected void ViewCoverLetterButton_Click(object sender, EventArgs e)
    {
        string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + CurrentUserID + "/CoverLetter/" + CurrentUserCoverLetter;

        Response.Redirect(path);
    }

    protected void ViewResumeButton_Click(object sender, EventArgs e)
    {
        string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + CurrentUserID + "/Resume/" + CurrentUserResume;

        Response.Redirect(path);
    }


    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        User NewUser = new User();
        NewUser.UserID = CurrentUserID;
        NewUser.UserEmail = EmailTextBox.Text;
        PRMS UserController = new PRMS();
        if (UserController.ChangePassword(NewUser, OldPassword.Text, NewPassword.Text))
        {
            PasswordConfirmation.Text = "Your password has been updated.";

        }
        else
        {
            PasswordConfirmation.Text = "Your old password is incorrect.";
        }
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ChangePasswordModal').modal('show')", true);
    }



    protected void ChangeCoverLetter_Click(object sender, EventArgs e)
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
        }else
        {
            CoverLetterMsg.Text = "Please select a file to upload.";
        }
    }

    protected void ChangeResume_Click(object sender, EventArgs e)
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
        }else
        {
            ResumeMsg.Text = "Please select a file to upload.";
        }
    }
    protected void ClearSkillsButton_Click(object sender, EventArgs e)
    {
        Session.Clear();
        skillsetsLabel.Text = "";
    }
    private void PopulateJobPostingTable(int jobID)
    {
        PRMS RequestDirector;
        RequestDirector = new PRMS();

        List<Skillset> Skills = RequestDirector.GetUserSkills(CurrentUserID);
        
        //Someting for skillsets
        skillsetsLabel.Text = "";
        foreach (Skillset s in Skills)
        {
            AddSkill_Click(skill.SkillsetID, skill.Description);
        }


        //Profession.SelectedValue = jobPosting.ProfessionID.ToString();
        //Region.SelectedValue = jobPosting.RegionID.ToString();


    }
}