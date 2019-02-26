using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

//https://www.c-sharpcorner.com/article/display-data-in-Asp-Net-using-jquery-datatables-plugin/ or user Ploty JSON 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class JobMatchService : System.Web.Services.WebService
{
    [WebMethod]
    public void GetMatches()
    {
        List<User> MatchedUsers = new List<User>();
        //Create the Connection Object
        SqlConnection Con;
        Con = new SqlConnection();
        Con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand Com;
        Com = new SqlCommand();
        Com.CommandType = CommandType.StoredProcedure;
        Com.Connection = Con;
        Com.CommandText = "";
    }

}
