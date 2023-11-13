using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models.Tramites;

public class ServicioTramite
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdServicio { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public bool Selected { get; set; }
    public ICollection<DetalleTramiteServicio> DetallesTramiteServicios { get; set; }
}
