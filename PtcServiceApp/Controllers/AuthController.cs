using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;

namespace PtcServiceApp.Controllers;

public class AuthController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public AuthController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }

    // GET
    public IActionResult Login()
    {
        var roleId = HttpContext.Session.GetInt32("RoleId");
        if (roleId == 1)
        {
            return RedirectToAction("ManagerDashboard", "Dashboard");
        }
        else if (roleId == 2)
        {
            return RedirectToAction("ManagerDashboard", "Dashboard");
        }
        else if (roleId == 3)
        {
            return RedirectToAction("UserDashboard", "Dashboard");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> PostLogin(string empCode, string password)
    {
        var result = await _ptcServiceDbContext.Auths.FromSqlRaw($"EXEC CrudLogin @Crud = 'Select', @EmployeeCode = '{empCode}', @Password = '{password}'").ToListAsync();

        foreach (var item in result)
        {
            HttpContext.Session.SetInt32("EmployeeId", item.EmployeeId);
            HttpContext.Session.SetInt32("DepartmentId", item.DepartmentId);
            HttpContext.Session.SetInt32("RoleId", item.RoleId);
        }
        
        return Ok(result);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("EmployeeId");
        HttpContext.Session.Remove("RoleId");
        return RedirectToAction("Login", "Auth");
    }
}