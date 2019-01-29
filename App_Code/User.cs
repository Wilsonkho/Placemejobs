using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string _userEmail;
    private string _userPassword;
    private string _salt;
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string UserEmail
    {
        get
        {
            return this._userEmail;
        }
        set
        {
            this._userEmail = value;
        }
    }
    public string UserPassword
    {
        get
        {
            return this._userPassword;
        }
        set
        {
            this._userPassword = value;
        }
    }
    public string UserSalt
    {
        get
        {
            return this._salt;
        }
        set
        {
            this._salt = value;
        }
    }

}