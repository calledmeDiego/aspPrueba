using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SustentacionASPNETCoreMVC.Data;
using SustentacionASPNETCoreMVC.Models;
using SustentacionASPNETCoreMVC.Models.Tramites;
using SustentacionASPNETCoreMVC.Models.ViewModels;
using System.Data.SqlTypes;
using System.Security.Claims;
using X.PagedList;

namespace SustentacionASPNETCoreMVC.Controllers;

public class TramiteController : Controller
{
    private readonly DBPRUEBAContext _context;

    public TramiteController(DBPRUEBAContext context)
    {
        _context = context;
    }
    private IQueryable<TramiteModel> BuscarTramite(IQueryable<TramiteModel> tramites, string buscar)
    {
        if (!string.IsNullOrEmpty(buscar))
        {
            tramites = tramites.Where(s => s.IdTramite.ToString()!.Contains(buscar));
        }
        return tramites;
    }

    private IQueryable<TramiteModel> AplicarOrdenamiento(IQueryable<TramiteModel> tramites, string ordenActual)
    {
        switch (ordenActual)
        {
            case "FechaDescendente":
                return tramites.OrderByDescending(cliente => cliente.FechaRegistro);

            case "FechaAscendente":
                return tramites.OrderBy(cliente => cliente.FechaRegistro);

            default:
                // Puedes agregar un caso por defecto para manejar otras opciones de ordenamiento
                return tramites;
        }
    }

    public async Task<IActionResult> Index(string buscar, string ordenActual, int? numPag, string filtroActual)
    {
        var tramites = from TramiteModel in _context.Tramites select TramiteModel;

        // Aplicar ordenamiento

        if (buscar != null)
            numPag = 1;
        else
            buscar = filtroActual;
        tramites = BuscarTramite(tramites, buscar);
        ViewData["OrdenActual"] = ordenActual;

        ViewData["FiltroActual"] = buscar;

        //Lógica para realizar filtrado en orden ascendente y descendente
        ViewData["FiltroNombre"] = string.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

        ViewData["FiltroFecha"] = ordenActual == "FechaAscendente" ? "FechaDescendente" : "FechaAscendente";

        tramites = AplicarOrdenamiento(tramites, ordenActual);



        int cantidadRegistros = 6;

        var nuevalista = await Paginacion<TramiteModel>.CrearPaginacion(tramites.Include(u => u.OUsuario).Include(u => u.Cliente).AsNoTracking(), numPag ?? 1, cantidadRegistros);


        return View(nuevalista);

    }

    private async Task<TramiteViewModel> CrearTramiteViewModel(int idUser)
    {
        // Lógica para crear y configurar un objeto TramiteViewModel
        // ...


        TramiteViewModel oTramiteVM = new TramiteViewModel()
        {
            ODocumentoCliente = new DocumentoCliente(),
            ODocumentoInvestigador = new DocumentoInvestigador(),
            OTramite = new TramiteModel()
            {

                IdUsuario = idUser
            },
            ORecibo = new Recibo(),

            ODetalleTramiteServicio = new DetalleTramiteServicio(),
            OListaTipoFormato = await _context.TipoClientes.Select(tipo => new SelectListItem()
            {
                Text = tipo.Descripcion,
                Value = tipo.IdTipoCliente.ToString()
            }).ToListAsync(),
            OServicio = await _context.Servicios.ToListAsync()
        };
        return oTramiteVM;
    }
    public async Task<IActionResult> Create(int idTramite)
    {
        // Crear una instancia de TramiteModel con el documento adecuado


        var userIdString = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
        {
            Console.WriteLine("No se pudo cargar el ID del usuario");
            return RedirectToAction("Error");
        }
        Console.WriteLine("el usuario id es" + userId);

        TramiteViewModel oTramiteVM = await CrearTramiteViewModel(userId);

        ViewData["Direcciones"] = Enum.GetValues(typeof(Direccion))
            .Cast<Direccion>()
            .Take(2)
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            })
            .ToList();


        if (idTramite != 0)
        {
            //oTramiteVM.OTramite = await _context.Tramites
            //.Include(t => t.DetallesTramiteServicios)
            //.Include(t => t.Documento)
            //.FirstOrDefaultAsync(t => t.IdTramite == idTramite);
            //oTramiteVM.OTramite.Documento.DiscriminatorDocumento = "1";
            //oTramiteVM.OTramite = await _context.Tramites.FindAsync(idTramite);
            oTramiteVM.OTramite = await _context.Tramites
           .Include(t => t.DetallesTramiteServicios)
           .Include(t => t.Documento)
           .FirstOrDefaultAsync(t => t.IdTramite == idTramite);
            if (oTramiteVM.OTramite.Documento.DiscriminatorDocumento == "Cliente")
            {
                oTramiteVM.OTramite.Documento.DiscriminatorDocumento = "1";
                var detallesServicio = await _context.DetalleTramiteServicios
        .Where(d => d.IdTramite == idTramite)
        .ToListAsync();
                oTramiteVM.ODocumentoCliente = await _context.DocumentoClientes.FindAsync(oTramiteVM.OTramite.IdDocumento);
                oTramiteVM.OServicio = await _context.Servicios.ToListAsync();
                oTramiteVM.IdentificadorCliente = await _context.Clientes
    .Where(d => d.IdPerson == oTramiteVM.OTramite.IdCliente)
    .Select(c => c.DNI)
    .FirstOrDefaultAsync();
                foreach (var servicio in oTramiteVM.OServicio)
                {
                    servicio.Selected = detallesServicio.Any(d => d.IdServicio == servicio.IdServicio);
                }
            }
            //else if (oTramiteVM.OTramite.Documento.DiscriminatorDocumento == "2")
            //{
            //    oTramiteVM.ODocumentoInvestigador = await _context.DocumentoInvestigadores.FindAsync(oTramiteVM.OTramite.IdDocumento);
            //}
            //oTramiteVM.ORecibo = await _context.Recibos.FindAsync(idTramite);
            //oTramiteVM.ODetalleTramiteServicio.Tramite = await _context.Tramites.FindAsync(idTramite);
            //oTramiteVM. = await _context.Recibos.FindAsync(idTramite);
            //oTramiteVM.OTramite.Documento.DiscriminatorDocumento = "1";

        }
        //Console.WriteLine("Nombre del usuario: " + oTramiteVM.OTramite.OUsuario.Nombre);

        return View(oTramiteVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TramiteViewModel oTramiteVM)
    {
        if (!ModelState.IsValid)
        {
            TempData["Mensaje"] = "Error en el Registro del Trámite";
            return RedirectToAction(nameof(Index));
        }

        try
        {
            // Cargar entidades relacionadas
            oTramiteVM.OTramite.OUsuario = await _context.Usuarios.FindAsync(oTramiteVM.OTramite.IdUsuario);
            oTramiteVM.OTramite.Cliente = await _context.Clientes.FindAsync(oTramiteVM.OTramite.IdCliente);

            // Configurar el tipo de documento
            if (oTramiteVM.OTramite.Documento.DiscriminatorDocumento == "1")
            {
                oTramiteVM.OTramite.Documento = oTramiteVM.ODocumentoCliente;
                ConvertirArray(oTramiteVM, oTramiteVM.Seleccionados, oTramiteVM.Cantidad, oTramiteVM.SubtotalString);
            }
            else if (oTramiteVM.OTramite.Documento.DiscriminatorDocumento == "2")
            {
                oTramiteVM.OTramite.Documento = oTramiteVM.ODocumentoInvestigador;
            }

            // Determinar si se guarda o actualiza
            if (oTramiteVM.OTramite.IdTramite == 0)
            {
                // Nuevo Trámite
                _context.Tramites.Add(oTramiteVM.OTramite);
                _context.Recibos.Add(oTramiteVM.ORecibo);

                if (oTramiteVM.OTramite.Documento.DiscriminatorDocumento == "Cliente")
                    _context.DocumentoClientes.Add(oTramiteVM.ODocumentoCliente);

                else if (oTramiteVM.OTramite.Documento.DiscriminatorDocumento == "Investigador")
                    _context.DocumentoInvestigadores.Add(oTramiteVM.ODocumentoInvestigador);

                // Agregar detalles del servicio
                for (int i = 0; i < oTramiteVM.SelectedServiceIds.Count; i++)
                {
                    var serviceDetail = CrearDetalleTramiteServicio(oTramiteVM, i);
                    _context.DetalleTramiteServicios.Add(serviceDetail);
                }

                TempData["Mensaje"] = "Trámite registrado exitosamente.";
            }
            else
            {
                // Actualizar Trámite existente
                _context.Tramites.Update(oTramiteVM.OTramite);
                TempData["Mensaje"] = "Trámite actualizado exitosamente.";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {

            TempData["Mensaje"] = $"Error en el Registro del Trámite {ex}";
            return RedirectToAction("Error");
        }
    }
    private DetalleTramiteServicio CrearDetalleTramiteServicio(TramiteViewModel oTramiteVM, int index)
    {
        int serviceId = oTramiteVM.SelectedServiceIds[index];
        int cantidad = oTramiteVM.Cantidades[index];
        decimal subtotal = oTramiteVM.Subtotales[index];
        oTramiteVM.ODetalleTramiteServicio = new DetalleTramiteServicio()
        {
            Tramite = oTramiteVM.OTramite,
            Recibo = oTramiteVM.ORecibo,
            IdServicio = serviceId,
            Cantidad = cantidad,
            Subtotal = subtotal
        };
        return oTramiteVM.ODetalleTramiteServicio;
    }

    [HttpPost]
    public async Task<IActionResult> ActualizarContenedor(List<int> serviciosSeleccionados)
    {
        var servicios = await _context.Servicios.Where(s => serviciosSeleccionados.Contains(s.IdServicio)).ToListAsync();

        return PartialView("~/Views/Tramite/_ActualizadorContenedor.cshtml", servicios);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarCliente(string numeroIdentificacion)
    {
        // Lógica para buscar el cliente por número de identificación
        var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.DNI.ToString() == numeroIdentificacion);

        if (cliente != null)
        {
            return Json(new { success = true, nombre = cliente.Nombre, apellido = cliente.Apellido, id = cliente.IdPerson });
        }

        return Json(new { success = false, message = "Cliente no encontrado." });
    }

    private void ConvertirArray(TramiteViewModel tramiteViewModel, string servicio, string cantidad, string subtotal)
    {
        string[] substrings = servicio.Split(' ');

        foreach (string substring in substrings)
        {
            if (int.TryParse(substring, out int numero))
            {
                tramiteViewModel.SelectedServiceIds.Add(numero);
            }
            else
            {
                Console.WriteLine($"No se pudo convertir '{substring}' a un número entero.");
            }
        }

        string[] cantidadesString = cantidad.Split(' ');

        foreach (var quantity in cantidadesString)
        {
            if (int.TryParse(quantity, out int numero))

                tramiteViewModel.Cantidades.Add(numero);

        }

        string[] preciosString = subtotal.Split(' ');

        foreach (var sub in preciosString)
        {
            if (decimal.TryParse(sub, out decimal numero))

                tramiteViewModel.Subtotales.Add(numero);

        }

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        TramiteModel tramite = await _context.Tramites
    .Include(t => t.DetallesTramiteServicios)
        .ThenInclude(d => d.Recibo)
    .Include(t => t.Documento)
    .Where(u => u.IdTramite == id)
    .FirstOrDefaultAsync();

        if (tramite != null)
        {
            _context.DetalleTramiteServicios.RemoveRange(tramite.DetallesTramiteServicios);
            _context.Remove(tramite.Documento);
            _context.Tramites.Remove(tramite);

            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Trámite eliminado exitosamente.";
        }
        else
        {
            TempData["Mensaje"] = "Trámite no encontrado.";
        }

        return RedirectToAction("Index");
    }

    //[HttpPost]
    //public IActionResult ActualizarSelectedServiceIds(List<int> selectedServiceIds)
    //{
    //    // Aquí puedes realizar alguna lógica adicional si es necesario
    //    var tramiteViewModel = new TramiteViewModel
    //    {
    //        SelectedServiceIds = selectedServiceIds
    //    };

    //    // Puedes almacenar este viewModel en TempData si necesitas acceder a él después de redirigir
    //    TempData["TramiteViewModel"] = tramiteViewModel.SelectedServiceIds;

    //    // Puedes devolver algún resultado si es necesario
    //    return Json(new { success = true });
    //}
    //[HttpPost]
    //public IActionResult CapturadorCheckboxes(List<int> serviciosSeleccionados)
    //{
    //    // Almacena los valores seleccionados en alguna variable de clase o en el TempData
    //    ActualizarContenedor(serviciosSeleccionados);
    //    return Json(new { Success = true });
    //}

    //[HttpPost]
    //public IActionResult CapturarValores(List<int> serviciosSeleccionados)
    //{
    //    var servicios = _context.Servicios.Where(s => serviciosSeleccionados.Contains(s.IdServicio)).ToList();
    //    return Json(servicios);
    //}

    //[HttpPost]
    //public IActionResult MostrarVistaParcial(List<int> serviciosSeleccionados)
    //{
    //    //var viewModel = new TramiteViewModel
    //    //{
    //    //    // Puedes asignar otros valores al ViewModel si es necesario
    //    //    SelectedServiceIds = serviciosSeleccionados
    //    //}
    //    var servicios = _context.Servicios.Where(s => serviciosSeleccionados.Contains(s.IdServicio)).ToList();

    //    return PartialView("~/Views/Tramite/_ActualizadorContenedor.cshtml", servicios);
    //}
    //[HttpGet]
    //public IActionResult VerificarClientePorDNI(string dni)
    //{
    //    // Lógica para verificar la existencia del cliente por su DNI
    //    bool clienteEncontrado = TuLogicaParaVerificarDNI(dni);

    //    ViewBag.ClienteEncontrado = clienteEncontrado;
    //    return PartialView("_MensajeCliente");
    //}

    //private bool TuLogicaParaVerificarDNI(string dni)
    //{
    //    // Implementa tu lógica real aquí
    //    // Retorna true si el cliente se encuentra, false si no se encuentra
    //    // Puedes realizar la consulta a la base de datos u otro método de verificación
    //    return /* Lógica de verificación */;
    //}
}

