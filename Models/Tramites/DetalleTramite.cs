using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models.Tramites;

public class DetalleTramite
{
    [Key]
    public int IdDetalleTramite { get; set; }
    public int IdTramite { get; set; }
    public TramiteModel Tramite { get; set; }
    public int IdDocumento { get; set; }
    public Documento Documento { get; set; }

    public int IdCliente { get; set; }
    [ForeignKey(nameof(IdCliente))]
    public Cliente Cliente { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public int IdTipo { get; set; }
    
}
