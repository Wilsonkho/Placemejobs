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
        }


    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        bool success = false;
        User newCandidate = new User();
        newCandidate.UserEmail = (EmailTextBox.Text == "") ? null : EmailTextBox.Text;
        newCandidate.FirstName = FirstName.Text;
        newCandidate.LastName = LastName.Text;
        newCandidate.Phone = Phone.Text;
        newCandidate.Resume = (ResumeUpload.PostedFile.FileName == "") ? null : ResumeUpload.PostedFile.FileName;
        newCandidate.CoverLetter = (CoverLetterUpload.PostedFile.FileName == "") ? null : ResumeUpload.PostedFile.FileName;

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
            professionsLabel.Text = professionsLabel.Text + " " + Profession.SelectedItem + ",";
        }

        Session["professions"] = professionList;


        foreach (int profession in professionList)
        {
            TableRow newRow = new TableRow();

            TableCell descriptionCell = new TableCell();
            descriptionCell.Text = profession.ToString();
            newRow.Cells.Add(descriptionCell);
            RegisterCandidateTable.Rows.Add(newRow);
        }
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
            skillsetsLabel.Text = skillsetsLabel.Text + " " + Skillset.SelectedItem + ",";
        }
        
        Session["skills"] = skillsList;


        foreach (int skill in skillsList)
        {
            TableRow newRow = new TableRow();           

            TableCell descriptionCell = new TableCell();
            descriptionCell.Text = skill.ToString();
            newRow.Cells.Add(descriptionCell);
            RegisterCandidateTable.Rows.Add(newRow);
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
            regionsLabel.Text = regionsLabel.Text + " " + Region.SelectedItem + ",";
        }


        Session["regions"] = regionsList;


        foreach (int region in regionsList)
        {
            TableRow newRow = new TableRow();

            TableCell descriptionCell = new TableCell();
            descriptionCell.Text = region.ToString();
            newRow.Cells.Add(descriptionCell);
            RegisterCandidateTable.Rows.Add(newRow);
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}