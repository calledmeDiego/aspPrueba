using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SustentacionASPNETCoreMVC.Models;

namespace SustentacionASPNETCoreMVC.Models.ViewModels;

[Index(nameof(UserName), IsUnique = true)]
public class UsuarioViewModel
{
    public int IdUsuario { get; set; }

    [Required]
    [Display(Name = "Nombre Completo")]
    public string Name { get; set; }


    
    [Required]
    [MaxLength(10)]
    [MinLength(3)]
    [Display(Name = "Nombre de Usuario")]
    public string UserName { get; set; }

    [Required]
    [MaxLength(10)]  
    [MinLength(3)]
    [Display(Name = "Contraseña")]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Fecha de Registro")]
    public string DateRegister { get; set; }

    [Required]
    [Display(Name = "Área")]
    public int IdArea { get; set; }
    
}
