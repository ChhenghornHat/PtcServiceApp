using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class Event
{
    [Key]
    public int EventId { get; set; }
    public byte[] Photo { get; set; }
    public string Description { get; set; }
    public string Subject { set; get; }
    public int Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}