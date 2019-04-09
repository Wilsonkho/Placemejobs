using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateRegion : System.Web.UI.Page
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

        Region.DataSource = controller.GetRegions();
        Region.DataTextField = "Description";
        Region.DataValueField = "RegionID";
        Region.Items.Insert(0, new ListItem("Select Region...", "0"));
        Region.DataBind();
    }

    protected void RegionUpdateButton1_Click(object sender, EventArgs e)
    {
        try
        {
            bool confirmation = false;
            PRMS controller = new PRMS();
            int regionID = Convert.ToInt32(Region.Text);
            //confirmation = controller.UpdateProfession(UpdateDescription.Text, professionID);
            confirmation = controller.UpdateRegion(UpdateDescription.Text, regionID);
            //confirmation = controller.AddSkillSet(SkillSet.Text, professionID);

            if (confirmation)
            {
                Confirmation.Text = "Region updated successfully.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Region was updated successfully')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating region. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }
}