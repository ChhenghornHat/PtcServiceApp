namespace PtcServiceApp.Models;

public class Branch
{
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}