using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterCandidate : System.Web.UI.Page
{
    List<Profession> professions;
    List<Skillset> skillsets;
    List<Region> regions;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
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

    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            List<int> list;
            bool dropdownsChecked = true;
            list = (List<int>)Session["professions"];
            if (list == null)
            {
                dropdownsChecked = false;
            }
            list = (List<int>)Session["skills"];
            if (list == null)
            {
                dropdownsChecked = false;
            }
            list = (List<int>)Session["regions"];
            if (list == null)
            {
                dropdownsChecked = false;
            }

            if (dropdownsChecked)
            {

                bool success = false;
                User newCandidate = new User();
                newCandidate.UserEmail = EmailTextBox.Text;
                newCandidate.FirstName = FirstName.Text;
                newCandidate.LastName = LastName.Text;
                newCandidate.Phone = Phone.Text;
                newCandidate.Resume = (ResumeUpload.PostedFile.FileName == "") ? null : ResumeUpload.PostedFile.FileName;
                newCandidate.CoverLetter = (CoverLetterUpload.PostedFile.FileName == "") ? null : CoverLetterUpload.PostedFile.FileName;

                PRMS controller = new PRMS();

                #region add user
                success = controller.AddCandidate(newCandidate);

                if (success)
                {
                    try
                    {
                        int userID;
                        userID = controller.GetUserIDByEmail(EmailTextBox.Text);

                        if (ResumeUpload.HasFile)
                        {

                            string fileExtension = Path.GetExtension(ResumeUpload.PostedFile.FileName);

                            if (fileExtension == ".pdf" || fileExtension == ".docx")
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Files/" + userID + "/Resume/"));

                                DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files/" + userID + "/Resume/"));
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    file.Delete();
                                }
                                foreach (DirectoryInfo di in directory.GetDirectories())
                                {
                                    di.Delete(true);
                                }

                                ResumeUpload.SaveAs(Server.MapPath("~/Files/" + userID + "/" + "Resume/" + ResumeUpload.FileName));
                            }
                            else
                            {
                                Msg.Text = "Only .pdf and .docx resume files are accepted.";
                            }
                        }
                        if (CoverLetterUpload.HasFile)
                        {

                            string fileExtension = Path.GetExtension(CoverLetterUpload.PostedFile.FileName);

                            if (fileExtension == ".pdf" || fileExtension == ".docx")
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Files/" + userID + "/CoverLetter/"));

                                DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files/" + userID + "/CoverLetter/"));
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    file.Delete();
                                }
                                foreach (DirectoryInfo di in directory.GetDirectories())
                                {
                                    di.Delete(true);
                                }

                                CoverLetterUpload.SaveAs(Server.MapPath("~/Files/" + userID + "/" + "CoverLetter/" + CoverLetterUpload.FileName));
                            }
                            else
                            {
                                Msg.Text = "Only .pdf and .docx cover letter files are accepted.";
                            }
                        }
                        //Set color to green
                        //Results.ForeColor = System.Drawing.Color.Green;
                        //Results.Text = "Candidate was added";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate was added Successfully')", true);
                        #region add professions
                        int newUserID;
                        newUserID = controller.GetUserIDByEmail(EmailTextBox.Text);

                        List<int> professions = (List<int>)Session["professions"];
                        foreach (int profession in professions)
                        {
                            controller.AddUserProfessions(newUserID, profession);
                        }

                        #endregion

                        #region add skills
                        List<int> skills = (List<int>)Session["skills"];
                        foreach (int skill in skills)
                        {
                            controller.AddUserSkills(newUserID, skill);
                        }

                        #endregion
                        #region add regions
                        List<int> regions = (List<int>)Session["regions"];
                        foreach (int region in regions)
                        {
                            controller.AddUserRegions(newUserID, region);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate was not registered.')", true);
                        Results.Text = ex.ToString();
                    }
                }
                else //if(success)
                {
                    Results.Text = "Candidate was not added";
                }
                #endregion

            }
            else //if(dropdownsChecked)
            {
                Results.Text = "Candidate must have at least one profession, skill, and region added.";
                DropDownValidators.IsValid = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with registering the candidate. Please contact customer support for assistance if this issue persists.’)", true);
            }
        }
        catch (Exception)
        {

            throw;
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

    protected void AddSkill_Click(object sender, EventArgs e)
    {
        List<int> skillsList;
        skillsList = (List<int>)Session["skills"];
         if (skillsList == null)
        {
            Session["skills"] = skillsList;
            skillsList = new List<int>();
        }

         if(!skillsList.Contains(int.Parse(Skillset.SelectedValue)) && int.Parse(Skillset.SelectedValue) != 0)
        {
            skillsList.Add(int.Parse(Skillset.SelectedValue));
            skillsetsLabel.Visible = true;
            skillsetsLabel.ForeColor = System.Drawing.Color.Blue;
            skillsetsLabel.Text = skillsetsLabel.Text + " " + Skillset.SelectedItem + ",";
        }
        
        Session["skills"] = skillsList;

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

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

}