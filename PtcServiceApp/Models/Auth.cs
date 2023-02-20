using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PtcServiceApp.Models;

[Keyless]
public class Auth
{
    [Key]
    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
}