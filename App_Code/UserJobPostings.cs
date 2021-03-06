﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserJobPostings
/// </summary>
public class UserJobPostings
{
    public List<UserJobPosting> GetUserJobPostingByStatus(string status)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserJobPostingByStatus";

        SqlParameter Status = new SqlParameter();
        Status.ParameterName = "@Status";
        Status.SqlDbType = SqlDbType.VarChar;
        Status.Direction = ParameterDirection.Input;
        Status.Value = status;

        cmd.Parameters.Add(Status);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        List<UserJobPosting> userJobPostingList = new List<UserJobPosting>();

        while (reader.Read())
        {
            UserJobPosting userJobPostingEntry = new UserJobPosting();

            userJobPostingEntry.UserID = Convert.ToInt32(reader["UserID"]);
            userJobPostingEntry.JobPostingID = Convert.ToInt32(reader["JobPostingID"]);
            userJobPostingEntry.StatusDate = Convert.ToDateTime(reader["StatusDate"]);

            userJobPostingList.Add(userJobPostingEntry);
        }

        return userJobPostingList;
    }

    public List<UserJobPosting> GetUserIDByJobPostingStatus(int jobPostingID, string status)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserIDByJobPostingStatus";

        SqlParameter JobPostingID = new SqlParameter();
        JobPostingID.ParameterName = "@JobPostingID";
        JobPostingID.SqlDbType = SqlDbType.Int;
        JobPostingID.Direction = ParameterDirection.Input;
        JobPostingID.Value = jobPostingID;

        cmd.Parameters.Add(JobPostingID);

        SqlParameter Status = new SqlParameter();
        Status.ParameterName = "@Status";
        Status.SqlDbType = SqlDbType.VarChar;
        Status.Direction = ParameterDirection.Input;
        Status.Value = status;

        cmd.Parameters.Add(Status);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        List<UserJobPosting> userJobPostingList = new List<UserJobPosting>();

        while (reader.Read())
        {
            UserJobPosting userJobPostingEntry = new UserJobPosting();

            userJobPostingEntry.UserID = Convert.ToInt32(reader["UserID"]);

            userJobPostingList.Add(userJobPostingEntry);
        }

        return userJobPostingList;
    }
}