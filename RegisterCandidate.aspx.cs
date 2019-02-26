using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterCandidate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        bool success = false;
        User newCandidate = new User();
        newCandidate.UserEmail = EmailTextBox.Text;
        newCandidate.FirstName = FirstName.Text;
        newCandidate.LastName = LastName.Text;
        newCandidate.Resume = ResumeUpload.PostedFile.FileName;
        newCandidate.CoverLetter = CoverLetterUpload.PostedFile.FileName;

        PRMS controller = new PRMS();
        success = controller.AddCandidate(newCandidate);


        int userID;

        userID = controller.GetUserIDByEmail(EmailTextBox.Text);

        if (ResumeUpload.HasFile)
        {

            string fileExtension = Path.GetExtension(ResumeUpload.PostedFile.FileName);

            if (fileExtension == ".pdf" || fileExtension == ".docx")
            {
                Directory.CreateDirectory(Server.MapPath("~/Files/" + userID + "/Resume/"));

                DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files/" + userID + "/Resume/"));
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo di in directory.GetDirectories())
                {
                    di.Delete(true);
                }

                ResumeUpload.SaveAs(Server.MapPath("~/Files/" + userID + "/" + "Resume/" + ResumeUpload.FileName));
            }
            else
            {
                Msg.Text = "Only .pdf and .docx resume files are accepted.";
            }
        }
        if (CoverLetterUpload.HasFile)
        {

            string fileExtension = Path.GetExtension(CoverLetterUpload.PostedFile.FileName);

            if (fileExtension == ".pdf" || fileExtension == ".docx")
            {
                Directory.CreateDirectory(Server.MapPath("~/Files/" + userID + "/CoverLetter/"));

                DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files/" + userID + "/CoverLetter/"));
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo di in directory.GetDirectories())
                {
                    di.Delete(true);
                }

                ResumeUpload.SaveAs(Server.MapPath("~/Files/" + userID + "/" + "CoverLetter/" + ResumeUpload.FileName));
            }
            else
            {
                Msg.Text = "Only .pdf and .docx cover letter files are accepted.";
            }
        }
    }

}