using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class JobTitle
{
    [Key]
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; }
    public bool Active { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}

public class PostJobTitle
{
    public string JobTitleName { get; set; }
    public int Active { get; set; }
}

public class GetJobTitleById
{
    [Key]
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; }
}

public class PostUpdateJobTitle
{
    [Key]
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; }
}

public class EditJtlActive
{
    [Key]
    public int JobTitleId { get; set; }
    public int Active { get; set; }
}