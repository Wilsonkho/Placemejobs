using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class JobCandidateStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int jobPostingID = Convert.ToInt32(Request["JobPostingID"]);
        PRMS controller = new PRMS();
        List<User> candidateList = new List<User>();
        candidateList = controller.GetAssignedCandidates(jobPostingID);

        HeaderLabel.Text = "Assigned Candidates for - " + Request["Name"];
        SmallLabel.Text = Request["Description"];
        // Table Headings
        TableHeaderRow tableHRow = new TableHeaderRow();
        List<String> headerList = new List<String>()
        {
            "First Name", "Last Name", "Email", "Phone", "Cover Letter", "Resume", "Status"
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
            
                DropDownList StatusList = new DropDownList();
                StatusList.ID = "StatusList" + index;
                StatusList.EnableViewState = true;
                StatusList.AutoPostBack = true;

            List<String> JobStatus = new List<String>() { "Interviewing", "Joined", "On-Hold", "Rejected", "Selected" };
            //Skillset.Items.Insert(0, new ListItem("Select Skillset...", "0"));
            //StatusList.Items.Insert(0, new ListItem(item.JobStatus, "0"));
            StatusList.Items.Insert(0, new ListItem("Interviewing", "Interviewing"));
            StatusList.Items.Insert(1, new ListItem("Joined", "Joined"));
            StatusList.Items.Insert(2, new ListItem("On-Hold", "On-Hold"));
            StatusList.Items.Insert(3, new ListItem("Rejected", "Rejected"));
            StatusList.Items.Insert(4, new ListItem("Selected", "Selected"));
            StatusList.SelectedValue = item.JobStatus;

            StatusList.SelectedIndexChanged += new EventHandler((obj,eArgs) => StatusListSelectedIndexChanged (obj,eArgs,StatusList.SelectedItem.Text, item.UserID, jobPostingID));
            
                aNewCell.Controls.Add(StatusList);
            
            aNewRow.Cells.Add(aNewCell);

            QualifiedCandidate.Rows.Add(aNewRow);
            index++;
        }

    }
    protected void StatusListSelectedIndexChanged(Object sender, EventArgs e, string StatusChange, int UserID, int JobPostingID)
    {
        //DropDownList ComboBox = (DropDownList)sender;
        //ViewState["ddl_index"] = ComboBox.SelectedValue;
        var status = UserID;
        var status2 = JobPostingID;
        var status3 = StatusChange;
        
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

    protected void AssignButton_Click(object sender, EventArgs e, int userID)
    {
        bool confirmation = false;

        int jobPostingID = Convert.ToInt32(Request["JobPostingID"]);
        PRMS controller = new PRMS();
        confirmation = controller.AssignCandidateToJobPosting(userID, jobPostingID);

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
        Response.Redirect("ViewJobPosting.aspx");
    }
}
