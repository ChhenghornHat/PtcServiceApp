using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

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
    public async Task<IActionResult> GetEvents()
    {
        var result = await _ptcServiceDbContext.Eventes.FromSqlRaw("EXEC CrudEvent @Crud = 'Select'").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostEvent(AddEvent objEvent)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync(
            $"EXEC CrudEvent @Crud = 'Insert', @Photo = '{objEvent.Photo}', @Subject = '{objEvent.Subject}', @Description = '{objEvent.Description}', @Active = {objEvent.Active}, @Feature = {objEvent.Feature}");
        return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetEvnById(int id)
    {
        var result = await _ptcServiceDbContext.GetEventByIds.FromSqlRaw($"EXEC CrudEvent @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }
}