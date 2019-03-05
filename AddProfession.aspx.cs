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


    }

    protected void AddProfessionButton_Click(object sender, EventArgs e)
    {
        bool confirmation = false;
        PRMS controller = new PRMS();

        confirmation = controller.AddProfession(Profession.Text);

        if (confirmation)
        {
            Confirmation.Text = "Profession added successfully.";
        }
        else
        {
            Confirmation.Text = "Error has occurred.";
        }
    }
}