using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JobPosting
/// </summary>
public class JobPosting
{
    public int JobPostingID { get; set; }
    public string EmployerPhone { get; set; }
    public DateTime Date { get; set; }
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public int RegionID { get; set; }
    public int ProfessionID { get; set; }
    public List<int> Skillsets { get; set; }
}