using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SustentacionASPNETCoreMVC.Models;

public class Cliente : Persona
{
    [MaxLength(30)]
    public string Ciudad { get; set; }

    [MaxLength(30)]
    public string Distrito { get; set; }

    [MaxLength(30)]
    public string Provincia { get; set; }

    [MaxLength(30)]
    public string Departamento { get; set; }

    [MaxLength(30)]
    public string País { get; set; }

    public bool Extranjero { get; set; }

    [MaxLength(10)]
    public string Carnet { get; set; }

    public string TipoDocumento { get; set; }

    [Required(ErrorMessage = "Por favor, seleccione un tipo de cliente.")]
    public int? IdTipoCliente { get; set; }

    [ForeignKey(nameof(IdTipoCliente))]
    public virtual TipoCliente OCliente { get; set; }
}
