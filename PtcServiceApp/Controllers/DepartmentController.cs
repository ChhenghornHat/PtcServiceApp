using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;

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

    // Fetch all department
    [HttpGet]
    public IActionResult GetDepartments()
    {
        var department = _ptcServiceDbContext.Departments.FromSqlRaw("EXEC Department 'Select'").ToList();

        return Ok(department);
    }
    
    // Add new department
    [HttpPost]
    public IActionResult AddDepartment(string dpm_name, int dpm_sts)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"Department 'Insert', {dpm_name}, {dpm_sts}");
        
        return Ok(1);
    }
    
    // Update status
    [HttpPost]
    public IActionResult UpdateStatus(int status, int id)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"Department 'Update', @Status={status}, ${id}");

        return Ok(1);
    }
}