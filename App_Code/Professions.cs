using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Professions
{
    public Profession[] GetProfessions()
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetProfessions";

        

        //3. Create Adapter
        SqlDataAdapter PlaceMeJobDataAdapter = new SqlDataAdapter();
        PlaceMeJobDataAdapter.SelectCommand = cmd;

        //4. Create DataSet
        DataSet PlaceMeJobDataSet = new DataSet();
        PlaceMeJobDataAdapter.Fill(PlaceMeJobDataSet);

        DataTable PlaceMeJobTable = PlaceMeJobDataSet.Tables[0];

        int count = 0;
        Profession[] professions = new Profession[PlaceMeJobTable.Rows.Count];     
        foreach (DataRow row in PlaceMeJobTable.Rows)
        {
            professions[count] = new Profession();
            professions[count].ProfessionID = (int)row["ProfessionID"];
            professions[count].Description = row["Description"].ToString();
            count += 1;
        }

        con.Close();
        return professions;



    }

    public bool AddUserProfession(int userID, int professionID)
    {
        bool Success;

        SqlConnection PlacemeJobsConnection;
        PlacemeJobsConnection = new SqlConnection();
        PlacemeJobsConnection.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddUserProfessionCommand;
        AddUserProfessionCommand = new SqlCommand();
        AddUserProfessionCommand.CommandType = CommandType.StoredProcedure;
        AddUserProfessionCommand.Connection = PlacemeJobsConnection;
        AddUserProfessionCommand.CommandText = "AddUserProfession";

        SqlParameter UserID;
        UserID = new SqlParameter();
        UserID.ParameterName = "@UserID";
        UserID.SqlDbType = SqlDbType.Int;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = userID;

        SqlParameter ProfessionID;
        ProfessionID = new SqlParameter();
        ProfessionID.ParameterName = "@ProfessionID";
        ProfessionID.SqlDbType = SqlDbType.Int;
        ProfessionID.Direction = ParameterDirection.Input;
        ProfessionID.Value = professionID;

        SqlParameter ReturnParameter;
        ReturnParameter = new SqlParameter();
        ReturnParameter.ParameterName = "ReturnValue";
        ReturnParameter.Direction = ParameterDirection.ReturnValue;

        AddUserProfessionCommand.Parameters.Add(UserID);
        AddUserProfessionCommand.Parameters.Add(ProfessionID);
        AddUserProfessionCommand.Parameters.Add(ReturnParameter);

        PlacemeJobsConnection.Open();


        AddUserProfessionCommand.ExecuteNonQuery();
        if ((int)AddUserProfessionCommand.Parameters["ReturnValue"].Value == 0)
        {
            Success = true;
        }
        else
        {
            Success = false;
        }
        return Success;
    }
}
