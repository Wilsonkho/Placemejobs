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
        TableHeaderRow ResultsTHRow = new TableHeaderRow();

        List<String> HeaderList = new List<String>()
        {
            "Header1","Header2","Header3"
        };

        foreach (string header in HeaderList)
        {
            TableHeaderCell ResultsTHCell = new TableHeaderCell();
            ResultsTHCell.Text = header;

            ResultsTHRow.Cells.Add(ResultsTHCell);
        }

        Results.Rows.Add(ResultsTHRow);
    }
}