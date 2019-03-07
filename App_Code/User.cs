using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    //private string _firstName;
    //private string _lastName;
    //private string _userEmail;
    //private string _userPassword;
    //private string _salt;

    public int UserID { get; set; }
    public string UserEmail { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Resume { get; set; }
    public string CoverLetter { get; set; }
    public string UserPassword { get; set; }
    public string UserSalt { get; set; }
    public bool ActiveInactive { get; set; }
    public string Roles { get; set; }
    public string Profession { get; set; }
    public string Region { get; set; }
    public string Skillset { get; set; }

    //public User()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    //public string FirstName
    //{
    //    get { return this._firstName; }
    //    set { this._firstName = value; }
    //}
    //public string LastName
    //{
    //    get { return this._lastName; }
    //    set { this._lastName = value; }
    //}
    //public string UserEmail
    //{
    //    get
    //    {
    //        return this._userEmail;
    //    }
    //    set
    //    {
    //        this._userEmail = value;
    //    }
    //}
    //public string UserPassword
    //{
    //    get
    //    {
    //        return this._userPassword;
    //    }
    //    set
    //    {
    //        this._userPassword = value;
    //    }
    //}
    //public string UserSalt
    //{
    //    get
    //    {
    //        return this._salt;
    //    }
    //    set
    //    {
    //        this._salt = value;
    //    }
    //}

}