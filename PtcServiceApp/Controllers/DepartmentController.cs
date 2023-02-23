using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

namespace PtcServiceApp.Controllers;

public class DepartmentController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;
    
    public DepartmentController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    // Fetch all data from database
    public IActionResult GetAllDepartment()
    {
        var result = _ptcServiceDbContext.Departments.FromSqlRaw("EXEC CrudDepartment @Crud = 'Select'").ToList();
        return Ok(result);
    }
    
    // Fetch parent
    public IActionResult GetParent()
    {
        var result = _ptcServiceDbContext.GetParents.FromSqlRaw("EXEC CrudDepartment @Crud = 'Select', @Parent = 1").ToList();
        return Ok(result);
    }

    //Post data to database
    public async Task<IActionResult> PostDepartment(PostDepartment objDpm)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudDepartment @Crud = 'Insert', @DepartmentName = '{objDpm.DepartmentName}', @Active = {objDpm.Active}, @Parent = {objDpm.ParentId}");
        return Ok(1);
    }
    
    //Get data by id to text field
    public async Task<IActionResult> GetDpmById(int id)
    {
        var result = await _ptcServiceDbContext.GetDepartmentByIds.FromSqlRaw($"EXEC CrudDepartment @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }
    
    // Post update data
    public async Task<IActionResult> PostUpdateDepartment(UpdateDepartment objDpm)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudDepartment @Crud =  'Update', @DepartmentName = '{objDpm.DepartmentName}', @Parent = {objDpm.ParentId}, @Id = {objDpm.DepartmentId}");
        return Ok(1);
    }

    public async Task<IActionResult> EditDpmActive(EditDpmStatus objAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudDepartment @Crud = 'Update', @Active = {objAtv.Active}, @Id = {objAtv.DepartmentId}");
        return Ok(1);
    }

    public async Task<IActionResult> EditDpmTicket(EditDpmTicket objTk)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudDepartment @Crud = 'Update', @ShowTicket = {objTk.ShowTicket}, @Id = {objTk.DepartmentId}");
        return Ok(1);
    }
}