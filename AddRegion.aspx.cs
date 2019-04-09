using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddRegion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddRegionButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool confirmation = false;
            PRMS controller = new PRMS();

            confirmation = controller.AddRegion(Region.Text);

            if (confirmation)
            {
                Confirmation.Text = "Region added successfully.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Region was added successfully')", true);
            }
            else
            {
                Confirmation.Text = "Error has occurred.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred with adding a region. Please contact customer support for assistance if this issue persists.’)", true);
            }
            Region.Text = "";
        }
        catch (Exception)
        {

            throw;
        }
    }
}