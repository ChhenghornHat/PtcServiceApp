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
        var roleId = HttpContext.Session.GetInt32("RoleId");
        if (roleId == 1)
        {
            return RedirectToAction("AdminDashboard", "Dashboard");
        }
        else if (roleId == 2)
        {
            return RedirectToAction("ManagerDashboard", "Dashboard");
        }
        else if (roleId == 3)
        {
            return RedirectToAction("UserDashboard", "Dashboard");
        }
        else
        {
            return RedirectToAction("Login", "Auth");
        }
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
    public async Task<IActionResult> TicketAccept(TicketAccept objTk)
    {
        var roleId = HttpContext.Session.GetInt32("RoleId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudProcces @Crud = 'Insert', @Comments = '{objTk.Comment}' @CreatedById = {roleId}, @TicketId = {objTk.TicketId}");
        return Ok(1);
    }
}