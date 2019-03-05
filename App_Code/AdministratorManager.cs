using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for AdministratorManager
/// </summary>
public class AdministratorManager
{
    public AdministratorManager()
    {
        //
        // TODO: Add constructor logic here
        //
       
    }

    public List<User> GetQualifiedCandidates(int JobPostingID)
    {
        List<User> qualifiedCandidates = new List<User>();

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
        //double textvalue = Convert.ToDouble(unitprice.Text.ToString());
        while (QualifiedCandidatesReader.Read())
        {
            User aCandidate = new User();

            aCandidate.UserID = Convert.ToInt32(QualifiedCandidatesReader["UserID"]);
            aCandidate.FirstName = QualifiedCandidatesReader["FirstName"].ToString();
            aCandidate.LastName = QualifiedCandidatesReader["LastName"].ToString();
            aCandidate.Phone = QualifiedCandidatesReader["Phone"].ToString();
            aCandidate.UserEmail = QualifiedCandidatesReader["Email"].ToString();
            aCandidate.Profession = QualifiedCandidatesReader["Profession"].ToString();
            aCandidate.Region = QualifiedCandidatesReader["Region"].ToString();
            aCandidate.CoverLetter = QualifiedCandidatesReader["CoverLetter"].ToString();
            aCandidate.Resume = QualifiedCandidatesReader["Resume"].ToString();

            qualifiedCandidates.Add(aCandidate);
        }
        
        con.Close();
        return qualifiedCandidates;

    }

    public bool AssignCandidateJobPosting(int userid, int jobpostingid, bool status)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AssignCandidateCommand;
        AssignCandidateCommand = new SqlCommand("");
        AssignCandidateCommand.CommandType = CommandType.StoredProcedure;
        AssignCandidateCommand.Connection = con;
        AssignCandidateCommand.CommandText = " ";

        SqlParameter UseridParameter;
        SqlParameter JobpostingParameter;
        SqlParameter statusParameter;

        UseridParameter = new SqlParameter();
        JobpostingParameter = new SqlParameter();
        statusParameter = new SqlParameter();

        UseridParameter.ParameterName = "@userid";
        JobpostingParameter.ParameterName = "@Jobid";
        statusParameter.ParameterName = "@status";

        UseridParameter.SqlDbType = SqlDbType.Int;
        UseridParameter.Direction = ParameterDirection.Input;

        JobpostingParameter.SqlDbType = SqlDbType.Int;
        JobpostingParameter.Direction = ParameterDirection.Input;

        statusParameter.SqlDbType = SqlDbType.Char;
        statusParameter.Direction = ParameterDirection.Input;

        UseridParameter.Value = userid;  
        JobpostingParameter.Value = jobpostingid;
        statusParameter.Value = status;

        con.Open();

        AssignCandidateCommand.Parameters.Add(UseridParameter);
        AssignCandidateCommand.Parameters.Add(JobpostingParameter);
        AssignCandidateCommand.Parameters.Add(statusParameter);

        int rowsAffected = AssignCandidateCommand.ExecuteNonQuery();

        Boolean success;
        if (rowsAffected == 0)
        {
            success = true;
        }
        else
        {
            success = false;
        }
        return success;

    }

    public bool AddProfession(string professiondescription)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddRegionCommand;
        AddRegionCommand = new SqlCommand("");
        AddRegionCommand.CommandType = CommandType.StoredProcedure;
        AddRegionCommand.Connection = con;
        AddRegionCommand.CommandText = "PopulateProfession";

        SqlParameter descriptionparameter;

        descriptionparameter = new SqlParameter();

        descriptionparameter.ParameterName = "@Description";

        descriptionparameter.SqlDbType = SqlDbType.NChar;
        descriptionparameter.Direction = ParameterDirection.Input;

        descriptionparameter.Value = professiondescription;

        con.Open();

        AddRegionCommand.Parameters.Add(descriptionparameter);

        int rowsAffected = AddRegionCommand.ExecuteNonQuery();

        Boolean success;
        if (rowsAffected == 0)
        {
            success = true;
        }
        else
        {
            success = false;
        }
        return success;
    }

    public bool AddRegion(string description)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddRegionCommand;
        AddRegionCommand = new SqlCommand("");
        AddRegionCommand.CommandType = CommandType.StoredProcedure;
        AddRegionCommand.Connection = con;
        AddRegionCommand.CommandText = "PopulateRegion";

        SqlParameter descriptionparameter;

        descriptionparameter = new SqlParameter();

        descriptionparameter.ParameterName = "@Description";
 
        descriptionparameter.SqlDbType = SqlDbType.NChar;
        descriptionparameter.Direction = ParameterDirection.Input;

        descriptionparameter.Value = description;

        con.Open();

        AddRegionCommand.Parameters.Add(descriptionparameter);

        int rowsAffected = AddRegionCommand.ExecuteNonQuery();

        Boolean success;
        if (rowsAffected == 0)
        {
            success = true;
        }
        else
        {
            success = false;
        }
        return success;
    }
}