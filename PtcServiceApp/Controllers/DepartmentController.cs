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
        var result = _ptcServiceDbContext.Departments.FromSqlRaw("EXEC CrudDepartment @Crud = 'Select'").ToList();
        return Ok(result);
    }
    
    // Add new department
    [HttpPost]
    public IActionResult AddDepartment(string departmentName, int active)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"CrudDepartment 'Insert', {departmentName}, {active}");
        return Ok(1);
    }
    
    // Update status
    [HttpPost]
    public IActionResult UpdateStatus(int id, int active)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"CrudDepartment 'Update', @Active={active}, @Id=${id}");
        return Ok(1);
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        var department = _ptcServiceDbContext.Departments.FromSqlRaw($"CrudDepartment 'Select' @id={id}").ToList();
        return Ok(department);
    }

    [HttpPost]
    public IActionResult UpdateName(string name, int id)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"CrudDepartment 'Update', @Name={name}, @id={id}");

        return Ok(1);
    }
}