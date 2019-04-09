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

            //confirmation = controller.AddSkillSet(SkillSet.Text, professionID);

            if (confirmation)
            {
                Confirmation.Text = "Profession updated successfully.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Profession was updated successfully')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating profession. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }
}