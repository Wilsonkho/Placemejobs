
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
}