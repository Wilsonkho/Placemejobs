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

    public bool UpdateProfession( string UpdatedProfessionDescription, int ProfessionID)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddRegionCommand;
        AddRegionCommand = new SqlCommand("");
        AddRegionCommand.CommandType = CommandType.StoredProcedure;
        AddRegionCommand.Connection = con;
        AddRegionCommand.CommandText = "UpdateProfession";

        SqlParameter professionIDParameter;
        SqlParameter UpdatedDescriptionParameter;

        professionIDParameter = new SqlParameter();
        UpdatedDescriptionParameter = new SqlParameter();

        professionIDParameter.ParameterName = "@ProfessionID";
        UpdatedDescriptionParameter.ParameterName = "@UpdatedDescription";

        professionIDParameter.SqlDbType = SqlDbType.Int;
        professionIDParameter.Direction = ParameterDirection.Input;

        UpdatedDescriptionParameter.SqlDbType = SqlDbType.NChar;
        UpdatedDescriptionParameter.Direction = ParameterDirection.Input;

        professionIDParameter.Value = ProfessionID;
        UpdatedDescriptionParameter.Value = UpdatedProfessionDescription;

        con.Open();

        AddRegionCommand.Parameters.Add(UpdatedDescriptionParameter);
        AddRegionCommand.Parameters.Add(professionIDParameter);
 

        int rowsAffected = AddRegionCommand.ExecuteNonQuery();

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
    public bool DeleteProfession(string professionID)
    {
        bool Success;
        SqlConnection PlacemeJobsConnection;
        PlacemeJobsConnection = new SqlConnection();
        PlacemeJobsConnection.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand DeleteProfessionCommand;
        DeleteProfessionCommand = new SqlCommand();
        DeleteProfessionCommand.CommandType = CommandType.StoredProcedure;
        DeleteProfessionCommand.Connection = PlacemeJobsConnection;
        DeleteProfessionCommand.CommandText = "DeleteProfession";

        SqlParameter ProfessionID;
        ProfessionID = new SqlParameter();
        ProfessionID.ParameterName = "@ProfessionID";
        ProfessionID.SqlDbType = SqlDbType.Int;
        ProfessionID.Direction = ParameterDirection.Input;
        ProfessionID.Value = professionID;

        SqlParameter ReturnParameter;
        ReturnParameter = new SqlParameter();
        ReturnParameter.ParameterName = "ReturnValue";
        ReturnParameter.SqlDbType = SqlDbType.Int;
        ReturnParameter.Direction = ParameterDirection.ReturnValue;




        DeleteProfessionCommand.Parameters.Add(ProfessionID);
        DeleteProfessionCommand.Parameters.Add(ReturnParameter);
        PlacemeJobsConnection.Open();


        DeleteProfessionCommand.ExecuteNonQuery();
        if ((int)DeleteProfessionCommand.Parameters["ReturnValue"].Value == 0)
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
