using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

namespace PtcServiceApp.Controllers;

public class JobTitleController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public JobTitleController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobTitle()
    {
        var result = await _ptcServiceDbContext.JobTitles.FromSqlRaw("EXEC CrudJobTitle @Crud = 'Select'").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostJobTitle(PostJobTitle objJtl)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudJobTitle @Crud = 'Insert', @JobTitleName = '{objJtl.JobTitleName}', @Active = {objJtl.Active}");
        return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetJobTitleById(int id)
    {
        var result = await _ptcServiceDbContext.GetJobTitleByIds.FromSqlRaw($"EXEC CrudJobTitle @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdateJobTitle(PostUpdateJobTitle objTtl)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudJobTitle @Crud = 'Update', @JobTitleName = '{objTtl.JobTitleName}', @Id = {objTtl.JobTitleId}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> EditActive(EditJtlActive objAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync(
            $"EXEC CrudJobTitle @Crud = 'Update', @Active = {objAtv.Active}, @Id = {objAtv.JobTitleId}");
        return Ok(1);
    }
}