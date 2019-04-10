using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Reg_Click(object sender, EventArgs e)
    {
        try
        {
            User NewUser = new User();
            NewUser.UserEmail = UserEmail.Text;
            NewUser.UserPassword = UserPass.Text;
            NewUser.FirstName = FirstNameBox.Text;
            NewUser.LastName = LastNameBox.Text;

            PRMS Control = new PRMS();

            if (Control.AddUser(NewUser))
            {
                Confirmation.Text = "User account created. ";
                Login.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Account registered successfully.')", true);
            }
            else
            {
                Confirmation.Text = "Failed to register user";
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occurred while with registering account. Please contact customer support for assistance if this issue persists.')", true);
            throw;
        }

    }
}