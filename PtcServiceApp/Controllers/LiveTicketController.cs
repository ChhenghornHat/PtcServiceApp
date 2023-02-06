using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;

namespace PtcServiceApp.Controllers;

public class LiveTicketController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public LiveTicketController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    // [HttpGet]
    // public IActionResult GetLiveTicket()
    // {
    //     var liveTicket = _ptcServiceDbContext.LiveTickets.FromSqlRaw("EXEC GetLiveTickets").ToList();
    //     return Ok(liveTicket);
    // }
}