﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class RegisterAccount : System.Web.UI.Page
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

            ProfessionLabel.Text = "";
            skillLabel.Text = "";
            regionLabel.Text = "";
            professionsLabel.Text = "";
            skillsetsLabel.Text = "";
            regionsLabel.Text = "";
        }

        Password.Attributes.Add("value", HidePassword.Value);
        Password.Attributes.Add("onblur", "CapturePassword()");
        ConfirmPassword.Attributes.Add("value", HideConfirmPassword.Value);
        ConfirmPassword.Attributes.Add("onblur", "CaptureConfirmPassword()");
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
                newCandidate.UserPassword = Password.Text;

                PRMS controller = new PRMS();



                #region add user
                success = controller.AddAccount(newCandidate);

                if (success)
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
                    #region send email
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        string email = EmailTextBox.Text;
                        string firstName = FirstName.Text;

                        MailAddress from = new MailAddress("automatedreplyfromplacemejob@gmail.com");
                        MailAddress to = new MailAddress(email);
                        MailMessage message = new MailMessage(from, to);

                        message.Subject = "Placemejob Account Registration";

                        string note = "Dear " + firstName + ",<br /><br />";
                        note += "Thank you for your application on Placemejob. We shall check your profile with relevant openings and get back to you.";

                        message.Body = note;
                        message.BodyEncoding = System.Text.Encoding.UTF8;
                        message.IsBodyHtml = true;

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                        client.UseDefaultCredentials = false;
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("automatedreplyfromplacemejob@gmail.com", "mejob986");

                        try
                        {
                            client.Send(message);
                        }
                        catch
                        {
                            Results.Text = "Error occurred with sending email.";
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have successfully registered an account.');window.location ='RegisterAccount.aspx';", true);
                    #endregion
                }
                else //if(success)
                {
                    Results.Text = "An error has occurred with your account registration. Please try again. If this issue persists, please contact customer support for assistance.";
                }
                #endregion
            }
            else //if(dropdownsChecked)
            {
                Results.Text = "You must select at least one profession, skill, and region preference.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Must have at least one profession, skill, and region added.’)", true);
            }
    }
        catch (Exception ex)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(''Error occurred with registering account. Please contact customer support for assistance if this issue persists.'')", true);
            Results.Text = ex.ToString();
        }


    }

    protected void Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
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
            regionLabel.Text = "Professions:";
            regionsLabel.Visible = true;
            regionsLabel.ForeColor = System.Drawing.Color.White;
            regionsLabel.Text = regionsLabel.Text + " " + Region.SelectedItem + "<br/>";
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
            skillLabel.Text = "Skills:";
            skillsetsLabel.Visible = true;
            skillsetsLabel.ForeColor = System.Drawing.Color.White;
            skillsetsLabel.Text = skillsetsLabel.Text  + Skillset.SelectedItem + "<br/> ";
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
            ProfessionLabel.Text = "Professions:";
            professionsLabel.Visible = true;
            professionsLabel.ForeColor = System.Drawing.Color.White;
            professionsLabel.Text = professionsLabel.Text + " " + Profession.SelectedItem + "<br/>";
        }

        Session["professions"] = professionList;
    }

    //protected void SendMailBASIC()
    //{
    //    // Gmail Address from where you send the mail
    //    var fromAddress = "no.reply.company@gmail.com";
    //    // any address where the email will be sending
    //    var toAddress = Email.Text.ToString();
    //    //Password of your gmail address
    //    const string fromPassword = "password";
    //    // Passing the values and make a email formate to display
    //    string subject = "Customer Account Confirmation";
    //    string body = "Hi " + Name.Text.ToString() + "\n\n";
    //    body += "Welcome to blah\nI Wanted to let you know that your account for blah.com is now active. " + "\n\n";
    //    body += "The next time you log in we will ask you to add more details to your account.  " + "\n";
    //    body += "\nCheers, \n\nThe Baist team";
    //    // smtp settings
    //    var smtp = new System.Net.Mail.SmtpClient();
    //    {
    //        smtp.Host = "smtp.gmail.com";
    //        smtp.Port = 587;
    //        smtp.EnableSsl = true;
    //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    //        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
    //        smtp.Timeout = 20000;
    //    }
    //    // Passing values to smtp object
    //    smtp.Send(fromAddress, toAddress, subject, body);
    //}
}