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

public class Users
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

    public User GetUserDetails(int userID)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserDetails";

        SqlParameter UserID = new SqlParameter();
        UserID.ParameterName = "@UserID";
        UserID.SqlDbType = SqlDbType.Int;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = userID;

        cmd.Parameters.Add(UserID);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        reader.Read();

        User aUser = new User();

        aUser.UserID = Convert.ToInt32(reader["UserID"]);
        aUser.UserEmail = reader["Email"].ToString();
        aUser.Phone = reader["Phone"].ToString();
        aUser.FirstName = reader["FirstName"].ToString();
        aUser.LastName = reader["LastName"].ToString();

        con.Close();

        return aUser;
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

    public bool AddAccount(User newcandidate)
    {
        bool success = false;
        newcandidate.UserPassword = CreatePasswordHash(newcandidate.UserPassword, CreateSalt(5));

        //try
        //{
            SqlConnection con;
            con = new SqlConnection();
            //con.ConnectionString = "Data Source=DataBaist; Initial Catalog = Placemejobs; Integrated Security=True";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "AddCandidates";

            SqlParameter Email = new SqlParameter();
            Email.ParameterName = "@Email";
            Email.SqlDbType = SqlDbType.NVarChar;
            Email.Direction = ParameterDirection.Input;
            Email.Value = newcandidate.UserEmail;

            SqlParameter Password = new SqlParameter();
            Password.ParameterName = "@Password";
            Password.SqlDbType = SqlDbType.NChar;
            Password.Direction = ParameterDirection.Input;
            Password.Value = newcandidate.UserPassword;

            SqlParameter FirstName = new SqlParameter();
            FirstName.ParameterName = "@FirstName";
            FirstName.SqlDbType = SqlDbType.NVarChar;
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = newcandidate.FirstName;

            SqlParameter LastName = new SqlParameter();
            LastName.ParameterName = "@LastName";
            LastName.SqlDbType = SqlDbType.NVarChar;
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = newcandidate.LastName;

            SqlParameter Phone = new SqlParameter();
            Phone.ParameterName = "@Phone";
            Phone.SqlDbType = SqlDbType.NVarChar;
            Phone.Direction = ParameterDirection.Input;
            Phone.Value = newcandidate.Phone;

            SqlParameter ResumeParameter = new SqlParameter();
            ResumeParameter.ParameterName = "@Resume";
            ResumeParameter.SqlDbType = SqlDbType.NVarChar;
            ResumeParameter.Direction = ParameterDirection.Input;
            ResumeParameter.Value = newcandidate.Resume;

            SqlParameter CoverLetterParameter = new SqlParameter();
            CoverLetterParameter.ParameterName = "@CoverLetter";
            CoverLetterParameter.SqlDbType = SqlDbType.NVarChar;
            CoverLetterParameter.Direction = ParameterDirection.Input;
            CoverLetterParameter.Value = newcandidate.CoverLetter;

            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(Password);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Phone);
            cmd.Parameters.Add(ResumeParameter);
            cmd.Parameters.Add(CoverLetterParameter);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            success = true;
        //}
        //catch (Exception e)
        //{

        //    return success;
        //}
        return success;

    }

    public bool ModifyAccount(User newcandidate)
    {
        bool success = false;

        try
        {
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "UpdateAccount";

            SqlParameter UserID = new SqlParameter();
            UserID.ParameterName = "@UserID";
            UserID.SqlDbType = SqlDbType.Int;
            UserID.Direction = ParameterDirection.Input;
            UserID.Value = newcandidate.UserID;
            SqlParameter FirstName = new SqlParameter();
            FirstName.ParameterName = "@FirstName";
            FirstName.SqlDbType = SqlDbType.NVarChar;
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = newcandidate.FirstName;

            SqlParameter LastName = new SqlParameter();
            LastName.ParameterName = "@LastName";
            LastName.SqlDbType = SqlDbType.NVarChar;
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = newcandidate.LastName;


            SqlParameter Status = new SqlParameter();
            Status.ParameterName = "@Status";
            Status.SqlDbType = SqlDbType.Bit;
            Status.Direction = ParameterDirection.Input;
            Status.Value = newcandidate.ActiveInactive;

            SqlParameter Phone = new SqlParameter();
            Phone.ParameterName = "@Phone";
            Phone.SqlDbType = SqlDbType.NVarChar;
            Phone.Direction = ParameterDirection.Input;
            Phone.Value = newcandidate.Phone;


            cmd.Parameters.Add(UserID);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Status);
            cmd.Parameters.Add(Phone);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            success = true;
        }
        catch
        {

            return success;
        }
        return success;

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

    public bool UploadResume(string resume)
    {
        bool success = false;

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "AddResume";

        SqlParameter Resume = new SqlParameter();
        Resume.ParameterName = "@Resume";
        Resume.SqlDbType = SqlDbType.VarChar;
        Resume.Direction = ParameterDirection.Input;
        Resume.Value = resume;

        cmd.Parameters.Add(Resume);

        con.Open();

        int rowCount = cmd.ExecuteNonQuery();

        con.Close();

        if (rowCount != 0)
        {
            success = true;
        }
        else
        {
            success = false;
        }

        return success;

    }

    public bool AddCandidate(User newcandidate)
    {
        bool success = false;

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
            cmd.CommandText = "AddCandidateAsAdmin";

            SqlParameter Email = new SqlParameter();
            Email.ParameterName = "@Email";
            Email.SqlDbType = SqlDbType.NVarChar;
            Email.Direction = ParameterDirection.Input;
            Email.Value = newcandidate.UserEmail;

            SqlParameter FirstName = new SqlParameter();
            FirstName.ParameterName = "@FirstName";
            FirstName.SqlDbType = SqlDbType.NVarChar;
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = newcandidate.FirstName;

            SqlParameter LastName = new SqlParameter();
            LastName.ParameterName = "@LastName";
            LastName.SqlDbType = SqlDbType.NVarChar;
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = newcandidate.LastName;

            SqlParameter Phone = new SqlParameter();
            Phone.ParameterName = "@Phone";
            Phone.SqlDbType = SqlDbType.NVarChar;
            Phone.Direction = ParameterDirection.Input;
            Phone.Value = newcandidate.Phone;

            SqlParameter Resume = new SqlParameter();
            Resume.ParameterName = "@Resume";
            Resume.SqlDbType = SqlDbType.NVarChar;
            Resume.Direction = ParameterDirection.Input;
            Resume.Value = newcandidate.Resume;

            SqlParameter CoverLetter = new SqlParameter();
            CoverLetter.ParameterName = "@CoverLetter";
            CoverLetter.SqlDbType = SqlDbType.NVarChar;
            CoverLetter.Direction = ParameterDirection.Input;
            CoverLetter.Value = newcandidate.CoverLetter;

            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Phone);
            cmd.Parameters.Add(Resume);
            cmd.Parameters.Add(CoverLetter);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            success = true;
        }
        catch (Exception e)
        {

            return success;
        }
        return success;

    }

    public int GetUserIDByEmail(string userEmail)
    {
        int userID;

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserIDByEmail";

        SqlParameter Email = new SqlParameter();
        Email.ParameterName = "@Email";
        Email.SqlDbType = SqlDbType.VarChar;
        Email.Direction = ParameterDirection.Input;
        Email.Value = userEmail;

        cmd.Parameters.Add(Email);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();

        userID = Convert.ToInt32(reader["UserID"]);

        con.Close();
        return userID;

    }

    public User GetProfile(string userEmail)
    {
        User Profile = new User();
        try
        {
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "GetProfile";

            SqlParameter Email = new SqlParameter();
            Email.ParameterName = "@Email";
            Email.SqlDbType = SqlDbType.VarChar;
            Email.Direction = ParameterDirection.Input;
            Email.Value = userEmail;

            cmd.Parameters.Add(Email);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Profile.UserID = Convert.ToInt32(reader["UserID"]);
            Profile.UserEmail = reader["Email"].ToString();
            Profile.FirstName = reader["FirstName"].ToString();
            Profile.LastName = reader["LastName"].ToString();
            Profile.Resume = reader["Resume"].ToString();
            Profile.CoverLetter = reader["CoverLetter"].ToString();
            Profile.Phone = reader["Phone"].ToString();
            Profile.ActiveInactive = Convert.ToBoolean(reader["ActiveInactive"]);

            con.Close();
        }
        catch { };

        return Profile;

    }
    public bool PasswordCheck(User LoginUser, String OldPassword)
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

                NewSaltedHashPassword = CreatePasswordHash(OldPassword, ExtractedSalt);

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
    public bool UpdatePassword(User CurrentUser, string OldPassword, string NewPassword)
    {
        if (PasswordCheck(CurrentUser, OldPassword))
        {
            NewPassword = CreatePasswordHash(NewPassword, CreateSalt(5));
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

            SqlCommand cmd;
            cmd = new SqlCommand("");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "ChangePassword";

            SqlParameter UseridParameter;
            SqlParameter NewPasswordParameter;


            UseridParameter = new SqlParameter();
            NewPasswordParameter = new SqlParameter();


            UseridParameter.ParameterName = "@UserID";
            NewPasswordParameter.ParameterName = "@NewPassword";

            UseridParameter.SqlDbType = SqlDbType.Int;
            UseridParameter.Direction = ParameterDirection.Input;

            NewPasswordParameter.SqlDbType = SqlDbType.VarChar;
            NewPasswordParameter.Direction = ParameterDirection.Input;


            UseridParameter.Value = CurrentUser.UserID;
            NewPasswordParameter.Value = NewPassword;


            cmd.Parameters.Add(UseridParameter);
            cmd.Parameters.Add(NewPasswordParameter);

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

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
        else
        {
            return false;
        }
    }
    public bool UpdateEmail(int UserID, string Oldemail)
    {

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "ChangeEmail";

        SqlParameter EmailParameter;
        SqlParameter UseridParameter;

        EmailParameter = new SqlParameter();
        UseridParameter = new SqlParameter();

        UseridParameter.ParameterName = "@UserID";
        EmailParameter.ParameterName = "@NewEmail";

        UseridParameter.SqlDbType = SqlDbType.Int;
        UseridParameter.Direction = ParameterDirection.Input;

        EmailParameter.SqlDbType = SqlDbType.VarChar;
        EmailParameter.Direction = ParameterDirection.Input;


        UseridParameter.Value = UserID;
        EmailParameter.Value = Oldemail;


        cmd.Parameters.Add(UseridParameter);
        cmd.Parameters.Add(EmailParameter);

        con.Open();

        int rowsAffected = cmd.ExecuteNonQuery();

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
    public bool UpdateCoverLetter(int CurrentUser, string CoverLetter)
    {

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "ChangeCoverLetter";

        SqlParameter UseridParameter;
        SqlParameter CoverLetterParameter;


        UseridParameter = new SqlParameter();
        CoverLetterParameter = new SqlParameter();


        UseridParameter.ParameterName = "@UserID";
        CoverLetterParameter.ParameterName = "@CoverLetter";

        CoverLetterParameter.SqlDbType = SqlDbType.VarChar;
        CoverLetterParameter.Direction = ParameterDirection.Input;


        UseridParameter.Value = CurrentUser;
        CoverLetterParameter.Value = CoverLetter;


        cmd.Parameters.Add(UseridParameter);
        cmd.Parameters.Add(CoverLetterParameter);

        con.Open();

        int rowsAffected = cmd.ExecuteNonQuery();

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
    public bool UpdateResume(int CurrentUser, string Resume)
    {

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "ChangeResume";

        SqlParameter UseridParameter;
        SqlParameter ResumeParameter;


        UseridParameter = new SqlParameter();
        ResumeParameter = new SqlParameter();


        UseridParameter.ParameterName = "@UserID";
        ResumeParameter.ParameterName = "@Resume";

        ResumeParameter.SqlDbType = SqlDbType.VarChar;
        ResumeParameter.Direction = ParameterDirection.Input;


        UseridParameter.Value = CurrentUser;
        ResumeParameter.Value = Resume;


        cmd.Parameters.Add(UseridParameter);
        cmd.Parameters.Add(ResumeParameter);

        con.Open();

        int rowsAffected = cmd.ExecuteNonQuery();

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
    public List<Skillset> GetUserSkills(int CurrentUser)
    {
        List<Skillset> UserSkills = new List<Skillset>();
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserSkills";

        SqlParameter UseridParameter;

        UseridParameter = new SqlParameter();
        UseridParameter.ParameterName = "@UserID";
        UseridParameter.Value = CurrentUser;

        cmd.Parameters.Add(UseridParameter);


        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Skillset Skill = new Skillset();
            Skill.SkillsetID = Convert.ToInt32(reader["SkillsetID"]);
            Skill.Description = Convert.ToString(reader["Description"]);
            UserSkills.Add(Skill);
        }

        return UserSkills;
    }

    public List<Profession> GetUserProfessions(int CurrentUser)
    {
        List<Profession> UserProfessions = new List<Profession>();
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserProfessions";

        SqlParameter UseridParameter;

        UseridParameter = new SqlParameter();
        UseridParameter.ParameterName = "@UserID";
        UseridParameter.Value = CurrentUser;

        cmd.Parameters.Add(UseridParameter);


        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Profession Pro = new Profession();
            Pro.ProfessionID = Convert.ToInt32(reader["ProfessionID"]);
            Pro.Description = Convert.ToString(reader["Description"]);
            UserProfessions.Add(Pro);
        }

        return UserProfessions;
    }
    public List<Region> GetUserRegions(int CurrentUser)
    {
        List<Region> UserRegions = new List<Region>();
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserRegions";

        SqlParameter UseridParameter;

        UseridParameter = new SqlParameter();
        UseridParameter.ParameterName = "@UserID";
        UseridParameter.Value = CurrentUser;

        cmd.Parameters.Add(UseridParameter);


        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Region Reg = new Region();
            Reg.RegionID = Convert.ToInt32(reader["RegionID"]);
            Reg.Description = Convert.ToString(reader["Description"]);
            UserRegions.Add(Reg);
        }

        return UserRegions;
    }
    public bool DeleteUserCategories(int CurrentUser)
    {

        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "DeleteUserCategories";

        SqlParameter UseridParameter;


        UseridParameter = new SqlParameter();
        UseridParameter.ParameterName = "@UserID";

        UseridParameter.Value = CurrentUser;

        cmd.Parameters.Add(UseridParameter);
        con.Open();

        int rowsAffected = cmd.ExecuteNonQuery();

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