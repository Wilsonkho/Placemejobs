﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModifyJobPosting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDropDowns();
            
        }
        ModifyPostingTable.Visible = false;
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
            skillsetsLabel.ForeColor = System.Drawing.Color.Blue;
            skillsetsLabel.Text = skillsetsLabel.Text + " " + Skillset.SelectedItem + ",";
        }

        Session["skills"] = skillsList;

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        PRMS controller = new PRMS();


        List<int> skillsList;
        skillsList = (List<int>)Session["skills"];

        JobPosting newPosting = new JobPosting();

        newPosting.Description = JobPostingDescription.Text;
        newPosting.CompanyName = CompanyName.Text;
        newPosting.RegionID = int.Parse(Region.Text);
        newPosting.ProfessionID = int.Parse(Profession.Text);
        newPosting.Date = DateTime.Parse(Date.Text);
        newPosting.EmployerPhone = CompanyPhone.Text;

        try
        {
            int newJobID;
            newJobID = controller.AddJobPosting(newPosting);

            foreach (int skill in skillsList)
            {
                controller.AddJobSkillSets(newJobID, skill);
            }
            ClearForm();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Job Posting Inserted Successfully')", true);
        }
        catch (Exception ex)
        {
            Confirmation.Text = "the following error has occurred: " + ex;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Job Posting Insert Failed')", true);
        }

    }

    protected void ClearForm()
    {
        JobPostingDescription.Text = "";
        CompanyName.Text = "";
        Region.SelectedValue = "0";
        Profession.SelectedValue = "0";
        Skillset.SelectedValue = "0";
        CompanyPhone.Text = "";
        Date.Text = "";
        skillsetsLabel.Visible = false;
        skillsetsLabel.Text = "Skills:";
        Session.Clear();

    }

    protected void PostingDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PostingDropDown.SelectedIndex != 0)
        {
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
        Profession.SelectedValue = jobPosting.ProfessionID.ToString();
        Region.SelectedValue = jobPosting.RegionID.ToString();


    }
}