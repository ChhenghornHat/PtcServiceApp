using Microsoft.EntityFrameworkCore;
using PtcServiceApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PtcServiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PtcServiceConnection")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
});
// builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddRouting(options => options.LowercaseUrls = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");
    // pattern: "{controller=Dashboard}/{action=AdminDashboard}/{id?}");
    // pattern: "{controller=ManagerDashboard}/{action=Dashboard}/{id?}");

app.Run();
