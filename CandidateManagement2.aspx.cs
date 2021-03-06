﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CandidateManagement2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            PRMS controller = new PRMS();
            // Get all job postings
            List<JobPosting> jobPostingsList = new List<JobPosting>();
            jobPostingsList = controller.GetAllJobPostings();

            // Table Headings
            TableHeaderRow tableHRow = new TableHeaderRow();
            List<String> headerList = new List<String>()
            {
                "JobPostingID", "CompanyName", "Description", "Action"
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
                aNewCell.Text = item.JobPostingID.ToString();
                aNewRow.Cells.Add(aNewCell);

                aNewCell = new TableCell();
                aNewCell.Text = item.CompanyName;
                aNewRow.Cells.Add(aNewCell);

                aNewCell = new TableCell();
                aNewCell.Text = item.Description;
                aNewRow.Cells.Add(aNewCell);

                aNewCell = new TableCell();
                Button viewButton = new Button();
                viewButton.ID = "ViewButton" + index;
                viewButton.Text = "View";
                viewButton.CssClass = "btn btn-dark";
                viewButton.Click += new EventHandler((obj, eArgs) => ViewButton_Click(obj, eArgs, item.JobPostingID, item.CompanyName, item.Description));
                aNewCell.Controls.Add(viewButton);
                aNewRow.Cells.Add(aNewCell);

                JobPostingsTable.Rows.Add(aNewRow);
                index++;
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred while obtaining data. Please contact customer support for assistance if this issue persists.’)", true);
        }
    }

    protected void ViewButton_Click(object sender, EventArgs e, int jobPostingID, string Name, string Description)
    {
        Response.Redirect("CandidateManagement.aspx?JobPostingID=" + jobPostingID.ToString() + "&Name=" + Name + "&Description=" + Description );
    }
}