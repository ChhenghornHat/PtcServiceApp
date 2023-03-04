using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Models;

namespace PtcServiceApp.Data;

public class PtcServiceDbContext : DbContext
{
    public PtcServiceDbContext(DbContextOptions<PtcServiceDbContext> options) : base(options) { }

    // Status Db
    public DbSet<Status> Statuses { get; set; }
    public DbSet<GetStatus> GetStatuses { get; set; }
    public DbSet<GetStsById> GetStsByIds { get; set; }
    // End
    
    // Department Db
    public DbSet<Department> Departments { get; set; }
    public DbSet<GetParent> GetParents { get; set; }
    public DbSet<GetDepartmentById> GetDepartmentByIds { get; set; }
    // End
    
    // Branch Db
    public DbSet<Branch> Branches { get; set; }
    public DbSet<GetBranchById> GetBranchByIds { get; set; }
    // End
    
    // Employee Db
    public DbSet<Employee> Employees { get; set; }
    public DbSet<GetDepartment> GetDepartments { get; set; }
    public DbSet<GetJobTitle> GetJobTitles { get; set; }
    public DbSet<GetBranch> GetBranches { get; set; }
    public DbSet<GetRole> GetRoles { get; set; }
    public DbSet<GetEmployeeById> GetEmployeeByIds { get; set; }
    // End

    public DbSet<User> Users { get; set; }
    
    //User Role Db
    public DbSet<Role> Roles { get; set; }
    public DbSet<GetUserRoleById> GetUserRoleByIds { get; set; }

    // JobTitle Db
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<GetJobTitleById> GetJobTitleByIds { get; set; }
    
    // Ticket Db
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<ReportAdmin> ReportAdmins { get; set; }
    public DbSet<ManagerTicket> ManagerTickets { get; set; }
    public DbSet<GetTicketById> GetTicketByIds { get; set; }
    // End

    // Event Db
    public DbSet<Event> Eventes { get; set; }
    public DbSet<GetEventById> GetEventByIds { get; set; }
    // End
    
    // User Db
    public DbSet<Auth> Auths { get; set; }
}