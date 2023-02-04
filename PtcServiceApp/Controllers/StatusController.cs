using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class StatusController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}