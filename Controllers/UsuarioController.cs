using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SustentacionASPNETCoreMVC.Models;
using SustentacionASPNETCoreMVC.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SustentacionASPNETCoreMVC.Controllers;

public class UsuarioController : Controller
{
    private readonly DBPRUEBAContext _context;

    public UsuarioController(DBPRUEBAContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string buscar)
    {
        var usuarios = from Usuario in _context.Usuarios select Usuario;
        if (!string.IsNullOrEmpty(buscar))
        {
            usuarios = usuarios.Where(s => s.UserName!.Contains(buscar));
        }
        var lista = await usuarios.Include(u => u.OArea).ToListAsync();


        return View(lista);
    }

    public IActionResult Create(int idUsuario)
    {
        ViewData["Areas"] = new SelectList(_context.Areas, "IdArea", "NameArea");

        if (idUsuario != 0)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario != null)
            {
                var usuarioVM = new UsuarioViewModel
                {
                    IdUsuario = (int)usuario.IdUser,
                    Name = usuario.NameComplete,
                    UserName = usuario.UserName,
                    Password = usuario.PasswordUser,
                    IdArea = (int)usuario.IdArea,
                    DateRegister = usuario.DateRegister.Value.ToString("yyyy-MM-dd")

                };

                return View(usuarioVM);
            }
        }

        return View(new UsuarioViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UsuarioViewModel model)
    {
        ViewData["Areas"] = new SelectList(_context.Areas, "IdArea", "NameArea", model.IdArea);

        if (ModelState.IsValid)

        {

            var usuario = new Usuario
            {
                IdUser = (int)model.IdUsuario,
                NameComplete = model.Name,
                IdArea = model.IdArea,
                UserName = model.UserName,
                PasswordUser = model.Password,
                DateRegister = DateTime.Parse(model.DateRegister)
            };
            // Lógica para verificar si el nombre de usuario ya existe en la base de datos
            if (NombreUsuarioExiste(usuario.UserName))
            {
                ModelState.AddModelError("UserName", "El nombre de usuario ya está en uso.");
                return View(model);
            }
            else
            {
                if ((int)model.IdUsuario == 0)
                {
                    _context.Usuarios.Add(usuario);
                }
                else
                {
                    _context.Usuarios.Update(usuario);

                }
            }

            await _context.SaveChangesAsync();

        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int idUsuario)
    {

        Usuario usuario = _context.Usuarios.Where(u => u.IdUser == idUsuario).FirstOrDefault();

        if (usuario == null)
        {
            return NotFound();
        }

        return PartialView("_DeleteUser", usuario);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        // Elimina el usuario de la base de datos
        Usuario usuario = _context.Usuarios.Include(a => a.OArea).Where(u => u.IdUser == id).FirstOrDefault();
        _context.Usuarios.Remove(usuario);
        _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    private bool NombreUsuarioExiste(string userName)
    {
        // Verifica si hay algún usuario en la base de datos con el mismo nombre de usuario
        return _context.Usuarios.Any(u => u.UserName == userName);
    }
}


//public async Task<IActionResult> Details(int id)
//{
//    if (id == null || _context.Usuarios == null)
//    {
//        return NotFound();
//    }

//    var usuario = await _context.Usuarios
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (usuario == null)
//    {
//        return NotFound();
//    }

//    return View(usuario);
//}


