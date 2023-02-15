using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

namespace PtcServiceApp.Controllers;

public class BranchController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public BranchController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBranch()
    {
        var result = await _ptcServiceDbContext.Branches.FromSqlRaw($"EXEC CrudBranch @Crud = 'Select'").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostBranch(PostBranch objBrn)
    {
        await _ptcServiceDbContext.Database
            .ExecuteSqlRawAsync($"EXEC CrudBranch @Crud = 'Insert', @BranchName = '{objBrn.BranchName}', @Phone = '{objBrn.Phone}', @Address = '{objBrn.Address}', @Map = '{objBrn.Map}', @Active = {objBrn.Active}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> PostBrandUpdate(PostBranchUpdate objBrn)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudBranch @Crud = 'Update', @BranchName = '{objBrn.BranchName}', @Phone = '{objBrn.Phone}', @Address = '{objBrn.Address}', @Map = '{objBrn.Map}', @Id = {objBrn.BranchId}");
        return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetBrandById(int id)
    {
        var result = await _ptcServiceDbContext.GetBranchByIds
            .FromSqlRaw($"EXEC CrudBranch @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateActive(UpdateActive objAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync(
            $"EXEC CrudBranch @Crud = 'Update', @Active = {objAtv.Active}, @Id = {objAtv.BranchId}");
        return Ok(1);
    }
}