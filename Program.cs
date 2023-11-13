using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SustentacionASPNETCoreMVC.Data;
using SustentacionASPNETCoreMVC.Models;
using X.PagedList.Mvc.Core;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBPRUEBAContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});
//builder.Services.AddScoped<IGenericRepository<AreaModel>,AreaRepository>();
//builder.Services.AddScoped<IGenericRepository<EjemploModel>,UsuarioRepository>();

builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Acceso/Index";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    option.AccessDeniedPath = "/Home/Privacy";  
});
builder.Services.AddTransient<DataAccess>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DBPRUEBAContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();    

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();
    