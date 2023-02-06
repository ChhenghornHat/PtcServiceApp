using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class LiveTicket
{
    [Key]
    public int TicketId { get; set; }
    public int TicketCode { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.Now;
    public string Descriptiion { get; set; }
    public string Image { get; set; }
    public string Location { get; set; }
    public string UserAddress { get; set; }
    public string Branch { get; set; }
    public string StatusCode { get; set; }
    public string StatusName { get; set; }
    public string Assign { get; set; }
    public string ServiceCode { get; set; }
}