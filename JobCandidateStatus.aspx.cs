using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Threading;
using System.IO;

public partial class JobCandidateStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
            "First Name", "Last Name", "Email", "Phone", "Cover Letter", "Resume","Status Date", "Status"
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
                viewCoverLetterButton.CssClass = "btn btn-dark";
                viewCoverLetterButton.Click += new EventHandler((obj, eArgs) => ViewCoverLetterButton_Click(obj, eArgs, item.UserID, item.CoverLetter));
                string strPath = Server.MapPath("~");
                string path = strPath + "\\Files\\" + item.UserID + "\\CoverLetter\\" + item.CoverLetter;
                if (!File.Exists(path))
                {
                    viewCoverLetterButton.Enabled = false;
                }
                aNewCell.Controls.Add(viewCoverLetterButton);
                aNewRow.Cells.Add(aNewCell);

                aNewCell = new TableCell();
                Button viewResumeButton = new Button();
                viewResumeButton.ID = "ViewResumeButton" + index;
                viewResumeButton.Text = "View";
                viewResumeButton.CssClass = "btn btn-dark";
                viewResumeButton.Click += new EventHandler((obj, eArgs) => ViewResumeButton_Click(obj, eArgs, item.UserID, item.Resume));
                string path2 = strPath + "\\Files\\" + item.UserID + "\\Resume\\" + item.Resume;
                if (!File.Exists(path2))
                {
                    viewResumeButton.Enabled = false;
                }
                aNewCell.Controls.Add(viewResumeButton);
                aNewRow.Cells.Add(aNewCell);

                aNewCell = new TableCell();
                TextBox DateBox = new TextBox();
                DateBox.TextMode = TextBoxMode.Date;
                DateBox.CssClass = "form-control";
                DateBox.Text = item.StatusDate;
                aNewCell.Controls.Add(DateBox);
                aNewRow.Cells.Add(aNewCell);

                aNewCell = new TableCell();
                DropDownList StatusList = new DropDownList();
                StatusList.ID = "StatusList" + index;
                StatusList.EnableViewState = true;
                StatusList.AutoPostBack = true;
                StatusList.CssClass = "form-control";

                List<String> JobStatus = new List<String>() { "Interviewing", "Joined", "On-Hold", "Rejected", "Selected" };
                StatusList.Items.Insert(0, new ListItem("Interviewing", "Interviewing"));
                StatusList.Items.Insert(1, new ListItem("Joined", "Joined"));
                StatusList.Items.Insert(2, new ListItem("On-Hold", "On-Hold"));
                StatusList.Items.Insert(3, new ListItem("Rejected", "Rejected"));
                StatusList.Items.Insert(4, new ListItem("Selected", "Selected"));
                StatusList.SelectedValue = item.JobStatus;

                StatusList.SelectedIndexChanged += new EventHandler((obj, eArgs) => StatusListSelectedIndexChanged(obj, eArgs, StatusList.SelectedItem.Text, item.UserID, jobPostingID, DateBox.Text, item.StatusDate, StatusList, item.JobStatus));

                aNewCell.Controls.Add(StatusList);

                aNewRow.Cells.Add(aNewCell);

                QualifiedCandidate.Rows.Add(aNewRow);
                index++;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(‘Error occurred while trying to obtain data. Please contact customer support for assistance if this issue persists.’)", true);
        }

    }
    protected void StatusListSelectedIndexChanged(Object sender, EventArgs e, string StatusChange, int UserID, int JobPostingID, string DateChange, string DateCheck, DropDownList RevertList, String RevertValue )
    {
        if (DateChange == DateCheck)
        {
            
            Response.Write("<script language='javascript'>window.alert('You must select a new date for the status change.');</script>");
            RevertList.SelectedValue = RevertValue;
            
        }
        else
        {
            PRMS Controller = new PRMS();
            Controller.ChangeStatus(UserID, JobPostingID, StatusChange, DateChange);
            
        }
        
    }

    protected void ViewCoverLetterButton_Click(object sender, EventArgs e, int userID, string coverLetter)
    {
        try
        {
            string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + userID + "/CoverLetter/" + coverLetter;

            Response.Redirect(path);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(''File does not exist.'')", true);
        }
    }

    protected void ViewResumeButton_Click(object sender, EventArgs e, int userID, string resume)
    {
        try
        {
            string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + "/Files/" + userID + "/Resume/" + resume;

            Response.Redirect(path);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(''File does not exist.'')", true);
        }

    }


    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewJobPosting.aspx");
    }
}
