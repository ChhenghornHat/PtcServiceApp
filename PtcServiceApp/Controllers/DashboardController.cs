using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult AdminDashboard()
    {
        return View();
    }
}