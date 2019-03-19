using System;
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
            skillsetsLabel.ForeColor = System.Drawing.Color.Blue;
            skillsetsLabel.Text = skillsetsLabel.Text + " " + Skillset.SelectedItem + ",";
        }

        Session["skills"] = skillsList;


        foreach (int skill in skillsList)
        {
            TableRow newRow = new TableRow();

            TableCell descriptionCell = new TableCell();
            descriptionCell.Text = skill.ToString();
            newRow.Cells.Add(descriptionCell);
            AddPostingTable.Rows.Add(newRow);
        }
    }

}