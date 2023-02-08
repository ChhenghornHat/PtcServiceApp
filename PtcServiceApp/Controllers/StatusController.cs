using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

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
        var status = _ptcServiceDbContext.Statuses.FromSqlRaw("EXEC GetStates").ToList();
        return Ok(status);
    }

    public IActionResult AddStatus(string statusName, int sapId, int closed,int active, int objectId, int customerStatus)
    {
        _ptcServiceDbContext.Database.ExecuteSqlRaw($"AddStatus {statusName}, {sapId}, {closed}, {active}, {objectId}, {customerStatus}");
        return Ok(1);
    }

    // public IActionResult EditStatus(int statusId)
    // {
    //     var status = _ptcServiceDbContext.Statuses.FromSqlRaw("")
    // }
}