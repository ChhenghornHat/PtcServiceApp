using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;

namespace PtcServiceApp.Controllers;

public class StatusController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;
    
    public StatusController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetStatuses()
    {
        var status = _ptcServiceDbContext.Statuses.FromSqlRaw("EXEC CrudStatus @Crud = 'Select'").ToList();
        return Ok(status);
    }

    [HttpPost]
    public IActionResult AddStatus(string statusName, int sapId, int isClose, int isActive, int customerStatus)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"EXEC CrudStatus @Crud = 'Insert', @StatusName = {statusName}, @SapId = {sapId}, @IsClosed = {isClose}, @IsActive = {isActive}, @CustomerStatus = {customerStatus}");
        return Ok(1);
    }

    [HttpPost]
    public IActionResult UpdateIsClosed(int id, int isClosed)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"EXEC CrudStatus @Crud = 'Update', @IsClosed = {isClosed}, @Id = {id}");
        return Ok(1);
    }
    
    [HttpPost]
    public IActionResult UpdateIsActive(int id, int isActive)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"EXEC CrudStatus @Crud = 'Update', @IsActive = {isActive}, @Id = {id}");
        return Ok(1);
    }
    
    [HttpPost]
    public IActionResult UpdateCustomer(int id, int customerStatus)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"EXEC CrudStatus @Crud = 'Update', @CustomerStatus = {customerStatus}, @Id = {id}");
        return Ok(1);
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        var result = _ptcServiceDbContext.Statuses.FromSqlRaw($"EXEC CrudStatus @Crud = 'Select', StatusId @Id = {id}").ToList();
        return Ok(result);
    }
}