namespace PtcServiceApp.Models;

public class User
{
    public int UserId { get; set; }
    public string UserCode { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string JobTitle { get; set; }
    public string Department { get; set; }
    public string Branch { get; set; }
    public string Role { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}