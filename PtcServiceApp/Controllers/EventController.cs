using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PtcServiceApp.Data;

namespace PtcServiceApp.Controllers;

public class EventController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public EventController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetEvent()
    {
        var result = _ptcServiceDbContext.Events.FromSqlRaw("EXEC CrudEvent @Crud = 'Select'");
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddEvent(string photo, string subject, string description, int active)
    {
        byte[] image = Convert.FromBase64String(photo);
        _ptcServiceDbContext.Database.ExecuteSqlRaw(
            $"EXEC CrudEvent @Crud = 'Insert', @Subject = {subject}, @Description = {description}, @Active = {active}, @Photo = {BitConverter.ToString(image)}");
        return Ok(1);
    }
    
}