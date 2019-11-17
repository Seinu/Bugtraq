namespace bugtraq.API.Models
{
  public class BugList
  {
    public int Id { get; set; }
    public string ReportedBy { get; set; }
    public string SubmitDate { get; set; }
    public string Category { get; set; }
    public string BugName { get; set; }
    public string BugSummary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string AssignedTo { get; set; }
    public string LastUpdate { get; set; }
  }
}