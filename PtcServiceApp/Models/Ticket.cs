namespace PtcServiceApp.Models;

public class Ticket
{
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public string TicketCode { get; set; }
    public string Description { get; set; }
    public int PhotoId { get; set; }
    public int BranchId { get; set; }
    public string Lat { get; set; }
    public string Long { get; set; }
    public string Address { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public int StatusId { get; set; }
    public string StatusName { get; set; }
}