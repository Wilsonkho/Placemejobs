using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;

public class Manager
{

    //algorithm for sha256 hash
    static string ComputeSha256Hash(string rawData)
    {
        // Create a SHA256   
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    //create new hashpassword with salt concatenates saltedhash with salt
    public string CreatePasswordHash(string Password, string salt)
    {

        string SaltedHash;
        SaltedHash = ComputeSha256Hash(Password + salt);

        //Hash contains trailing salt 
        return (SaltedHash + salt);
    }

    //generate salt 
    private static string CreateSalt(int size)
    {
        // Generate a cryptographic random number using the cryptographic
        // service provider
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        // Return a Base64 string representation of the random number
        return Convert.ToBase64String(buff);
    }
    public bool GetUser(User LoginUser)
    {

        bool Confirmaton = false;
        try
        {
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "GetUser";

            SqlParameter Email = new SqlParameter();
            Email.ParameterName = "@Email";
            Email.SqlDbType = SqlDbType.NChar;
            Email.Direction = ParameterDirection.Input;
            Email.Value = LoginUser.UserEmail;

            cmd.Parameters.Add(Email);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string SaltedHashPassword;
            string ExtractedSalt;
            string NewSaltedHashPassword;
            while (reader.Read())
            {
                SaltedHashPassword = Convert.ToString(reader.GetValue(0));

                ExtractedSalt = SaltedHashPassword.Substring(SaltedHashPassword.Length - 8);

                NewSaltedHashPassword = CreatePasswordHash(LoginUser.UserPassword, ExtractedSalt);

                if (SaltedHashPassword == NewSaltedHashPassword)
                {
                    Confirmaton = true;
                }

            }
            con.Close();
            return Confirmaton;
        }
        catch
        {
            return Confirmaton;
        }

    }

    public Boolean AddUser(User NewUser)
    {
        bool Success = false;
        //hash password with Salt and concatenate Salt at the end
        NewUser.UserPassword = CreatePasswordHash(NewUser.UserPassword, CreateSalt(5));


        try
        {
            SqlConnection con;
            con = new SqlConnection();
            //con.ConnectionString = "Data Source=DataBaist; Initial Catalog = Placemejobs; Integrated Security=True";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "AddUser";

            SqlParameter Email = new SqlParameter();
            Email.ParameterName = "@Email";
            Email.SqlDbType = SqlDbType.NChar;
            Email.Direction = ParameterDirection.Input;
            Email.Value = NewUser.UserEmail;

            SqlParameter Password = new SqlParameter();
            Password.ParameterName = "@Password";
            Password.SqlDbType = SqlDbType.NChar;
            Password.Direction = ParameterDirection.Input;
            Password.Value = NewUser.UserPassword;

            SqlParameter FirstName = new SqlParameter();
            FirstName.ParameterName = "@FirstName";
            FirstName.SqlDbType = SqlDbType.NChar;
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = NewUser.FirstName;

            SqlParameter LastName = new SqlParameter();
            LastName.ParameterName = "@LastName";
            LastName.SqlDbType = SqlDbType.NChar;
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = NewUser.LastName;

            
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(Password);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Success = true;
        }
        catch
        {
            return Success;
        }
        return Success;

    }
    public string GetRoles(User LoginUser)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetRoles";

        SqlParameter Email = new SqlParameter();
        Email.ParameterName = "@Email";
        Email.SqlDbType = SqlDbType.VarChar;
        Email.Direction = ParameterDirection.Input;
        Email.Value = LoginUser.UserEmail;

        cmd.Parameters.Add(Email);
        string UserRole = "";
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            UserRole = Convert.ToString(reader.GetValue(0));
        }
        con.Close();
        return UserRole;

    }
}