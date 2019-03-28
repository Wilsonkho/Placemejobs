using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModifyJobPosting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindDropDowns();
             ModifyPostingTable.Visible = false;
        }
       
    }

    protected void BindDropDowns()
    {
        PRMS controller = new PRMS();

        PostingDropDown.DataSource = controller.GetAllJobPostings();
        PostingDropDown.DataTextField = "Description";
        PostingDropDown.DataValueField = "JobPostingID";
        PostingDropDown.Items.Insert(0, new ListItem("Select Job Posting...", "0"));
        PostingDropDown.DataBind();

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
            skillsetsLabel.Text = skillsetsLabel.Text  + Skillset.SelectedItem + "<br/>";
        }

        Session["skills"] = skillsList;

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
        skillLabel.Visible = true;
        skillsetsLabel.ForeColor = System.Drawing.Color.White;
        skillsetsLabel.Text = skillsetsLabel.Text + skillText + "<br/> ";
        

        Session["skills"] = skillsList;

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        PRMS controller = new PRMS();


        List<int> skillsList;
        skillsList = (List<int>)Session["skills"];

        JobPosting jobPosting = new JobPosting();

        jobPosting.JobPostingID = int.Parse(PostingDropDown.SelectedValue);
        jobPosting.Description = JobPostingDescription.Text;
        jobPosting.CompanyName = CompanyName.Text;
        jobPosting.RegionID = int.Parse(Region.Text);
        jobPosting.ProfessionID = int.Parse(Profession.Text);
        jobPosting.Date = DateTime.Parse(Date.Text);
        jobPosting.EmployerPhone = CompanyPhone.Text;

        try
        {
            bool success;
            success = controller.UpdateJobPosting(jobPosting);
            if (success)
            {
                foreach (int skill in skillsList)
                {
                    controller.AddJobSkillSets(jobPosting.JobPostingID, skill);
                }
                ClearForm();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Job Posting Updated Successfully')", true);
            }
        }
        catch (Exception ex)
        {
            Confirmation.Text = "the following error has occurred: " + ex;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Job Posting Update Failed')", true);
        }

    }

    protected void ClearForm()
    {
        Session.Clear();
        skillsetsLabel.Text = "";
        PostingDropDown.SelectedValue = "0";
        JobPostingDescription.Text = "";
        CompanyName.Text = "";
        Region.SelectedValue = "0";
        Profession.SelectedValue = "0";
        Skillset.SelectedValue = "0";
        CompanyPhone.Text = "";
        Date.Text = "";
        SelectJobTable.Visible = false;
        

    }

    protected void PostingDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PostingDropDown.SelectedIndex != 0)
        {
            Skillset.SelectedIndex = 0;
            ModifyPostingTable.Visible = true;
            PopulateJobPostingTable();
        }
    }

    private void PopulateJobPostingTable()
    {
        PRMS RequestDirector;
        RequestDirector = new PRMS();

        JobPosting jobPosting;
        jobPosting = RequestDirector.GetJobPosting(int.Parse(PostingDropDown.SelectedValue));
        JobPostingDescription.Text = jobPosting.Description;
        CompanyName.Text = jobPosting.CompanyName;
        CompanyPhone.Text = jobPosting.EmployerPhone;
        Date.Text = jobPosting.Date.ToString("yyyy-MM-dd");
        //Someting for skillsets
        Session.Clear();
        skillsetsLabel.Text = "";
        foreach(Skillset skill in jobPosting.Skillsets)
        {
            AddSkill_Click(skill.SkillsetID, skill.Description);
        }


        Profession.SelectedValue = jobPosting.ProfessionID.ToString();
        Region.SelectedValue = jobPosting.RegionID.ToString();


    }

    protected void ClearSkillsButton_Click(object sender, EventArgs e)
    {
        Session.Clear();
        skillsetsLabel.Text = "";
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        PRMS controller = new PRMS();
        bool Success;
        Success = controller.DeleteJobPosting(PostingDropDown.SelectedValue);
        if(Success)
        {
            ClearForm();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Job Posting Deleted')", true);
            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Job Posting not Deleted')", true);
        }
        
    }
}