using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PRMS controller = new PRMS();
        // Get all job postings
        List<JobPosting> jobPostingsList = new List<JobPosting>();
        jobPostingsList = controller.GetAllJobPostings();

        // Table Headings
        TableHeaderRow tableHRow = new TableHeaderRow();
        List<String> headerList = new List<String>()
        {
            "Company Name", "Job Description"
        };

        foreach (string header in headerList)
        {
            TableHeaderCell tableHCell = new TableHeaderCell();
            tableHCell.Text = header;

            tableHRow.Cells.Add(tableHCell);
        }

        JobPostingsTable.Rows.Add(tableHRow);

        // Table Rows
        TableRow aNewRow;
        int index = 0;

        foreach (var item in jobPostingsList)
        {
            aNewRow = new TableRow();

            TableCell aNewCell = new TableCell();
            aNewCell.Text = item.CompanyName;
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            aNewCell.Text = item.Description;
            aNewRow.Cells.Add(aNewCell);

            JobPostingsTable.Rows.Add(aNewRow);
            index++;
        }

    }

    protected void Signout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}