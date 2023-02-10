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

    // Fetch all department
    [HttpGet]
    public IActionResult GetDepartments()
    {
        var result = _ptcServiceDbContext.Departments.FromSqlRaw("EXEC CrudDepartment @Crud = 'Select'").ToList();
        return Ok(result);
    }
    
    // Add new department
    [HttpPost]
    public IActionResult AddDepartment(string departmentName, int active)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"EXEC CrudDepartment @Crud = 'Insert', @Name =  {departmentName}, @Active =  {active}");
        return Ok(1);
    }
    
    // Update status
    [HttpPost]
    public IActionResult UpdateStatus(int id, int active)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"EXEC CrudDepartment @Crud = 'Update', @Active={active}, @Id=${id}");
        return Ok(1);
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        var result = _ptcServiceDbContext.Departments.FromSqlRaw($"EXEC CrudDepartment @Crud = 'Select', @Id={id}").ToList();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult UpdateName(string name, int id)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"EXEC CrudDepartment @Crud = 'Update', @Name={name}, @Id={id}");
        return Ok(1);
    }
}