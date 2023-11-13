using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models.Tramites;

public class DetalleTramiteServicio
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? IdDetalle { get; set; }
    public int? IdTramite { get; set; }
    public int? IdServicio { get; set; }
    public int? IdRecibo { get; set; }
    [ForeignKey(nameof(IdTramite))]
    public TramiteModel Tramite { get; set; }
    [ForeignKey(nameof(IdServicio))]
    public ServicioTramite Servicio { get; set; }
    [ForeignKey(nameof(IdRecibo))]
    public Recibo Recibo { get; set; }
    public int? Cantidad { get; set; }
    public decimal? Subtotal { get; set; }
    //public bool? Seleccionado { get; set; }
}
