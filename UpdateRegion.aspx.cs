using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateRegion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindDropDowns();
        }
       
    }
    protected void BindDropDowns()
    {
        PRMS controller = new PRMS();

        Region.DataSource = controller.GetRegions();
        Region.DataTextField = "Description";
        Region.DataValueField = "RegionID";
        Region.Items.Insert(0, new ListItem("Select Region...", "0"));
        Region.DataBind();
    }

    protected void RegionUpdateButton1_Click(object sender, EventArgs e)
    {
        bool confirmation = false;
        PRMS controller = new PRMS();
        int regionID = Convert.ToInt32(Region.Text);
        //confirmation = controller.UpdateProfession(UpdateDescription.Text, professionID);
        confirmation = controller.UpdateRegion(UpdateDescription.Text, regionID);
        //confirmation = controller.AddSkillSet(SkillSet.Text, professionID);

        if (confirmation)
        {
            Confirmation.Text = "Region updated successfully.";
        }
        else
        {
            Confirmation.Text = "Error has occurred.";
        }
    }
}