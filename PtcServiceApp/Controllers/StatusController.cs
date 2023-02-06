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
        var status = _ptcServiceDbContext.Statuses.FromSqlRaw("EXEC GetStatuses").ToList();
        return Ok(status);
    }
}