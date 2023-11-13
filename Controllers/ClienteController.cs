using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SustentacionASPNETCoreMVC.Data;
using SustentacionASPNETCoreMVC.Models;
using SustentacionASPNETCoreMVC.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SustentacionASPNETCoreMVC.Controllers;


public class ClienteController : Controller
{
    private readonly DBPRUEBAContext _context;

    public ClienteController(DBPRUEBAContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string buscar, string ordenActual, int? numPag, string filtroActual)
    {
        // Variable que almacena los registros de la tabla cliente
        var clientes = from Cliente in _context.Clientes select Cliente;

        // CONDICIONAL QUE BUSCA POSICIONAR AL NÚMERO DE PÁGINA COMO UNO SI LA VARIABLE BUSCAR CONTIENE UN DATO
        if (buscar != null)
            numPag = 1;
        else
            buscar = filtroActual;

        // Condicional para buscar cliente por su número de DNI
        if (!string.IsNullOrEmpty(buscar))
            clientes = clientes.Where(s => s.DNI.ToString()!.Contains(buscar));


        ViewData["OrdenActual"] = ordenActual; 

        ViewData["FiltroActual"] = buscar;    


        //Lógica para realizar filtrado en orden ascendente y descendente
        ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

        ViewData["FiltroFecha"] = ordenActual == "FechaAscendente" ? "FechaDescendente" : "FechaAscendente";


        switch (ordenActual)
        {
            case "NombreDescendente":
                clientes = clientes.OrderByDescending(cliente => cliente.Nombre);
                break;

            case "FechaDescendente":
                clientes = clientes.OrderByDescending(cliente => cliente.FechaRegistro);
                break;

            case "FechaAscendente":
                clientes = clientes.OrderBy(cliente => cliente.FechaRegistro);
                break;

            default:
                clientes = clientes.OrderBy(cliente => cliente.Nombre);
                break;
                
        }
        //var lista = await clientes.Include(u => u.OCliente).ToListAsync();

        //CANTIDAD DE REGISTROS POR PÁGINA
        int cantidadRegistros = 6;

        // VARIABLE QUE LISTARA LOS REGISTROS EN LA VISTA
        var nuevalista = await Paginacion<Cliente>.CrearPaginacion(clientes.Include(u => u.OCliente).AsNoTracking(), numPag ?? 1, cantidadRegistros);

        // RETORNARA A LA VISTA INDEX JUNTO A LA VARIABLE
        return View(nuevalista);
    }

    public async Task<IActionResult> Create(int idCliente)
    {
        ViewData["TipoClientes"] = new SelectList(_context.TipoClientes, "IdTipoCliente", "Descripcion");
        ClienteViewModel oClienteVM = new ClienteViewModel()
        {
            OCliente = new Cliente(),
            OListaTipoClientes = _context.TipoClientes.Select(tipo => new SelectListItem()
            {
                Text = tipo.Descripcion,
                Value = tipo.IdTipoCliente.ToString()
            }).ToList()
        };

        if (idCliente != 0)
        {
            oClienteVM.OCliente = await _context.Clientes.FindAsync(idCliente);
        }
        return View(oClienteVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClienteViewModel oClienteVM)
    {
        if (ModelState.IsValid)
        {
            // Lógica para verificar si el nombre de usuario ya existe en la base de datos

            if (NombreClienteExiste(oClienteVM.OCliente.DNI.ToString()) && oClienteVM.OCliente.IdPerson == 0)
            {
                ModelState.AddModelError("UserName", "El nombre de usuario ya está en uso.");
                return View(oClienteVM);
            }
            if (oClienteVM.OCliente.Extranjero
                )
            {
                // Lógica para el caso de extranjero
                oClienteVM.OCliente.TipoDocumento = "Pasaporte";
            }
            else
            {
                // Lógica para el caso de no extranjero
                oClienteVM.OCliente.TipoDocumento = "DNI";
            }

            if ((int)oClienteVM.OCliente.IdPerson == 0)
            {
                _context.Clientes.Add(oClienteVM.OCliente);
                TempData["Mensaje"] = "Cliente registrado exitosamente.";
                
            }
            else
            {
                _context.Clientes.Update(oClienteVM.OCliente);
                TempData["Mensaje"] = "Cliente actualizado exitosamente.";
            }
            await _context.SaveChangesAsync();
            // Después de guardar, muestra SweetAlert
            
           

        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Elimina el usuario de la base de datos
        Cliente cliente = await _context.Clientes.Where(u => u.IdPerson == id).FirstOrDefaultAsync();
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        TempData["Mensaje"] = "Cliente eliminado exitosamente.";
        return RedirectToAction("Index");
    }

    private bool NombreClienteExiste(string dni)
    {
        // Verifica si hay algún usuario en la base de datos con el mismo nombre de usuario
        return _context.Clientes.Any(u => u.DNI.ToString() == dni);
    }

}








//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create(UsuarioViewModel model)
//{
//    ViewData["Areas"] = new SelectList(_context.Areas, "IdArea", "NameArea", model.IdArea);

//    if (ModelState.IsValid)

//    {

//        var usuario = new Usuario
//        {
//            IdPerson = model.IdUsuario,
//            Nombre = model.Name,
//            IdArea = model.IdArea,
//            UserName = model.UserName,
//            PasswordUser = model.Password,
//            FechaRegistro = DateTime.Parse(model.DateRegister)
//        };
//        // Lógica para verificar si el nombre de usuario ya existe en la base de datos
//        if (NombreUsuarioExiste(usuario.UserName) && model.IdUsuario == 0)
//        {
//            ModelState.AddModelError("UserName", "El nombre de usuario ya está en uso.");
//            return View(model);
//        }
//        else
//        {
//            if ((int)model.IdUsuario == 0)
//            {
//                _context.Usuarios.Add(usuario);
//            }
//            else
//            {
//                _context.Usuarios.Update(usuario);

//            }
//        }
//        await _context.SaveChangesAsync();
//    }
//    return RedirectToAction(nameof(Index));
//}



