using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PtcServiceApp.Models;

[Keyless]
public class Status
{
    [Key]
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public int SapId { get; set; }
    public bool Closed { get; set; }
    public bool Active { get; set; }
    public bool CustomerActive { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}

[Keyless]
public class GetStatus
{
    [Key]
    public int StatusId { get; set; }
    public string StatusName { get; set; }
}

[Keyless]
public class PostStatus
{
    public string StatusName { get; set; }
    public string Color { get; set; }
    public int SapId { get; set; }
    public int Closed { get; set; }
    public int Active { get; set; }
    public int CustomerActive { get; set; }
}

[Keyless]
public class EditClose
{
    [Key]
    public int StatusId { get; set; }
    public int Closed { get; set; }
}

[Keyless]
public class EditActive
{
    [Key]
    public int StatusId { get; set; }
    public int Active { get; set; }
}

[Keyless]
public class EditCtmActive
{
    [Key]
    public int StatusId { get; set; }
    public int CustomerActive { get; set; }
}

[Keyless]
public class GetStsById
{
    [Key]
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public int SapId { get; set; }
}

[Keyless]
public class PostUpdateSts
{
    [Key]
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public int SapId { get; set; }
}