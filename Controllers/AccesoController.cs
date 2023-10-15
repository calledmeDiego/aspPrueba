using Microsoft.AspNetCore.Mvc;
using SustentacionASPNETCoreMVC.Data;
using SustentacionASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SustentacionASPNETCoreMVC.Controllers;


public class AccesoController : Controller
{
    private readonly DBPRUEBAContext _context;
    public AccesoController(DBPRUEBAContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Usuario _usuario)
    {
        DataAccess data = new DataAccess(_context);

        var usuario = data.ValidarUsuario(_usuario.UserName, _usuario.PasswordUser);
        if (usuario != null)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.NameComplete),
                 new Claim("UserName", usuario.UserName)

            };


            foreach (var area in _context.Areas.ToList())
            {
                claims.Add(new Claim(ClaimTypes.Role, area.NameArea));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();
        }
    }
    public async Task<IActionResult> Salir()
    {

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Acceso");
    }
}
