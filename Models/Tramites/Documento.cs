using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models.Tramites;

public abstract class Documento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDocument { get; set; }
    public string Tramitante { get; set; }
    public string Motivo { get; set; }
    public string FondoDoc { get; set; }
    public string SeccionDoc { get; set; }
    public string DiscriminatorDocumento { get; set; }
    public ICollection<TramiteModel> Tramites { get; set; }
}

//public class DocumentoInvestigador
//{
//    public int IdCarnet { get; set; }
//    public string Nombre { get; set; }
//    public string Leg { get; set; }
//    public int Cuaderno { get; set; }
//    public int Libro { get; set; }
//    public int Seccion { get; set; }
//    public int Anio { get; set; }
//    public string Escribano { get; set; }
//    public string Fondo { get; set; }
//    public int Expediente { get; set; }
//    public int Paqt { get; set; }
//}