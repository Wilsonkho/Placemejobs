using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;

//https://www.c-sharpcorner.com/article/display-data-in-Asp-Net-using-jquery-datatables-plugin/ or user Ploty JSON 

[WebService(Namespace = "PlacemejobsWebService")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    [WebMethod]
    public void GetQualifiedCandidates(int JobPostingID)
    {
        
        List<User> AllQualifiedCandidates = new List<User>();
   
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand GetQualifiedCandidatesCommand;
        GetQualifiedCandidatesCommand = new SqlCommand("");
        GetQualifiedCandidatesCommand.CommandType = CommandType.StoredProcedure;
        GetQualifiedCandidatesCommand.Connection = con;
        GetQualifiedCandidatesCommand.CommandText = "JobMatch";

        
        SqlParameter JobPostingIdParameter;

        JobPostingIdParameter = new SqlParameter();

        JobPostingIdParameter.ParameterName = "@JobID";

        JobPostingIdParameter.SqlDbType = SqlDbType.Int;
        JobPostingIdParameter.Direction = ParameterDirection.Input;

        JobPostingIdParameter.Value = JobPostingID;
        GetQualifiedCandidatesCommand.Parameters.Add(JobPostingIdParameter);

        con.Open();

        SqlDataReader QualifiedCandidatesReader;
        QualifiedCandidatesReader = GetQualifiedCandidatesCommand.ExecuteReader();
        
        while (QualifiedCandidatesReader.Read())
        {
            User QualifiedCandidates = new User();
            QualifiedCandidates.FirstName = QualifiedCandidatesReader["FirstName"].ToString();
            QualifiedCandidates.LastName = QualifiedCandidatesReader["LastName"].ToString();
            QualifiedCandidates.Phone = QualifiedCandidatesReader["Phone"].ToString();
            QualifiedCandidates.UserEmail = QualifiedCandidatesReader["Email"].ToString();
            QualifiedCandidates.Profession = QualifiedCandidatesReader["Profession"].ToString();
            QualifiedCandidates.Region = QualifiedCandidatesReader["Region"].ToString();
            QualifiedCandidates.CoverLetter = QualifiedCandidatesReader["CoverLetter"].ToString();
            QualifiedCandidates.Resume = QualifiedCandidatesReader["Resume"].ToString();
            AllQualifiedCandidates.Add(QualifiedCandidates);
        }

        QualifiedCandidatesReader.Close();
        con.Close();
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(AllQualifiedCandidates));

    }
    [WebMethod]
    public void AllCandidates()
    {
        List<User> AllQualifiedCandidates = new List<User>();

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand GetQualifiedCandidatesCommand;
        GetQualifiedCandidatesCommand = new SqlCommand("");
        GetQualifiedCandidatesCommand.CommandType = CommandType.StoredProcedure;
        GetQualifiedCandidatesCommand.Connection = con;
        GetQualifiedCandidatesCommand.CommandText = "GetAllCandidates";

        con.Open();

        SqlDataReader QualifiedCandidatesReader;
        QualifiedCandidatesReader = GetQualifiedCandidatesCommand.ExecuteReader();
        
        while (QualifiedCandidatesReader.Read())
        {
            User QualifiedCandidates = new User();
            QualifiedCandidates.FirstName = QualifiedCandidatesReader["FirstName"].ToString();
            QualifiedCandidates.LastName = QualifiedCandidatesReader["LastName"].ToString();
            QualifiedCandidates.Phone = QualifiedCandidatesReader["Phone"].ToString();
            QualifiedCandidates.UserEmail = QualifiedCandidatesReader["Email"].ToString();
            QualifiedCandidates.CoverLetter = QualifiedCandidatesReader["CoverLetter"].ToString();
            QualifiedCandidates.Resume = QualifiedCandidatesReader["Resume"].ToString();
            AllQualifiedCandidates.Add(QualifiedCandidates);
        }

        QualifiedCandidatesReader.Close();
        con.Close();
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(AllQualifiedCandidates));

    }
}
