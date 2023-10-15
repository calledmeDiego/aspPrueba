using Microsoft.AspNetCore.Mvc;
using SustentacionASPNETCoreMVC.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;
 



namespace SustentacionASPNETCoreMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    //private readonly IGenericRepository<AreaModel> _areaRepository;
    //private readonly IGenericRepository<EjemploModel> _userRepository;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        //_areaRepository = areaRepository;
        //_userRepository = userRepository;

    }

    public IActionResult Index()
    {
        return View();
    }

    //[HttpGet]
    //public async Task<IActionResult>  ListaAreas()
    //{
    //    List<AreaModel> _lista = await _areaRepository.ToList();

    //    return StatusCode(StatusCodes.Status200OK, _lista);
    //}

    //[HttpGet]
    //public async Task<IActionResult> ListaUsuarios()
    //{
    //    List<EjemploModel> _lista = await _userRepository.ToList();

    //    return StatusCode(StatusCodes.Status200OK, _lista);
    //}

    //[HttpPost]
    //public async Task<IActionResult>  GuardarUsuarios([FromBody]EjemploModel modelo)
    //{
    //    bool _resultado = await _userRepository.Save(modelo);

    //    if(_resultado)
    //        return StatusCode(StatusCodes.Status200OK, new {
    //            valor = _resultado,
    //            msg = "Ok"
    //        });
    //    else
    //        return StatusCode(StatusCodes.Status500InternalServerError, new {
    //            valor = _resultado,
    //            msg = "error"
    //        });

        
    //}

    //[HttpPut]
    //public async Task<IActionResult>  EditarUsuarios([FromBody]EjemploModel modelo)
    //{
    //    bool _resultado = await _userRepository.Edit(modelo);

    //    if(_resultado)
    //        return StatusCode(StatusCodes.Status200OK, new {
    //            valor = _resultado,
    //            msg = "Ok"
    //        });
    //    else
    //        return StatusCode(StatusCodes.Status500InternalServerError, new {
    //            valor = _resultado,
    //            msg = "error"
    //        });        
    //}

    //[HttpDelete]
    //public async Task<IActionResult>  EliminarUsuarios(int idUser)
    //{
    //    bool _resultado = await _userRepository.Delete(idUser);

    //    if(_resultado)
    //        return StatusCode(StatusCodes.Status200OK, new {
    //            valor = _resultado,
    //            msg = "Ok"
    //        });
    //    else
    //        return StatusCode(StatusCodes.Status500InternalServerError, new {
    //            valor = _resultado,
    //            msg = "error"
    //        });        
    //}



    [Authorize(Roles = "Administración, Recepción")]
    public IActionResult Clientes()
    {
        return View();
    }

    [Authorize(Roles = "Administración, Caja")]
    public IActionResult Tramites()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}