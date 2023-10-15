using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SustentacionASPNETCoreMVC.Models;

namespace SustentacionASPNETCoreMVC.Controllers;

public class AreaController : Controller
{

    private readonly DBPRUEBAContext _context;

    public AreaController(DBPRUEBAContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Areas.ToListAsync());
    }
}
