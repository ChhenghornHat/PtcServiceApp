using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

namespace PtcServiceApp.Controllers;

public class EmployeeController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public EmployeeController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployee()
    {
        var result = await _ptcServiceDbContext.Employees.FromSqlRaw("EXEC CrudEmployee @Crud = 'Select'").ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetDepartment()
    {
        var result = await _ptcServiceDbContext.GetDepartments.FromSqlRaw("EXEC CrudInfo @InfoName = 'Department'").ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetJobTitle()
    {
        var result = await _ptcServiceDbContext.GetJobTitles.FromSqlRaw("EXEC CrudInfo @InfoName = 'JobTitle'").ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBranch()
    {
        var result = await _ptcServiceDbContext.GetBranches.FromSqlRaw("EXEC CrudInfo @InfoName = 'Branch'").ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRole()
    {
        var result = await _ptcServiceDbContext.GetRoles.FromSqlRaw("EXEC CrudInfo @InfoName = 'Role'").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostEmployee(PostEmployee objEmp)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync(
            $"EXEC CrudEmployee @Crud = 'Insert', @EmployeeCode = '{objEmp.EmployeeCode}', @EmployeeName = '{objEmp.EmployeeName}', @Password = '{objEmp.Password}', @JobId = {objEmp.JobTitleId}, @DepartmentId = {objEmp.DepartmentId}, @BranchId = {objEmp.BranchId}, @RoleId = {objEmp.RoleId}, @Active = {objEmp.Active}");
        return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var result = await _ptcServiceDbContext.GetEmployeeByIds.FromSqlRaw($"EXEC CrudEmployee @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> EditActive(EditActives objAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudEmployee @Crud = 'Update', @Active = {objAtv.Active}, @Id = {objAtv.EmployeeId}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdateEmployee(PostUpdateEmployee objEmp)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudEmployee @Crud = 'Update', @EmployeeCode = '{objEmp.EmployeeCode}', @EmployeeName = '{objEmp.EmployeeName}', @Password = '{objEmp.Password}', @JobId = {objEmp.JobTitleId}, @DepartmentId = {objEmp.DepartmentId}, @BranchId = {objEmp.BranchId}, @RoleId = {objEmp.RoleId}, @Id = {objEmp.EmployeeId}");
        return Ok(1);
    }
}