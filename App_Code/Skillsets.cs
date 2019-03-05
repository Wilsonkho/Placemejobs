
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Skillsets
/// </summary>
public class Skillsets
{
    public Skillset[] GetSkillsets()
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetSkillsets";



        //3. Create Adapter
        SqlDataAdapter PlaceMeJobDataAdapter = new SqlDataAdapter();
        PlaceMeJobDataAdapter.SelectCommand = cmd;

        //4. Create DataSet
        DataSet PlaceMeJobDataSet = new DataSet();
        PlaceMeJobDataAdapter.Fill(PlaceMeJobDataSet);

        DataTable PlaceMeJobTable = PlaceMeJobDataSet.Tables[0];

        int count = 0;
        Skillset[] skillsets = new Skillset[PlaceMeJobTable.Rows.Count];
        foreach (DataRow row in PlaceMeJobTable.Rows)
        {
            skillsets[count] = new Skillset();
            skillsets[count].SkillsetID = (int)row["SkillsetID"];
            skillsets[count].Description = row["Description"].ToString();
            count += 1;
        }

        con.Close();
        return skillsets;



    }

    public bool AddUserSkill(int userID, int skillID)
    {
        bool Success;

        SqlConnection PlacemeJobsConnection;
        PlacemeJobsConnection = new SqlConnection();
        PlacemeJobsConnection.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand AddUserSkillsetCommand;
        AddUserSkillsetCommand = new SqlCommand();
        AddUserSkillsetCommand.CommandType = CommandType.StoredProcedure;
        AddUserSkillsetCommand.Connection = PlacemeJobsConnection;
        AddUserSkillsetCommand.CommandText = "AddUserSkillset";

        SqlParameter UserID;
        UserID = new SqlParameter();
        UserID.ParameterName = "@UserID";
        UserID.SqlDbType = SqlDbType.Int;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = userID;

        SqlParameter SkillID;
        SkillID = new SqlParameter();
        SkillID.ParameterName = "@SkillID";
        SkillID.SqlDbType = SqlDbType.Int;
        SkillID.Direction = ParameterDirection.Input;
        SkillID.Value = skillID;

        SqlParameter ReturnParameter;
        ReturnParameter = new SqlParameter();
        ReturnParameter.ParameterName = "ReturnValue";
        ReturnParameter.Direction = ParameterDirection.ReturnValue;

        AddUserSkillsetCommand.Parameters.Add(UserID);
        AddUserSkillsetCommand.Parameters.Add(SkillID);
        AddUserSkillsetCommand.Parameters.Add(ReturnParameter);

        PlacemeJobsConnection.Open();


        AddUserSkillsetCommand.ExecuteNonQuery();
        if ((int)AddUserSkillsetCommand.Parameters["ReturnValue"].Value == 0)
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