using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class User : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}