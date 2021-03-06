﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddJobPosting : System.Web.UI.Page
{
    List<Skillset> skillsets;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDowns();

            skillsetsLabel.Visible = false;
            skillsets = new List<Skillset>();
            
            Session["skills"] = null;
            
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
            skillsetsLabel.ForeColor = System.Drawing.Color.White;
            skillsetsLabel.Text = skillsetsLabel.Text + " " + Skillset.SelectedItem + "<br>";
        }

        Session["skills"] = skillsList;

    }


    protected void Submit_Click(object sender, EventArgs e)
    {
        try
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

            int newJobID;
            newJobID = controller.AddJobPosting(newPosting);

            foreach (int skill in skillsList)
            {
                controller.AddJobSkillSets(newJobID, skill);
            }
            ClearForm();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Job posting added successfully.')", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occurred while with adding a job posting. Please contact customer support for assistance if this issue persists.')", true);
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
        skillsetsLabel.Text = "";
        Session.Clear();

    }

    protected void ClearSkillsButton_Click(object sender, EventArgs e)
    {
        Session.Clear();
        skillsetsLabel.Text = "";
    }

}