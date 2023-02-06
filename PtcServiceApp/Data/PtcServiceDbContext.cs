using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Models;

namespace PtcServiceApp.Data;

public class PtcServiceDbContext : DbContext
{
    public PtcServiceDbContext(DbContextOptions<PtcServiceDbContext> options) : base(options) { }

     public DbSet<Status> Statuses { get; set; }
    //public DbSet<LiveTicket> LiveTickets { get; set; }
}