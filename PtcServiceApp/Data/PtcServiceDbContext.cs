using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Models;

namespace PtcServiceApp.Data;

public class PtcServiceDbContext : DbContext
{
    public PtcServiceDbContext(DbContextOptions<PtcServiceDbContext> options) : base(options) { }

    // Status Db
    public DbSet<Status> Statuses { get; set; }
    public DbSet<EditClose> EditCloses { get; set; }
    public DbSet<EditActive> EditActive { get; set; }
    public DbSet<EditCtmActive> EditCtmActive { get; set; }
    public DbSet<GetStsById> GetStsByIds { get; set; }
    public DbSet<PostUpdateSts> PostUpdateSts { get; set; }
    // End
    
    // Department Db
    public DbSet<Department> Departments { get; set; }
    public DbSet<GetParent> GetParents { get; set; }
    public DbSet<GetDepartmentById> GetDepartmentByIds { get; set; }
    public DbSet<UpdateDepartment> UpdateDepartments { get; set; }
    public DbSet<UpdateStatus> UpdateStatuses { get; set; }
    // End
    
    // Branch Db
    public DbSet<Branch> Branches { get; set; }
    public DbSet<PostBranch> PostBranches { get; set; }
    public DbSet<GetBranchById> GetBranchByIds { get; set; }
    public DbSet<PostBranchUpdate> PostBranchUpdates { get; set; }
    public DbSet<UpdateActive> UpdateActives { get; set; }
    // End
    
    // Employee Db
    public DbSet<Employee> Employees { get; set; }
    public DbSet<GetDepartment> GetDepartments { get; set; }
    public DbSet<GetJobTitle> GetJobTitles { get; set; }
    public DbSet<GetBranch> GetBranches { get; set; }
    public DbSet<GetRole> GetRoles { get; set; }
    public DbSet<PostEmployee> PostEmployees { get; set; }
    public DbSet<GetEmployeeById> GetEmployeeByIds { get; set; }
    public DbSet<PostUpdateEmployee> PostUpdateEmployees { get; set; }
    // End

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    
    // Event Db
    public DbSet<Event> Eventes { get; set; }
    public DbSet<GetEventById> GetEventByIds { get; set; }
    // End
}