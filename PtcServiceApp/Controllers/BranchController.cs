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
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudBranch @Crud = 'Insert', @BranchName = '{objBrn.BranchName}', @Phone = '{objBrn.Phone}', @Address = '{objBrn.Address}', @Map = '{objBrn.Map}', @Active = {objBrn.Active}");
        return Ok(1);
    }
}