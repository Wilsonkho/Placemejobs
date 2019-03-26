
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public class Regions
{
    public Region[] GetRegions()
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetRegions";

        //3. Create Adapter
        SqlDataAdapter PlaceMeJobDataAdapter = new SqlDataAdapter();
        PlaceMeJobDataAdapter.SelectCommand = cmd;

        //4. Create DataSet
        DataSet PlaceMeJobDataSet = new DataSet();
        PlaceMeJobDataAdapter.Fill(PlaceMeJobDataSet);

        DataTable PlaceMeJobTable = PlaceMeJobDataSet.Tables[0];

        int count = 0;
        Region[] regions = new Region[PlaceMeJobTable.Rows.Count];
        foreach (DataRow row in PlaceMeJobTable.Rows)
        {
            regions[count] = new Region();
            regions[count].RegionID = (int)row["RegionID"];
            regions[count].Description = row["Description"].ToString();
            count += 1;
        }

        con.Close();
        return regions;

    }


    public bool AddUserRegion(int userID, int regionID)
    {
        bool Success;

        SqlConnection PlacemeJobsConnection;
        PlacemeJobsConnection = new SqlConnection();
        PlacemeJobsConnection.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddUserRegionCommand;
        AddUserRegionCommand = new SqlCommand();
        AddUserRegionCommand.CommandType = CommandType.StoredProcedure;
        AddUserRegionCommand.Connection = PlacemeJobsConnection;
        AddUserRegionCommand.CommandText = "AddUserRegion";

        SqlParameter UserID;
        UserID = new SqlParameter();
        UserID.ParameterName = "@UserID";
        UserID.SqlDbType = SqlDbType.Int;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = userID;

        SqlParameter RegionID;
        RegionID = new SqlParameter();
        RegionID.ParameterName = "@RegionID";
        RegionID.SqlDbType = SqlDbType.Int;
        RegionID.Direction = ParameterDirection.Input;
        RegionID.Value = regionID;

        SqlParameter ReturnParameter;
        ReturnParameter = new SqlParameter();
        ReturnParameter.ParameterName = "ReturnValue";
        ReturnParameter.Direction = ParameterDirection.ReturnValue;

        AddUserRegionCommand.Parameters.Add(UserID);
        AddUserRegionCommand.Parameters.Add(RegionID);
        AddUserRegionCommand.Parameters.Add(ReturnParameter);

        PlacemeJobsConnection.Open();


        AddUserRegionCommand.ExecuteNonQuery();
        if ((int)AddUserRegionCommand.Parameters["ReturnValue"].Value == 0)
        {
            Success = true;
        }
        else
        {
            Success = false;
        }
        return Success;
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

        bool success = false;
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

    public bool UpdateRegion(string updatedRegionDescription, int regionID)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddRegionCommand;
        AddRegionCommand = new SqlCommand("");
        AddRegionCommand.CommandType = CommandType.StoredProcedure;
        AddRegionCommand.Connection = con;
        AddRegionCommand.CommandText = "UpdateRegion";

        SqlParameter regionIdParameter;
        SqlParameter UpdatedDescriptionParameter;

        regionIdParameter = new SqlParameter();
        UpdatedDescriptionParameter = new SqlParameter();

        regionIdParameter.ParameterName = "@RegionID";
        UpdatedDescriptionParameter.ParameterName = "@updatedRegionDescription";

        regionIdParameter.SqlDbType = SqlDbType.Int;
        regionIdParameter.Direction = ParameterDirection.Input;

        UpdatedDescriptionParameter.SqlDbType = SqlDbType.NChar;
        UpdatedDescriptionParameter.Direction = ParameterDirection.Input;

        regionIdParameter.Value = regionID;
        UpdatedDescriptionParameter.Value = updatedRegionDescription;

        con.Open();

        AddRegionCommand.Parameters.Add(UpdatedDescriptionParameter);
        AddRegionCommand.Parameters.Add(regionIdParameter);


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
}