using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JobPostings
/// </summary>
public class JobPostings
{
    public List<JobPosting> GetAllJobPostings()
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetAllJobPostings";

        con.Open();

        SqlDataReader reader;
        reader = cmd.ExecuteReader();

        List<JobPosting> jobPostingsList = new List<JobPosting>();

        while (reader.Read())
        {
            JobPosting aJobPosting = new JobPosting();

            aJobPosting.JobPostingID = Convert.ToInt32(reader["JobPostingID"]);
            aJobPosting.CompanyName = reader["CompanyName"].ToString();
            aJobPosting.Description = reader["Description"].ToString();

            jobPostingsList.Add(aJobPosting);
        }


        con.Close();

        return jobPostingsList;
    }
}