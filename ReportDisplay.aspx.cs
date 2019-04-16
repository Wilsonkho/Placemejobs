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

public partial class ReportDisplay : System.Web.UI.Page
{
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
            table = new PdfPTable(4);
            table.AddCell("First Name");
            table.AddCell("Last Name");
            table.AddCell("Email");
            table.AddCell("Phone");
            //table.AddCell("Date");

            int searchJobPostingID = userJobPostingItem.JobPostingID;
            string statusDate = userJobPostingItem.StatusDate.ToString("MMM dd, yyyy");

            aJobPosting = controller.GetJobPostingDetails(searchJobPostingID);
            foreach (var idTrackerItem in idTrackerList)
            {
                if (idTrackerItem == searchJobPostingID)
                {
                    exists = true;
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
                    //table.AddCell(statusDate);
                   
                }
                doc.Add(table);
                doc.Add(new Paragraph("\n"));

                idTrackerList.Add(searchJobPostingID);
            }
        }

    }
}