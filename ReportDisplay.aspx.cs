using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class ReportDisplay : System.Web.UI.Page
{
    List<int> idTrackerList = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        MemoryStream m = new MemoryStream();
        iTextSharp.text.Document document = new Document();
        try
        {
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(document, m);
            writer.CloseStream = false;
            document.Open();
            PopulatePDF(ref document);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occurred while generating a report. Please contact customer support for assistance if this issue persists.')", true);
        }

        document.Close();
        Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        m.Close();
    }
    public string GetStatusDate (int UserID, int JobPostingID, string Status)
    {
        string StatusDate; 
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;

        SqlCommand cmd;
        cmd = new SqlCommand("");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "GetUserJobStatus";

        SqlParameter UseridParameter;
        UseridParameter = new SqlParameter();
        UseridParameter.ParameterName = "@UserID";
        UseridParameter.Value = UserID;

        SqlParameter JobPostingParameter;
        JobPostingParameter = new SqlParameter();
        JobPostingParameter.ParameterName = "@JobPostingID";
        JobPostingParameter.Value = JobPostingID;

        SqlParameter JobStatus;
        JobStatus = new SqlParameter();
        JobStatus.ParameterName = "@Status";
        JobStatus.Value = Status;

        cmd.Parameters.Add(UseridParameter);
        cmd.Parameters.Add(JobPostingParameter);
        cmd.Parameters.Add(JobStatus);


        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        StatusDate = Convert.ToDateTime(reader["StatusDate"]).ToString("MMM dd, yyyy");
        con.Close();

        return StatusDate;
    }

    protected void PopulatePDF(ref iTextSharp.text.Document doc)
    {
        PRMS controller = new PRMS();

        List<UserJobPosting> userJobPostingList = new List<UserJobPosting>();
        userJobPostingList = controller.GetUserJobPostingByStatus(Request["status"]);

        JobPosting aJobPosting = new JobPosting();
        List<UserJobPosting> refinedList = new List<UserJobPosting>();
        User aUser = new User();
        List<int> idTrackerList = new List<int>();
        bool exists = false;

        doc.Add(new Paragraph("\n\n"));
        doc.Add(new Chunk("Candidate Status Report (" + Request["status"] + ")", FontFactory.GetFont("arial", 22f)).SetUnderline(1f, -1.5f));
        doc.Add(new Paragraph("Date: " + DateTime.Now.ToString() + "\n\n"));

        PdfPTable table;

        foreach (var userJobPostingItem in userJobPostingList)
        {
            table = new PdfPTable(5);
            table.AddCell("First Name");
            table.AddCell("Last Name");
            table.AddCell("Email");
            table.AddCell("Phone");
            table.AddCell("Date");

            int searchJobPostingID = userJobPostingItem.JobPostingID;
            string statusDate = userJobPostingItem.StatusDate.ToString("MMM dd, yyyy");

            aJobPosting = controller.GetJobPostingDetails(searchJobPostingID);
            foreach (var idTrackerItem in idTrackerList)
            {
                if (idTrackerItem == searchJobPostingID)
                {
                    exists = true;
                    break;
                }
                else
                {
                    exists = false;
                }
            }

            if (exists == false)
            {
                doc.Add(new Chunk(aJobPosting.CompanyName + " - " + aJobPosting.Description, FontFactory.GetFont("arial", 14f)));
                //Get UserID by JobPostingID and Status
                refinedList = controller.GetUserIDByJobPostingStatus(searchJobPostingID, Request["status"]);

                foreach (var refinedListItem in refinedList)
                {
                    int searchUserID = refinedListItem.UserID;

                    aUser = controller.GetUserDetails(searchUserID);

                    table.AddCell(aUser.FirstName);
                    table.AddCell(aUser.LastName);
                    table.AddCell(aUser.UserEmail);
                    table.AddCell(aUser.Phone);
                    table.AddCell(GetStatusDate(searchUserID,searchJobPostingID,Request["Status"]));
                   
                }
                doc.Add(table);
                doc.Add(new Paragraph("\n"));

                idTrackerList.Add(searchJobPostingID);
            }
        }

    }
}