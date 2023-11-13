using Microsoft.EntityFrameworkCore;
using SustentacionASPNETCoreMVC.Models;
using System;

namespace SustentacionASPNETCoreMVC.Data;

public class DataAccess
{
    private readonly DBPRUEBAContext _context;
    public DataAccess(DBPRUEBAContext context)
    {
        _context = context;
    }
    //public async Task<List<Usuario>> ListaUsuario()
    //{
        
    //    return await _context.Usuarios.Include(u => u.OArea).ToListAsync();
        
    //}
    public async Task<Usuario> ValidarUsuario(string username, string password)
    {
       return await _context.Usuarios
        .Include(u => u.OArea)
        .FirstOrDefaultAsync(item => item.UserName == username && item.PasswordUser == password);
    }

}
