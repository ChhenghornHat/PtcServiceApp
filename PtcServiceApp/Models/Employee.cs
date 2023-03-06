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

[Keyless]
public class GetDepartment
{
    [Key]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}

[Keyless]
public class GetAssignDepartment
{
    [Key]
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
}

[Keyless]
public class GetJobTitle
{
    [Key]
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; }
}

[Keyless]
public class GetBranch
{
    [Key]
    public int BranchId { get; set; }
    public string BranchName { get; set; }
}

[Keyless]
public class GetRole
{
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }
}

[Keyless]
public class PostEmployee
{
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Password { get; set; }
    public string DepartmentId { get; set; }
    public string JobTitleId { get; set; }
    public string BranchId { get; set; }
    public string RoleId { get; set; }
    public int Active { get; set; }
}

[Keyless]
public class GetEmployeeById
{
    [Key]
    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Password { get; set; }
    public int DepartmentId { get; set; }
    public int JobTitleId { get; set; }
    public int BranchId { get; set; }
    public int RoleId { get; set; }
}

[Keyless]
public class PostUpdateEmployee
{
    [Key]
    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Password { get; set; }
    public int DepartmentId { get; set; }
    public int JobTitleId { get; set; }
    public int BranchId { get; set; }
    public int RoleId { get; set; }
}

[Keyless]
public class EditActives
{
    [Key]
    public int EmployeeId { get; set; }
    public int Active { get; set; }
}