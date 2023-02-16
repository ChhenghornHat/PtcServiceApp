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
    public async Task<IActionResult> GetAllEvent()
    {
        var result = await _ptcServiceDbContext.Eventes.FromSqlRaw("EXEC CrudEvent @Crud = 'Select'").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostEvent(AddEvent objEvn)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync(
            $"EXEC CrudEvent @Crud = 'Insert', @Photo = '{objEvn.Photo}', @Subject = '{objEvn.Subject}', @Description = '{objEvn.Description}', @Active = {objEvn.Active}, @Feature = {objEvn.Feature}");
        return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetEvnById(int id)
    {
        var result = await _ptcServiceDbContext.GetEventByIds.FromSqlRaw($"EXEC CrudEvent @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdateEvn(PostUpdateEvn objEvn)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudEvent @Crud = 'Update', @Photo = '{objEvn.Photo}', @Subject = '{objEvn.Subject}', @Description = '{objEvn.Description}', @Id = {objEvn.EventId}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> EditAtv(EditAtv objAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudEvent @Crud = 'Update', @Active = {objAtv.Active}, @Id = {objAtv.EventId}");
        return Ok(1);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditFt(EditFt objFt)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudEvent @Crud = 'Update', @Feature = {objFt.Feature}, @Id = {objFt.EventId}");
        return Ok(1);
    }
    
}