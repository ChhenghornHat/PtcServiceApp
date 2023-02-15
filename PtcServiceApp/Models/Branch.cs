using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PtcServiceApp.Models;

[Keyless]
public class Branch
{
    [Key]
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Map { get; set; }
    public bool Active { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}

[Keyless]
public class PostBranch
{
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Map { get; set; }
    public int Active { get; set; }
}

[Keyless]
public class PostBranchUpdate
{
    [Key]
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Map { get; set; }
}

[Keyless]
public class GetBranchById
{
    [Key]
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Map { get; set; }
}

[Keyless]
public class UpdateActive
{
    [Key]
    public int BranchId { get; set; }
    public int Active { get; set; }
}