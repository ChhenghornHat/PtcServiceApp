using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult AdminDashboard()
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
    
    public IActionResult ManagerDashboard()
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
    
    public IActionResult UserDashboard()
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
}