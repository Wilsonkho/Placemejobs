using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web.Security;


public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void Reg_Click(object sender, EventArgs e)
    {
        User NewUser = new User();
        NewUser.UserEmail = UserEmail.Text;
        NewUser.UserPassword = UserPass.Text;

        Controller Control = new Controller();
        if (Control.AddUser(NewUser))
        {
            Confirmation.Text = "User account created. ";
            Login.Visible = true;


        }
        else
        {
            Confirmation.Text = "Failed to register user";
        }
    }
}