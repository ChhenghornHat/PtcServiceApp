namespace PtcServiceApp.Models;

public class Ticket
{
    public int TicketId { get; set; }
    public int TicketCode { get; set; }
    public string Indidual { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Letitude { get; set; }
    public string Longitude { get; set; }
    public string UserAddress { get; set; }
    public string StatusName { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}