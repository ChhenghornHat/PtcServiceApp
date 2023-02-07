using Microsoft.AspNetCore.Mvc;

namespace PtcServiceApp.Controllers;

public class BranchController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}