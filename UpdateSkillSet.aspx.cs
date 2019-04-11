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
        Skillset.Items.Clear();
        PRMS controller = new PRMS();

        Skillset.DataSource = controller.GetSkillsets();
        Skillset.DataTextField = "Description";
        Skillset.DataValueField = "SkillsetID";
        Skillset.Items.Insert(0, new ListItem("Select Skillset...", "0"));
        Skillset.DataBind();
    }

    protected void SkillSetUpdateButton1_Click(object sender, EventArgs e)
    {
        try
        {
            bool confirmation = false;
            PRMS controller = new PRMS();
            int skillsetID = Convert.ToInt32(Skillset.Text);
            int ProfessionID = Convert.ToInt32(Skillset.Text);
            confirmation = controller.UpdateSkillSet(UpdateSkillset.Text, skillsetID, ProfessionID);
            if (confirmation)
            {
                ClearForm();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Skillset was updated successfully.')", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating skillset. Please contact customer support for assistance if this issue persists.’)", true);
            throw;
        }
    }

    private void ClearForm()
    {
        Skillset.SelectedValue = "0";
        UpdateSkillset.Text = "";
        BindDropDowns();
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        PRMS controller = new PRMS();
        bool Success;
        Success = controller.DeleteSkillset(Skillset.SelectedValue);
        if (Success)
        {
            ClearForm();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Skillset Deleted')", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Skillset not Deleted')", true);
        }
    }
}