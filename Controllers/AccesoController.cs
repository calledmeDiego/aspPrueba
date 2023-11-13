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
    private readonly DataAccess _dataAccess;

    public AccesoController(DBPRUEBAContext context, DataAccess dataAccess)
    {
        _context = context;
        _dataAccess = dataAccess;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Usuario _usuario)
    {
        
        var usuario = await _dataAccess.ValidarUsuario(_usuario.UserName, _usuario.PasswordUser);
        if (usuario != null)
        {
            // Almacena el ID del usuario en la sesión antes de redirigirlo
            HttpContext.Session.SetString("UserId", usuario.IdPerson.ToString());

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("UserName", usuario.UserName),
                new Claim(ClaimTypes.Role, usuario.OArea.NameArea)
            };

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
