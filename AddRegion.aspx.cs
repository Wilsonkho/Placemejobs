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
        bool confirmation = false;
        PRMS controller = new PRMS();

        confirmation = controller.AddRegion(Region.Text);

        if (confirmation)
        {
            Confirmation.Text = "Region added successfully.";
        }
        else
        {
            Confirmation.Text = "Error has occurred.";
        }
    }
}