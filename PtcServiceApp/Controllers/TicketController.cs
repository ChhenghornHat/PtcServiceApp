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
    // Admin
    public IActionResult AdminTicket()
    {
        var roleId = HttpContext.Session.GetInt32("RoleId");
        if (roleId == 1)
        {
            return View();
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
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudProcces @Crud = 'Insert', @Comments = '{objTk.Comment}', @CreatedById = {empId}, @TicketId = {objTk.TicketId}");
        return Ok(1);
    }
    // End Admin
    
    // Manager
    public IActionResult ManagerTicket()
    {
        var roleId = HttpContext.Session.GetInt32("RoleId");
        if (roleId == 1)
        {
            return RedirectToAction("AdminDashboard", "Dashboard");
        }
        else if (roleId == 2)
        {
            return View();
        }
        else if (roleId == 3)
        {
            return RedirectToAction("UserDashboard", "Dashboard");
        }
        else
        {
            return RedirectToAction("Login", "Auth");
        }
    }

    public async Task<IActionResult> GetByManagerTicket()
    {
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.ManagerTickets.FromSqlRaw($"EXEC CrudTicketDepartment @Crud = 'Select', @DepartmentId = {dpmId}").ToListAsync();
        return Ok(result);
    }
    // End Manager
    
    // User
    public IActionResult UserTicket()
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
            return View();
        }
        else
        {
            return RedirectToAction("Login", "Auth");
        }
    }
    // End User
}