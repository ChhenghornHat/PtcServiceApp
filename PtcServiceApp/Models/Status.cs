using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class Status
{
    [Key]
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public int SapId { get; set; }
    public int IsClosed { get; set; }
    public int IsActive { get; set; }
    public int Object { get; set; }
    public int CustomerStatus { get; set; }
}