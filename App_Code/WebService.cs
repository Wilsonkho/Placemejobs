using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;

[WebService(Namespace = "PlacemejobsWebService")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    User QualifiedCandidate2 = new User();
    [WebMethod]
    public void ViewDocuments(string Parse)
    {
        
    }
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
            QualifiedCandidates.UserID = Convert.ToInt32(QualifiedCandidatesReader["UserID"]);
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

            User QualifiedCandidate = new User();
            //Check if the row is unqiue
            if (Convert.ToInt32(QualifiedCandidatesReader["UserID"]) != QualifiedCandidate2.UserID)
            {
                if (QualifiedCandidate2.UserID != 0)
                {
                    AllQualifiedCandidates.Add(QualifiedCandidate2);
                }
                QualifiedCandidate.UserID = Convert.ToInt32(QualifiedCandidatesReader["UserID"]);
                QualifiedCandidate.FirstName = QualifiedCandidatesReader["FirstName"].ToString();
                QualifiedCandidate.LastName = QualifiedCandidatesReader["LastName"].ToString();
                QualifiedCandidate.Phone = QualifiedCandidatesReader["Phone"].ToString();
                QualifiedCandidate.UserEmail = QualifiedCandidatesReader["Email"].ToString();
                QualifiedCandidate.Profession = QualifiedCandidatesReader["Profession"].ToString();
                QualifiedCandidate.Region = QualifiedCandidatesReader["Region"].ToString();
                QualifiedCandidate.Skillset = QualifiedCandidatesReader["Skillset"].ToString();
                QualifiedCandidate.CoverLetter = QualifiedCandidatesReader["CoverLetter"].ToString();
                QualifiedCandidate.Resume = QualifiedCandidatesReader["Resume"].ToString();
                QualifiedCandidate2 = QualifiedCandidate;
            }
            //Same user row
            else
            {
                if (!QualifiedCandidate2.Profession.Contains(QualifiedCandidatesReader["Profession"].ToString()))
                {
                    QualifiedCandidate2.Profession = QualifiedCandidate2.Profession + ", " + QualifiedCandidatesReader["Profession"].ToString();
                }
                if (!QualifiedCandidate2.Region.Contains(QualifiedCandidatesReader["Region"].ToString()))
                {
                    QualifiedCandidate2.Region = QualifiedCandidate2.Region + ", " + QualifiedCandidatesReader["Region"].ToString();
                }
                if (!QualifiedCandidate2.Skillset.Contains(QualifiedCandidatesReader["Skillset"].ToString()))
                {
                    QualifiedCandidate2.Skillset = QualifiedCandidate2.Skillset + ", " + QualifiedCandidatesReader["Skillset"].ToString();
                }
                
            }
                
           
        }
        AllQualifiedCandidates.Add(QualifiedCandidate2);

        QualifiedCandidatesReader.Close();
        con.Close();
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(AllQualifiedCandidates));

    }
}
