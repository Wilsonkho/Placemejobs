using System;
using System.Collections.Generic;
using System.Web;


public class Controller
{

    public bool GetUser(User LoginUser)
    {
        bool Confirmation;
        User ReturnUser = new User();
        Manager Get = new Manager();
        Confirmation = Get.GetUser(LoginUser);
        return Confirmation;

    }
    public Boolean AddUser(User NewUser)
    {
        bool confirmation;
        Manager Add = new Manager();
        confirmation = Add.AddUser(NewUser);
        return confirmation;
    }
    public String GetRoles(User LoginUser)
    {
        Manager Roles = new Manager();
        return Roles.GetRoles(LoginUser);
    }

   
}