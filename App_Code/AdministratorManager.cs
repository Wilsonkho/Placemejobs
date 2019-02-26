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

    public User GetQualifiedCandidates(int JobPostingID)
    {
        User QualifiedCandidates = new User();

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
            QualifiedCandidates.FirstName = QualifiedCandidatesReader["Name"].ToString();
            QualifiedCandidates.LastName = QualifiedCandidatesReader["Name"].ToString();
            QualifiedCandidates.Phone = QualifiedCandidatesReader["Phone"].ToString();
            QualifiedCandidates.UserEmail = QualifiedCandidatesReader["Email"].ToString();
            QualifiedCandidates.Profession = QualifiedCandidatesReader["Profession"].ToString();
            QualifiedCandidates.Region = QualifiedCandidatesReader["Region"].ToString();
            QualifiedCandidates.CoverLetter = QualifiedCandidatesReader["CoverLetter"].ToString();
            QualifiedCandidates.Resume = QualifiedCandidatesReader["Resume"].ToString();
           
            
        }
        return QualifiedCandidates;
        QualifiedCandidatesReader.Close();
        con.Close();
        
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
}