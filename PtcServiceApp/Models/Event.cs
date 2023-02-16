using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class Event
{
    [Key]
    public int EventId { get; set; }
    public string Photo { get; set; }
    public string Description { get; set; }
    public string Subject { set; get; }
    public bool Active { get; set; }
    public bool Feature { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}

public class AddEvent
{
    public string Photo { get; set; }
    public string Description { get; set; }
    public string Subject { set; get; }
    public int Active { get; set; }
    public int Feature { get; set; }
}

public class PostUpdateEvn
{
    [Key]
    public int EventId { get; set; }
    public string Photo { get; set; }
    public string Subject { set; get; }
    public string Description { get; set; }
}

public class EditAtv
{
    [Key]
    public int EventId { get; set; }
    public int Active { get; set; }
}

public class EditFt
{
    [Key]
    public int EventId { get; set; }
    public int Feature { get; set; }
}

public class GetEventById
{
    [Key]
    public int EventId { get; set; }
    public string Photo { get; set; }
    public string Description { get; set; }
    public string Subject { set; get; }
}