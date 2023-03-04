using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PtcServiceApp.Models;

[Keyless]
public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    public int No { get; set; }
    public int TicketCode { get; set; }
    public int StatusId { get; set; }
    public string Name { get; set; }
    public string CreatedDate { get; set; }
}

[Keyless]
public class ReportAdmin
{
    public int No { get; set; }
    public int TicketCode { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public int StatusId { get; set; }
    public string CreatedDate { get; set; }
}

[Keyless]
public class GetTicketById
{
    [Key]
    public int TicketId { get; set; }
    public int TicketCode { get; set; }
    public string CreatedByName { get; set; }
    public string Indidual { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public string UserAddress { get; set; }
    public string Photo { get; set; }
    public int StatusId { get; set; }
    public string CreatedDate { get; set; }
}

[Keyless]
public class TicketAcceptOrReject
{
    [Key]
    public int TicketId { get; set; }
    public string Comment { get; set; }
}

// Manger Ticket
[Keyless]
public class ManagerTicket
{
    [Key]
    public int TicketId { get; set; }
    public Int64 No { get; set; }
    public int TicketCode { get; set; }
    public string Username { get; set; }
    public string Subject { get; set; }
    public int StatusId { get; set; }
    public string CreatedDate { get; set; }
}

[Keyless]
public class TicketTransferOrAssign
{
    [Key]
    public int TicketId { get; set; }
    public string Comment { get; set; }
    public int DepartmentId { get; set; }
    public int ServiceCallId { get; set; }
    public int AssignId { get; set; }
}