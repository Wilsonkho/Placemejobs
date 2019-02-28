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
        }

        
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        bool success = false;
        User newCandidate = new User();
        newCandidate.UserEmail = EmailTextBox.Text;
        newCandidate.FirstName = FirstName.Text;
        newCandidate.LastName = LastName.Text;
        newCandidate.Resume = ResumeUpload.PostedFile.FileName;
        newCandidate.CoverLetter = CoverLetterUpload.PostedFile.FileName;

        PRMS controller = new PRMS();
        success = controller.AddCandidate(newCandidate);


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
        Profession newProfession = new Profession();

        newProfession.ProfessionID = int.Parse(Profession.SelectedValue);
        newProfession.Description = Profession.SelectedItem.ToString();

        professions.Add(newProfession);

        professionsLabel.Visible = true;
        professionsLabel.Text = professionsLabel.Text + " " + Profession.SelectedItem + ",";

        
    }

    protected void AddSkill_Click(object sender, EventArgs e)
    {
        skillsetsLabel.Visible = true;
        skillsetsLabel.Text = skillsetsLabel.Text + " " + Skillset.SelectedItem + ",";
    }

    protected void AddRegion_Click(object sender, EventArgs e)
    {
        regionsLabel.Visible = true;
        regionsLabel.Text = regionsLabel.Text + " " + Region.SelectedItem + ",";
    }
}