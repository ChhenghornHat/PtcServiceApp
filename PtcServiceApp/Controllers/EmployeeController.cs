using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;

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
}