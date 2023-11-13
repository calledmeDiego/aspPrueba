using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models.Tramites;

//public int IdTipoCliente { get; set; }
//[Required(ErrorMessage = "Por favor, seleccione un tipo de formato.")]
//[ForeignKey(nameof(IdTipoCliente))]
//public virtual TipoCliente TipoCliente { get; set; }

//public int? IdService { get; set; }
//[ForeignKey(nameof(IdService))]
//public virtual ServicioTramite Services { get; set; }
public class TramiteModel
{
    public TramiteModel()
    {
        // Puedes elegir DocumentoCliente o DocumentoInvestigador según tus necesidades
        Documento = new DocumentoCliente();
        FechaFinalizado = DateTime.Now;
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTramite { get; set; }
    public int? IdUsuario { get; set; }
    [ForeignKey(nameof(IdUsuario))]
    public virtual Usuario OUsuario { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? FechaRegistro { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? FechaFinalizado { get; set; }
    public string TipoTramite { get; set; }
    
    public ICollection<DetalleTramiteServicio> DetallesTramiteServicios { get; set; }

    //public string Cliente { get; set; }
    public int? IdCliente { get; set; }
    //[Required(ErrorMessage = "Por favor, seleccione un cliente.")]
    [ForeignKey(nameof(IdCliente))]
    public virtual Cliente Cliente { get; set; }

    
    public int? IdDocumento { get; set; }
    [ForeignKey(nameof(IdDocumento))]
    public Documento Documento { get; set; }

    // Propiedades de navegación
    public virtual bool EsInvestigador { get; set; }

    public bool TratamientoDatos { get; set; }
    public EstadoTramite Estado { get; set; }
    public int CantidadServicios { get; set; }
    
}
//public ICollection<ServicioTramite> TramiteServicios { get; set; }
public enum EstadoTramite
{
    Atendido,
    Por_Entregar,
    Finalizado,
    Incompleto
}

public enum TipoTramite
{
    Histórico,
    Intermedio
}