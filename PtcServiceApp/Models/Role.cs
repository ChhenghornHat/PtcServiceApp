namespace PtcServiceApp.Models;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}