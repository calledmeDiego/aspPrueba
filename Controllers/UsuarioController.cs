using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SustentacionASPNETCoreMVC.Data;
using SustentacionASPNETCoreMVC.Models;
using SustentacionASPNETCoreMVC.Models.Tramites;
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

    public async Task<IActionResult> Index(string buscar, string ordenActual, int? numPag, string filtroActual)
    {
        var usuarios = from Usuario in _context.Usuarios select Usuario;
        
        

        if (buscar != null)
            numPag = 1;
        else
            buscar = filtroActual;

        if (!string.IsNullOrEmpty(buscar))
            usuarios = usuarios.Where(s => s.UserName!.Contains(buscar));

        ViewData["OrdenActual"] = ordenActual;

        ViewData["FiltroActual"] = buscar;

        //Lógica para realizar filtrado en orden ascendente y descendente
        ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

        ViewData["FiltroFecha"] = ordenActual == "FechaAscendente" ? "FechaDescendente" : "FechaAscendente";


        switch (ordenActual)
        {
            case "NombreDescendente":
                usuarios = usuarios.OrderByDescending(cliente => cliente.Nombre);
                break;

            case "FechaDescendente":
                usuarios = usuarios.OrderByDescending(cliente => cliente.FechaRegistro);
                break;

            case "FechaAscendente":
                usuarios = usuarios.OrderBy(cliente => cliente.FechaRegistro);
                break;

            default:
                usuarios = usuarios.OrderBy(cliente => cliente.Nombre);
                break;

        }
        //var lista = await clientes.Include(u => u.OCliente).ToListAsync();

        //CANTIDAD DE REGISTROS POR PÁGINA
        int cantidadRegistros = 6;

        var nuevalista = await Paginacion<Usuario>.CrearPaginacion(usuarios.Include(u => u.OArea).AsNoTracking(), numPag ?? 1, cantidadRegistros);

        // RETORNARA A LA VISTA INDEX JUNTO A LA VARIABLE
        return View(nuevalista);

        //var lista = await usuarios.Include(u => u.OArea).ToListAsync();

        //return View(lista);
    }

    public async Task<IActionResult> Create(int idUsuario)
    {
        ViewData["Areas"] = new SelectList( _context.Areas, "IdArea", "NameArea");

        UsuarioViewModel oUsuarioVM = new UsuarioViewModel()
        {
            OUsuario = new Usuario(),
            OListaArea =await _context.Areas.Select(area => new SelectListItem()
            {
                Text = area.NameArea,
                Value = area.IdArea.ToString()
            }).ToListAsync()
        };
        var direcciones = Enum.GetValues(typeof(Direccion))
                             .Cast<Direccion>()
                             .Select(e => new SelectListItem
                             {
                                 Value = ((int)e).ToString(),
                                 Text = e.ToString()
                             })
                             .ToList();

        ViewBag.Direcciones = direcciones;

        if (idUsuario != 0)
        {
            oUsuarioVM.OUsuario = await _context.Usuarios.FindAsync(idUsuario);
        }
        return View(oUsuarioVM);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UsuarioViewModel model)
    {      
        if (ModelState.IsValid)
        {
            // Lógica para verificar si el nombre de usuario ya existe en la base de datos
            if (NombreUsuarioExiste(model.OUsuario.UserName) && model.OUsuario.IdPerson == 0)
            {
                ModelState.AddModelError("UserName", "El nombre de usuario ya está en uso.");
                return View(model);
            }

            if (model.OUsuario.IdPerson == 0)
            {
                _context.Usuarios.Add(model.OUsuario);
            }
            else
            {
                _context.Usuarios.Update(model.OUsuario);
            }

            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Elimina el usuario de la base de datos
        Usuario usuario =await _context.Usuarios.Include(a => a.OArea).Where(u => u.IdPerson == id).FirstOrDefaultAsync();
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
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


