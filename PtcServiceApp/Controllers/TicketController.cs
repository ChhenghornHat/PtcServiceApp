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
        var result = await _ptcServiceDbContext.GetTicketByIds.FromSqlRaw($"EXEC LiveTicketManager @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetSelectDepartment()
    {
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.GetDepartments.FromSqlRaw($"EXEC CrudInfo @InfoName = 'TransferDepartment', @DepartmentId = {dpmId}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> TicketAccept(TicketAccept objTk)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC AcceptTicket @Crud = 'Insert', @Comments = '{objTk.Comment}', @CreatedById = {empId}, @DepartmentId = {dpmId}, @TicketId = {objTk.TicketId}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> TicketReject(TicketReject objTk)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC RejectTicket @Crud = 'Insert', @Comments = '{objTk.Comment}', @CreatedById = {empId}, @DepartmentId = {dpmId}, @TicketId = {objTk.TicketId}");
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

    [HttpGet]
    public async Task<IActionResult> GetByManagerTicket()
    {
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.ManagerTickets.FromSqlRaw($"EXEC LiveTicketManager @DepartmentId = {dpmId}").ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetManagerTicketById(int id)
    {
        var result = await _ptcServiceDbContext.GetTicketByIds.FromSqlRaw($"EXEC LiveTicketAdmin @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> TransferTo(TransferTo objTf)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudTransfer @Crud = 'Insert', @Comments = '{objTf.Comment}', @TicketId = {objTf.TicketId}, @DepartmentId = {objTf.EmployeeId}, @CreatedById = {empId}");
        return Ok(1);
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