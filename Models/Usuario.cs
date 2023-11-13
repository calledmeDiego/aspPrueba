using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using SustentacionASPNETCoreMVC.Models.Tramites;

namespace SustentacionASPNETCoreMVC.Models;


public class Usuario : Persona
{

    [Required]
    [MaxLength(10)]
    [MinLength(3)]
    [Display(Name = "Nombre de Usuario")]
    public string UserName { get; set; }
    [Required]
    [MaxLength(10)]
    [MinLength(3)]
    [Display(Name = "Contraseña")]
    public string PasswordUser { get; set; }

    [Display(Name = "Área")]
    public int? IdArea { get; set; }

    [ForeignKey(nameof(IdArea))]
    public virtual Area OArea { get; set; }
    public virtual ICollection<TramiteModel> Tramites { get; set; }

    public string Direccion { get; set; }

}

public enum Direccion
{
    Intermedio,
    Historico,
    Ambos
}
