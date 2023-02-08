namespace PtcServiceApp.Models;

public class JobTitle
{
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}