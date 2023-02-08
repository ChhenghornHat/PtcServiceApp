namespace PtcServiceApp.Models;

public class User
{
    public int UserId { get; set; }
    public string UserCode { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int JobTitleId { get; set; }
    public int DepartmentId { get; set; }
    public int BranchId { get; set; }
    public int RoleId { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}