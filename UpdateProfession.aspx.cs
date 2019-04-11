using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateProfession : System.Web.UI.Page
{
    List<Profession> professions;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDowns();
        } 
    }
    protected void BindDropDowns()
    {
        Profession.Items.Clear();
        PRMS controller = new PRMS();

        Profession.DataSource = controller.GetProfessions();
        Profession.DataTextField = "Description";
        Profession.DataValueField = "ProfessionID";
        Profession.Items.Insert(0, new ListItem("Select Profession...", "0"));
        Profession.DataBind();
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        List<int> list;
        bool dropdownsChecked = true;
        list = (List<int>)Session["professions"];
        if (list == null)
        {
            dropdownsChecked = false;
        }
    }

    protected void ProfessionUpdateButton1_Click(object sender, EventArgs e)
    {
        try
        {
            bool confirmation = false;
            PRMS controller = new PRMS();
            int professionID = Convert.ToInt32(Profession.Text);
            confirmation = controller.UpdateProfession(UpdateDescription.Text, professionID);

            if (confirmation)
            {
                ClearForm();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Profession was updated successfully.')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating profession. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }

    private void ClearForm()
    {
        Profession.SelectedValue = "0";
        UpdateDescription.Text = "";
        BindDropDowns();
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        PRMS controller = new PRMS();
        bool Success;
        Success = controller.DeleteProfession(Profession.SelectedValue);
        if (Success)
        {
            ClearForm();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Profession Deleted')", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Profession not Deleted')", true);
        }
    }
}