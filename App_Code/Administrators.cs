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
public class Administrators
{

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

        SqlDataReader reader;
        reader = GetQualifiedCandidatesCommand.ExecuteReader();
        //double textvalue = Convert.ToDouble(unitprice.Text.ToString());
        while (reader.Read())
        {
            User aCandidate = new User();

            aCandidate.UserID = Convert.ToInt32(reader["UserID"]);
            aCandidate.FirstName = reader["FirstName"].ToString();
            aCandidate.LastName = reader["LastName"].ToString();
            aCandidate.Phone = reader["Phone"].ToString();
            aCandidate.UserEmail = reader["Email"].ToString();
            aCandidate.Profession = reader["Profession"].ToString();
            aCandidate.Region = reader["Region"].ToString();
            aCandidate.CoverLetter = reader["CoverLetter"].ToString();
            aCandidate.Resume = reader["Resume"].ToString();

            qualifiedCandidates.Add(aCandidate);
        }
        
        con.Close();
        return qualifiedCandidates;

    }

    public bool AddCandidateToJobPosting(int userid, int jobpostingid, string date)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "AddCandidateToJobPosting";

        SqlParameter UseridParameter;
        SqlParameter JobpostingParameter;
        SqlParameter DateParameter;

        UseridParameter = new SqlParameter();
        JobpostingParameter = new SqlParameter();
        DateParameter = new SqlParameter();

        UseridParameter.ParameterName = "@UserID";
        JobpostingParameter.ParameterName = "@JobPostingID";
        DateParameter.ParameterName = "@Date";


        UseridParameter.SqlDbType = SqlDbType.Int;
        UseridParameter.Direction = ParameterDirection.Input;

        JobpostingParameter.SqlDbType = SqlDbType.Int;
        JobpostingParameter.Direction = ParameterDirection.Input;

        DateParameter.SqlDbType = SqlDbType.Date;
        DateParameter.Direction = ParameterDirection.Input;

        UseridParameter.Value = userid;  
        JobpostingParameter.Value = jobpostingid;
        DateParameter.Value = date;

        cmd.Parameters.Add(UseridParameter);
        cmd.Parameters.Add(JobpostingParameter);
        cmd.Parameters.Add(DateParameter);

        con.Open();

        int rowsAffected = cmd.ExecuteNonQuery();

        Boolean success = false;
        if (rowsAffected != 0)
        {
            success = true;
        }
        else
        {
            success = false;
        }
        return success;

    }
    public List<User> GetAssignedCandidates(int JobPostingID)
    {
        List<User> qualifiedCandidates = new List<User>();

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand GetAssignedCandidatesCommand;
        GetAssignedCandidatesCommand = new SqlCommand("");
        GetAssignedCandidatesCommand.CommandType = CommandType.StoredProcedure;
        GetAssignedCandidatesCommand.Connection = con;
        GetAssignedCandidatesCommand.CommandText = "GetJobCandidates";

        SqlParameter JobPostingIdParameter;
        JobPostingIdParameter = new SqlParameter();
        JobPostingIdParameter.ParameterName = "@JobPostingID";
        JobPostingIdParameter.SqlDbType = SqlDbType.Int;
        JobPostingIdParameter.Direction = ParameterDirection.Input;
        JobPostingIdParameter.Value = JobPostingID;
        GetAssignedCandidatesCommand.Parameters.Add(JobPostingIdParameter);

        con.Open();

        SqlDataReader reader;
        reader = GetAssignedCandidatesCommand.ExecuteReader();

        while (reader.Read())
        {
            User aCandidate = new User();

            aCandidate.UserID = Convert.ToInt32(reader["UserID"]);
            aCandidate.FirstName = reader["FirstName"].ToString();
            aCandidate.LastName = reader["LastName"].ToString();
            aCandidate.Phone = reader["Phone"].ToString();
            aCandidate.UserEmail = reader["Email"].ToString();
            aCandidate.CoverLetter = reader["CoverLetter"].ToString();
            aCandidate.Resume = reader["Resume"].ToString();
            aCandidate.JobStatus = reader["Status"].ToString();
            aCandidate.StatusDate = Convert.ToDateTime(reader["StatusDate"]).ToString("yyyy-MM-dd");

            qualifiedCandidates.Add(aCandidate);
        }

        con.Close();
        return qualifiedCandidates;

    }
    public bool UpdateCandidateJobStatus(int userid, int jobpostingid, string status, string date)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "UpdateJobStatus";

        SqlParameter UseridParameter;
        SqlParameter JobpostingParameter;
        SqlParameter StatusParameter;
        SqlParameter DateParameter;

        UseridParameter = new SqlParameter();
        JobpostingParameter = new SqlParameter();
        StatusParameter = new SqlParameter();
        DateParameter = new SqlParameter();

        UseridParameter.ParameterName = "@UserID";
        JobpostingParameter.ParameterName = "@JobPostingID";
        StatusParameter.ParameterName = "@Status";
        DateParameter.ParameterName = "@StatusDate";

        UseridParameter.SqlDbType = SqlDbType.Int;
        UseridParameter.Direction = ParameterDirection.Input;

        JobpostingParameter.SqlDbType = SqlDbType.Int;
        JobpostingParameter.Direction = ParameterDirection.Input;

        StatusParameter.SqlDbType = SqlDbType.Char;
        StatusParameter.Direction = ParameterDirection.Input;

        DateParameter.SqlDbType = SqlDbType.Date;
        DateParameter.Direction = ParameterDirection.Input;

        UseridParameter.Value = userid;
        JobpostingParameter.Value = jobpostingid;
        StatusParameter.Value = status;
        DateParameter.Value = date;

        cmd.Parameters.Add(UseridParameter);
        cmd.Parameters.Add(JobpostingParameter);
        cmd.Parameters.Add(StatusParameter);
        cmd.Parameters.Add(DateParameter);

        con.Open();

        int rowsAffected = cmd.ExecuteNonQuery();

        Boolean success = false;
        if (rowsAffected != 0)
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