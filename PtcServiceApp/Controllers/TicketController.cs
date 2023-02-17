using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

namespace PtcServiceApp.Controllers;

public class TicketController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public TicketController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTicket()
    {
        var result = await _ptcServiceDbContext.Tickets.FromSqlRaw("EXEC CrudTicketAdmin @Crud = 'Select'").ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketById(int id)
    {
        var result = await _ptcServiceDbContext.GetTicketByIds.FromSqlRaw($"EXEC CrudTicketAdmin @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> TicketAccept(int id)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudTicket @Crud = 'Update', @StatusId = 2, @Notificate = 'Your ticket was accept', @Id = {id}");
        return Ok(1);
    }
}