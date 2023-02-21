using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PtcServiceApp.Models;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public bool Active { get; set; }
    public bool ShowTicket { get; set; }
    public string ParentName { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}

public class GetParent
{
    [Key]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}

public class PostDepartment
{
    public string DepartmentName { get; set; }
    public int Active { get; set; }
    public int ShowTicket { get; set; }
    public int ParentId { get; set; }
}

[Keyless]
public class UpdateDepartment
{
    [Key]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int ParentId { get; set; }
}

[Keyless]
public class GetDepartmentById
{
    [Key]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int ParentId { get; set; }
}

[Keyless]
public class EditDpmStatus
{
    [Key]
    public int DepartmentId { get; set; }
    public int Active { get; set; }
}

[Keyless]
public class EditDpmTicket
{
    [Key]
    public int DepartmentId { get; set; }
    public int ShowTicket { get; set; }
}