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
}