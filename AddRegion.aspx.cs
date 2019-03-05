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
        AdministratorManager administrator = new AdministratorManager();
        administrator.AddRegion(Region.Text);

        PRMS Control = new PRMS();
    }

    protected void AddRegionButton_Click(object sender, EventArgs e)
    {

        Label1.Text = "Region added successfully";
    }
}