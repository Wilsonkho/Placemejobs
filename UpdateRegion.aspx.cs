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
        Region.Items.Clear();
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
            confirmation = controller.UpdateRegion(RegionUpdated.Text, regionID);

            if (confirmation)
            {
                ClearForm();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Region was updated successfully.')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Region was not updated.')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with updating region. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }

    private void ClearForm()
    {
        Region.SelectedValue = "0";
        RegionUpdated.Text = "";
        BindDropDowns();
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        PRMS controller = new PRMS();
        bool Success;
        Success = controller.DeleteRegion(Region.SelectedValue);
        if (Success)
        {
            ClearForm();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Region Deleted')", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Region not Deleted')", true);
        }
    }
}