using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string _firstName;
    private string _lastName;
    private string _userEmail;
    private string _userPassword;
    private string _salt;
  
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string FirstName
    {
        get { return this._firstName; }
        set { this._firstName = value; }
    }
    public string LastName
    {
        get { return this._lastName; }
        set { this._lastName = value; }
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