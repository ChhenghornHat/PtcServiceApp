using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PtcServiceApp.Models;

[Keyless]
public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Password { get; set; }
    public string JobTitleName { get; set; }
    public string DepartmentName { get; set; }
    public string BranchName { get; set; }
    public string RoleName { get; set; }
    public bool Active { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}