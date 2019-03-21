using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CandidateManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int jobPostingID = Convert.ToInt32(Request["JobPostingID"]);
        PRMS controller = new PRMS();
        List<User> candidateList = new List<User>();
        candidateList = controller.GetQualifiedCandidates(jobPostingID);

        HeaderLabel.Text = "Candidates Matching - " + Request["Name"];
        SmallLabel.Text = Request["Description"];
        // Table Headings
        TableHeaderRow tableHRow = new TableHeaderRow();
        List<String> headerList = new List<String>()
        {
            "First Name", "Last Name", "Email", "Phone", "Cover Letter", "Resume", "Interview Date", "Action"
        };

        foreach (string header in headerList)
        {
            TableHeaderCell tableHCell = new TableHeaderCell();
            tableHCell.Text = header;

            tableHRow.Cells.Add(tableHCell);
        }

        QualifiedCandidate.Rows.Add(tableHRow);

        // Table Rows
        TableRow aNewRow;
        int index = 0;

        foreach (var item in candidateList)
        {
            aNewRow = new TableRow();

            TableCell aNewCell = new TableCell();
            aNewCell.Text = item.FirstName;
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            aNewCell.Text = item.LastName;
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            aNewCell.Text = item.UserEmail;
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            aNewCell.Text = item.Phone;
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            Button viewCoverLetterButton = new Button();
            viewCoverLetterButton.ID = "ViewCoverLetterButton" + index;
            viewCoverLetterButton.Text = "View";
            viewCoverLetterButton.CssClass = "btn btn-outline-primary";
            viewCoverLetterButton.Click += new EventHandler((obj, eArgs) => ViewCoverLetterButton_Click(obj, eArgs, item.UserID, item.CoverLetter));
            aNewCell.Controls.Add(viewCoverLetterButton);
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            Button viewResumeButton = new Button();
            viewResumeButton.ID = "ViewResumeButton" + index;
            viewResumeButton.Text = "View";
            viewResumeButton.CssClass = "btn btn-outline-primary";
            viewResumeButton.Click += new EventHandler((obj, eArgs) => ViewResumeButton_Click(obj, eArgs, item.UserID, item.Resume));
            aNewCell.Controls.Add(viewResumeButton);
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            TextBox DateBox = new TextBox();
            DateBox.TextMode = TextBoxMode.Date;
            DateBox.CssClass = "form-control";
            aNewCell.Controls.Add(DateBox);
            aNewRow.Cells.Add(aNewCell);

            aNewCell = new TableCell();
            Button assignButton = new Button();
            assignButton.ID = "AssignButton" + index;
            assignButton.Text = "Confirm Interview";
            assignButton.CssClass = "btn btn-outline-primary";
            assignButton.Click += new EventHandler((obj, eArgs) => AssignButton_Click(obj, eArgs, item.UserID, DateBox.Text));
            aNewCell.Controls.Add(assignButton);
            aNewRow.Cells.Add(aNewCell);

            QualifiedCandidate.Rows.Add(aNewRow);
            index++;
        }

    }

    protected void ViewCoverLetterButton_Click(object sender, EventArgs e, int userID, string coverLetter)
    {
        string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + userID + "/CoverLetter/" + coverLetter;

        Response.Redirect(path);
    }

    protected void ViewResumeButton_Click(object sender, EventArgs e, int userID, string resume)
    {
        string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + userID + "/Resume/" + resume;

        Response.Redirect(path);
    }

    protected void AssignButton_Click(object sender, EventArgs e, int userID, string date)
    {
        bool confirmation = false;

        int jobPostingID = Convert.ToInt32(Request["JobPostingID"]);
        PRMS controller = new PRMS();
        confirmation = controller.AssignCandidateToJobPosting(userID, jobPostingID, date);

        if (confirmation)
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {

        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CandidateManagement2.aspx");
    }
}