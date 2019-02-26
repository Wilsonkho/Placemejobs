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
        int userid = 26;
        if (ResumeUpload.HasFile)
        {

            string fileExtension = Path.GetExtension(ResumeUpload.PostedFile.FileName);

            if (fileExtension == ".pdf" || fileExtension == ".docx")
            {
                Directory.CreateDirectory(Server.MapPath("~/Files/" + userid + "/Resume/"));

                DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files/" + userid + "/Resume/"));
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo di in directory.GetDirectories())
                {
                    di.Delete(true);
                }

                ResumeUpload.SaveAs(Server.MapPath("~/Files/" + userid + "/" + "Resume/" + ResumeUpload.FileName));

                //Send file to database
                bool confirmation = false;
                PRMS controller = new PRMS();
                string resume = ResumeUpload.PostedFile.FileName;
                confirmation = controller.UploadResume(resume);

                if (confirmation)
                {
                    Msg.Text = "Successfully submitted a resume.";
                }
                else
                {
                    Msg.Text = "Error uploading resume. Please contact customer support for assistance.";
                }
            }
            else
            {
                Msg.Text = "Only .pdf and .docx resume files are accepted.";
            }
        }
    }

}