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
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudDepartment @Crud = 'Insert', @Name = '{objDpm.DepartmentName}', @Active = {objDpm.Active}, @Parent = {objDpm.ParentId}");
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
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudDepartment @Crud =  'Update', @Name = '{objDpm.DepartmentName}', @Parent = {objDpm.ParentId}, @Id = {objDpm.DepartmentId}");
        return Ok(1);
    }
    
    // Post update Status
    public async Task<IActionResult> UpdateStatus(UpdateStatus objSts)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudDepartment @Crud = 'Update', @Active = {objSts.Active}, @Id = {objSts.DepartmentId}");
        return Ok(1);
    }
}