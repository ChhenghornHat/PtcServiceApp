using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class Customer : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}