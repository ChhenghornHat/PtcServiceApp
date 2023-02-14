using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class Branch
{
    [Key]
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Map { get; set; }
    public int Active { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}

public class PostBranch
{
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Map { get; set; }
    public int Active { get; set; }
}