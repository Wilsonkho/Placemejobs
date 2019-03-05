using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProfession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdministratorManager administrator = new AdministratorManager();
        //administrator.AddRegion(Profession.Text);
        administrator.AddProfession(Profession.Text);

        PRMS Control = new PRMS();
    }

    protected void AddProfessionButton_Click(object sender, EventArgs e)
    {
        Label1.Text = "Profession added successfully";
    }
}