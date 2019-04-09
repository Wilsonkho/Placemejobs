using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddSkillSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindDropDowns();
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
    }
    protected void SkillSetAddButton1_Click(object sender, EventArgs e)
    {
        bool confirmation = false;
        PRMS controller = new PRMS();

        int ProfessionID = Convert.ToInt32(Profession.Text);
        //confirmation = controller.UpdateSkillSet(ProfessionID,);
        confirmation = controller.AddSkillSet(SkillsetDescription.Text, ProfessionID);

        if (confirmation)
        {
            Confirmation.Text = "Skillset added successfully.";
        }
        else
        {
            Confirmation.Text = "Error has occurred.";
        }
    }

}

