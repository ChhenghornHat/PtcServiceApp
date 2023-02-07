using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class SettingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}