using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Models;

namespace PtcServiceApp.Data;

public class PtcServiceDbContext : DbContext
{
    public PtcServiceDbContext(DbContextOptions<PtcServiceDbContext> options) : base(options) { }

    public DbSet<Status> Statuses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<GetParent> GetParents { get; set; }
    public DbSet<GetDepartmentById> GetDepartmentByIds { get; set; }
    public DbSet<UpdateDepartment> UpdateDepartments { get; set; }
    public DbSet<UpdateStatus> UpdateStatuses { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<PostBranch> PostBranches { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Event> Eventes { get; set; }
    public DbSet<GetEventById> GetEventByIds { get; set; }
}