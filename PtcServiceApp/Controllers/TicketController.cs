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
        var result = await _ptcServiceDbContext.Tickets.FromSqlRaw("EXEC LiveTicketAdmin").ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketById(int id)
    {
        var result = await _ptcServiceDbContext.GetTicketByIds.FromSqlRaw($"EXEC LiveTicketAdmin @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetTransferDepartment()
    {
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.GetDepartments.FromSqlRaw($"EXEC ShowDepartment @Type = 'Transfer', @DepartmentId = {dpmId}").ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAssignDepartment()
    {
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.GetAssignDepartments.FromSqlRaw($"EXEC ShowDepartment @Type = 'Assign', @DepartmentId = {dpmId}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> TicketAccept(TicketAcceptOrReject objTk)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC AcceptTicket @Crud = 'Insert', @Comments = '{objTk.Comment}', @CreatedById = {empId}, @DepartmentId = {dpmId}, @TicketId = {objTk.TicketId}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> TicketReject(TicketAcceptOrReject objTk)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC RejectTicket @Crud = 'Insert', @Comments = '{objTk.Comment}', @CreatedById = {empId}, @DepartmentId = {dpmId}, @TicketId = {objTk.TicketId}");
        return Ok(1);
    }

    public async Task<IActionResult> TicketAssign(TicketTransferOrAssign objAsn)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");

        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC AssignTicket @Crud = 'Insert', @Comments = '{objAsn.Comment}', @TicketId = {objAsn.TicketId}, @ServiceCallId = {objAsn.ServiceCallId}, @AssignToId = {objAsn.AssignId}, @DepartmentId = {dpmId}, @CreatedById = {empId}");
        return Ok(1);
    }

    // Ticket Admin Report
    public IActionResult AdminTicketReport()
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
    public async Task<IActionResult> GetAdminTicketReport()
    {
        var result = await _ptcServiceDbContext.ReportAdmins.FromSqlRaw("EXEC ReportAdmin").ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAdminTicketReportFilterBy(int statusId, string docDate, string dueDate)
    {
        var result = await _ptcServiceDbContext.ReportAdmins.FromSqlRaw($"EXEC ReportAdmin @StatusId = {statusId}, @DocDate = '{docDate}', @DueDate = '{dueDate}'").ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStatus()
    {
        var result = await _ptcServiceDbContext.GetStatuses.FromSqlRaw("EXEC GetStatus").ToListAsync();
        return Ok(result);
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
    public async Task<IActionResult> TransferTo(TicketTransferOrAssign objTf)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudTransfer @Crud = 'Insert', @Comments = '{objTf.Comment}', @TicketId = {objTf.TicketId}, @DepartmentId = {objTf.DepartmentId}, @CreatedById = {empId}");
        return Ok(1);
    }
    
    [HttpPost]
    public async Task<IActionResult> AssignTo(TicketTransferOrAssign objAs)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC AssignTicket @Crud = 'Insert', @Comments '{objAs.Comment}', @TicketId = {objAs.TicketId}, @ServiceCallId = {objAs.ServiceCallId}, @AssignToId = {objAs.AssignId}, @DepartmentId = {objAs.DepartmentId}, @CreatedById = {empId}");
        return Ok(1);
    }
    
    // Ticket Manager Report
    public IActionResult ManagerTicketReport()
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
    public async Task<IActionResult> GetManagerTicketReportFilterBy(int statusId, string docDate, string dueDate)
    {
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.ReportManagers.FromSqlRaw($"EXEC ReportManager @StatusId = {statusId}, @DepartmentId = {dpmId}, @DocDate = '{docDate}', @DueDate = '{dueDate}'").ToListAsync();
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

    [HttpGet]
    public async Task<IActionResult> GetByUserTicket()
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.UserTickets.FromSqlRaw($"EXEC LiveTicketEmployee @DepartmentId = {dpmId}, @EmployeeId = {empId}").ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _ptcServiceDbContext.GetUserTickByIds.FromSqlRaw($"EXEC LiveTicketAdmin @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CompleteTicket(CompleteTicket objCmp)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CompleteTicket @Comments = '{objCmp.Comment}', @TicketId = {objCmp.TicketId}, @CreatedById = {empId}, @DepartmentId = {dpmId}");
        return Ok(1);
    }
    
    // Ticket User Report
    public IActionResult UserTicketReport()
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
    
    [HttpGet]
    public async Task<IActionResult> GetUserTicketReportFilterBy(string docDate, string dueDate)
    {
        var empId = HttpContext.Session.GetInt32("EmployeeId");
        var dpmId = HttpContext.Session.GetInt32("DepartmentId");
        var result = await _ptcServiceDbContext.ReportUsers.FromSqlRaw($"EXEC ReportEmployee @EmployeeId = {empId}, @DepartmentId = {dpmId}, @DocDate = '{docDate}', @DueDate = '{dueDate}'").ToListAsync();
        return Ok(result);
    }
    // End User
}