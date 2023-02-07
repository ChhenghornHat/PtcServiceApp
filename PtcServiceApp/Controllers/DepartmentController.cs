using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class Department : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}