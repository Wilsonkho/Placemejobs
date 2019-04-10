using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateSkillSet : System.Web.UI.Page
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

        Skillset.DataSource = controller.GetSkillsets();
        Skillset.DataTextField = "Description";
        Skillset.DataValueField = "SkillsetID";
        Skillset.Items.Insert(0, new ListItem("Select Skillset...", "0"));
        Skillset.DataBind();

        Profession.DataSource = controller.GetProfessions();
        Profession.DataTextField = "Description";
        Profession.DataValueField = "ProfessionID";
        Profession.Items.Insert(0, new ListItem("Select Profession...", "0"));
        Profession.DataBind();
    }

    protected void SkillSetUpdateButton1_Click(object sender, EventArgs e)
    {
        try
        {
            bool confirmation = false;
            PRMS controller = new PRMS();
            int skillsetID = Convert.ToInt32(Skillset.Text);
            int ProfessionID = Convert.ToInt32(Profession.Text);
            //confirmation = controller.UpdateProfession(UpdateDescription.Text, professionID);
            //confirmation = controller.UpdateRegion(UpdateDescription.Text, skillsetID);
            //confirmation = controller.AddSkillSet(SkillSet.Text, professionID);
            confirmation = controller.UpdateSkillSet(UpdateDescription.Text, skillsetID, ProfessionID);
            if (confirmation)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Skillset was updated successfully.')", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating skillset. Please contact customer support for assistance if this issue persists.’)", true);
            throw;
        }
    }
}