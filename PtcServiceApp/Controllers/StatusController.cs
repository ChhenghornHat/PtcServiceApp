using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

namespace PtcServiceApp.Controllers;

public class StatusController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;
    
    public StatusController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStatus()
    {
        var status = await _ptcServiceDbContext.Statuses.FromSqlRaw("EXEC CrudStatus @Crud = 'Select'").ToListAsync();
        return Ok(status);
    }

    [HttpPost]
    public async Task<IActionResult> PostStatus(PostStatus objSts)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudStatus @Crud = 'Insert', @StatusName = '{objSts.StatusName}', @SapId = {objSts.SapId}, @Closed = {objSts.Closed}, @Active = {objSts.Active}, @CustomerActive = {objSts.CustomerActive}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> EditClosed(EditClose objCls)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudStatus @Crud = 'Update', @Closed = {objCls.Closed}, @Id = {objCls.StatusId}");
        return Ok(1);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditActive(EditActive objAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudStatus @Crud = 'Update', @Active = {objAtv.Active}, @Id = {objAtv.StatusId}");
        return Ok(1);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditCtmActive(EditCtmActive objCtmAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudStatus @Crud = 'Update', @CustomerActive = {objCtmAtv.CustomerActive}, @Id = {objCtmAtv.StatusId}");
        return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetStsById(int id)
    {
        var result = await _ptcServiceDbContext.GetStsByIds.FromSqlRaw($"EXEC CrudStatus @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdateSts(PostUpdateSts objSts)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudStatus @Crud = 'Update', @StatusName = '{objSts.StatusName}', @SapId = {objSts.SapId}, @Id = {objSts.StatusId}");
        return Ok(1);
    }
}