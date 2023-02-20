using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;
using PtcServiceApp.Models;

namespace PtcServiceApp.Controllers;

public class UserRoleController : Controller
{
    private readonly PtcServiceDbContext _ptcServiceDbContext;

    public UserRoleController(PtcServiceDbContext ptcServiceDbContext)
    {
        _ptcServiceDbContext = ptcServiceDbContext;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserRole()
    {
        var result = await _ptcServiceDbContext.Roles.FromSqlRaw("EXEC CrudRole @Crud = 'Select'").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostUserRole(PostRole objRl)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudRole @Crud = 'Insert', @RoleName = '{objRl.RoleName}', @Active = {objRl.Active}");
        return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserRoleById(int id)
    {
        var result = await _ptcServiceDbContext.GetUserRoleByIds.FromSqlRaw($"EXEC CrudRole @Crud = 'Select', @Id = {id}").ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdateRole(PostUpdateRole objRl)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudRole @Crud = 'Update', @RoleName = '{objRl.RoleName}', @Id = {objRl.RoleId}");
        return Ok(1);
    }

    [HttpPost]
    public async Task<IActionResult> EditActive(EditRoleActive objAtv)
    {
        await _ptcServiceDbContext.Database.ExecuteSqlRawAsync($"EXEC CrudRole @Crud = 'Update', @Active = {objAtv.Active}, @Id = {objAtv.RoleId}");
        return Ok(1);
    }
}