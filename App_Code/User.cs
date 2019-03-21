using System;
using System.Collections.Generic;
using System.Web;

public class User
{

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
    //Temperary placeholder for the job status if Candidate is assigned 
    public string JobStatus { get; set; }
    //Temperary placeholder for the date of job status change
    public string StatusDate { get; set; }


}