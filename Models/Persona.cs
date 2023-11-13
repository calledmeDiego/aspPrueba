using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SustentacionASPNETCoreMVC.Models;

public class Persona
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPerson { get; set; }

    [MaxLength(30)]
    public string Nombre { get; set; }

    [MaxLength(30)]
    public string Apellido { get; set; }

    [Range(10000000, 99999999, ErrorMessage = "El número debe tener 8 dígitos.") ]
    public int DNI { get; set; }

    [Range(100000000, 999999999, ErrorMessage = "El número debe tener 9 dígitos.")]
    public int Cellphone { get; set; }

    [MaxLength(30)]
    public string Domicilio { get; set; }

    [MaxLength(30)]
    public string EmailAddress { get; set; }

 
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaNacimiento { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaRegistro { get; set; }
    [MaxLength(20)]
    public string Cargo { get; set; }
}
