﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


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

    public int AddJobPosting(JobPosting job)
    {

        SqlConnection PlacemeJobsConnection;
        PlacemeJobsConnection = new SqlConnection();
        PlacemeJobsConnection.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddJobPostingCommand;
        AddJobPostingCommand = new SqlCommand();
        AddJobPostingCommand.CommandType = CommandType.StoredProcedure;
        AddJobPostingCommand.Connection = PlacemeJobsConnection;
        AddJobPostingCommand.CommandText = "AddJobPosting";

        SqlParameter Description;
        Description = new SqlParameter();
        Description.ParameterName = "@Description";
        Description.SqlDbType = SqlDbType.VarChar;
        Description.Direction = ParameterDirection.Input;
        Description.Value = job.Description;

        SqlParameter CompanyName;
        CompanyName = new SqlParameter();
        CompanyName.ParameterName = "@CompanyName";
        CompanyName.SqlDbType = SqlDbType.VarChar;
        CompanyName.Direction = ParameterDirection.Input;
        CompanyName.Value = job.CompanyName;

        SqlParameter ProfessionID;
        ProfessionID = new SqlParameter();
        ProfessionID.ParameterName = "@ProfessionID";
        ProfessionID.SqlDbType = SqlDbType.Int;
        ProfessionID.Direction = ParameterDirection.Input;
        ProfessionID.Value = job.ProfessionID;

        SqlParameter RegionID;
        RegionID = new SqlParameter();
        RegionID.ParameterName = "@RegionID";
        RegionID.SqlDbType = SqlDbType.Int;
        RegionID.Direction = ParameterDirection.Input;
        RegionID.Value = job.RegionID;

        SqlParameter Date;
        Date = new SqlParameter();
        Date.ParameterName = "@Date";
        Date.SqlDbType = SqlDbType.Date;
        Date.Direction = ParameterDirection.Input;
        Date.Value = job.Date;

        SqlParameter EmployerPhone;
        EmployerPhone = new SqlParameter();
        EmployerPhone.ParameterName = "@EmployerPhone";
        EmployerPhone.SqlDbType = SqlDbType.VarChar;
        EmployerPhone.Direction = ParameterDirection.Input;
        EmployerPhone.Value = job.EmployerPhone;

        SqlParameter ReturnParameter;
        ReturnParameter = new SqlParameter();
        ReturnParameter.ParameterName = "ReturnValue";
        ReturnParameter.SqlDbType = SqlDbType.Int;
        ReturnParameter.Direction = ParameterDirection.ReturnValue;


        AddJobPostingCommand.Parameters.Add(Description);
        AddJobPostingCommand.Parameters.Add(CompanyName);
        AddJobPostingCommand.Parameters.Add(EmployerPhone);
        AddJobPostingCommand.Parameters.Add(ProfessionID);
        AddJobPostingCommand.Parameters.Add(RegionID);
        AddJobPostingCommand.Parameters.Add(Date);
        AddJobPostingCommand.Parameters.Add(ReturnParameter);

        PlacemeJobsConnection.Open();


        AddJobPostingCommand.ExecuteNonQuery();
        return (int)AddJobPostingCommand.Parameters["ReturnValue"].Value;
        
        
    }

    internal JobPosting GetJobPosting(int jobPostingID)
    {
        JobPosting aJobPosting = new JobPosting();
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetJobPosting";

        SqlParameter JobPostingID;
        JobPostingID = new SqlParameter();
        JobPostingID.ParameterName = "@JobPostingID";
        JobPostingID.SqlDbType = SqlDbType.Int;
        JobPostingID.Direction = ParameterDirection.Input;
        JobPostingID.Value = jobPostingID;

        cmd.Parameters.Add(JobPostingID);

        con.Open();

        SqlDataReader reader;
        reader = cmd.ExecuteReader();



        while (reader.Read())
        {
            

            aJobPosting.JobPostingID = Convert.ToInt32(reader["JobPostingID"]);
            aJobPosting.EmployerPhone = reader["EmployerPhone"].ToString();
            aJobPosting.CompanyName = reader["CompanyName"].ToString();
            aJobPosting.Description = reader["Description"].ToString();
            aJobPosting.Date = DateTime.Parse(reader["Date"].ToString());
            aJobPosting.ProfessionID = int.Parse(reader["ProfessionID"].ToString());
            aJobPosting.RegionID = int.Parse(reader["RegionID"].ToString());

        }


        con.Close();

        return aJobPosting;
    }
}