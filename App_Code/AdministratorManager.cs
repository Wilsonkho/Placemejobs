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
        GetQualifiedCandidatesCommand.CommandText = "QualifiedCandidatesProcedure";

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
            QualifiedCandidates.CoverLetter = QualifiedCandidatesReader["CoverLetter"].ToString();
            QualifiedCandidates.Resume = QualifiedCandidatesReader["Resume"].ToString();
           
            //ItemSearch.unitprice = Convert.ToDecimal(ItemSearchReader["unitprice"].ToString());
        }
        return QualifiedCandidates;
        QualifiedCandidatesReader.Close();
        con.Close();
        
    }
}