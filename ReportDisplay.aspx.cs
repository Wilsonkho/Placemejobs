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



        List<User> userList = new List<User>();
        //userList = controller.GetUserDetails();


        PdfPTable table = new PdfPTable(3);
        PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
        cell.Colspan = 3;
        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
        table.AddCell(cell);
        
        table.AddCell("Col 1 Row 1");
        table.AddCell("Col 2 Row 1");
        table.AddCell("Col 3 Row 1");
        table.AddCell("Col 1 Row 2");
        table.AddCell("Col 2 Row 2");
        table.AddCell("Col 3 Row 2");
        doc.Add(table);
    }
}