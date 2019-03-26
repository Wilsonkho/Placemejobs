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
        catch (Exception)
        {

            throw;
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

        List<JobPosting> jobPostingList = new List<JobPosting>();
        List<UserJobPosting> refinedList = new List<UserJobPosting>();
        List<User> userList = new List<User>();

        doc.Add(new Paragraph("\n\n"));
        doc.Add(new Chunk("Candidate Status Report (" + Request["status"] + ")", FontFactory.GetFont("arial", 22f)).SetUnderline(1f, -1.5f));
        doc.Add(new Paragraph("Date: " + DateTime.Now.ToString() + "\n\n"));

        foreach (var userJobPostingItem in userJobPostingList)
        {
            int searchJobPostingID = userJobPostingItem.JobPostingID;
            string statusDate = userJobPostingItem.StatusDate.ToString("MMM dd, yyyy");

            jobPostingList = controller.GetJobPostingDetails(searchJobPostingID);
            JobPosting aJobPosting = new JobPosting();

            foreach (var jobPostingItem in jobPostingList)
            {
                if (jobPostingItem.JobPostingID == searchJobPostingID)
                {
                    doc.Add(new Chunk(jobPostingItem.CompanyName + " - " + jobPostingItem.Description, FontFactory.GetFont("arial", 14f)));
                    //Get UserID by JobPostingID and Status
                    refinedList = controller.GetUserIDByJobPostingStatus(searchJobPostingID, Request["status"]);

                    foreach (var refinedListItem in refinedList)
                    {
                        int searchUserID = refinedListItem.UserID;

                        userList = controller.GetUserDetails(searchUserID);

                        foreach (var userListItem in userList)
                        {
                            if (userListItem.UserID == searchUserID)
                            {
                                PdfPTable table = new PdfPTable(5);
                                //PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
                                //cell.Colspan = 3;
                                //cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                                //table.AddCell(cell);

                                table.AddCell("First Name");
                                table.AddCell("Last Name");
                                table.AddCell("Email");
                                table.AddCell("Phone");
                                table.AddCell("Date");
                                table.AddCell(userListItem.FirstName);
                                table.AddCell(userListItem.LastName);
                                table.AddCell(userListItem.UserEmail);
                                table.AddCell(userListItem.Phone);
                                table.AddCell(statusDate);
                                doc.Add(table);
                            }
                        }
                    }
                    doc.Add(new Paragraph("\n"));
                }
            }
        }

        //PdfPTable table = new PdfPTable(3);
        //PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
        //cell.Colspan = 3;
        //cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
        //table.AddCell(cell);

        //table.AddCell("Col 1 Row 1");
        //table.AddCell("Col 2 Row 1");
        //table.AddCell("Col 3 Row 1");
        //table.AddCell("Col 1 Row 2");
        //table.AddCell("Col 2 Row 2");
        //table.AddCell("Col 3 Row 2");
        //doc.Add(table);

        //PdfPTable table = new PdfPTable(4);
        //PdfPCell cell = new PdfPCell(new Phrase("Table Name"));
        //cell.Colspan = 4;
        //cell.HorizontalAlignment = 1;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase("Header 1"));
        //cell.HorizontalAlignment = 1;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase("Header 2"));
        //cell.HorizontalAlignment = 1;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase("Header 3"));
        //cell.HorizontalAlignment = 1;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase("Header 4"));
        //cell.HorizontalAlignment = 1;
        //table.AddCell(cell);
        //table.AddCell("Table Cell 1.1");
        //table.AddCell("Table Cell 1.1");
        //table.AddCell("Table Cell 1.3");
        //table.AddCell("Table Cell 1.4");
        //table.AddCell("Table Cell 2.1");
        //table.AddCell("Table Cell 2.2");
        //table.AddCell("Table Cell 2.3");
        //table.AddCell("Table Cell 2.4");
        //cell = new PdfPCell(new Phrase("Big Table Cell"));
        //cell.Colspan = 3;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase("Regular Cell"));
        //cell.Colspan = 1;
        //table.AddCell(cell);
        //doc.Add(table);
    }
}