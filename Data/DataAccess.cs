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
    public List<Usuario> ListaUsuario()
    {
        

        var usuarios = _context.Usuarios.Include(u => u.OArea).ToList();
        return usuarios;
        

       
    }
    public Usuario ValidarUsuario(string username, string password)
    {
        return ListaUsuario().Where(item => item.UserName == username && item.PasswordUser == password).FirstOrDefault();
    }

}
