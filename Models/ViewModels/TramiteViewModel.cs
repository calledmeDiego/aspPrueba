using Microsoft.AspNetCore.Mvc.Rendering;
using SustentacionASPNETCoreMVC.Models.Tramites;

namespace SustentacionASPNETCoreMVC.Models.ViewModels;

public class TramiteViewModel
{

    public List<SelectListItem> OListaTipoFormato { get; set; }
    public TramiteModel OTramite { get; set; }
    public Recibo ORecibo { get; set; }
    public DetalleTramiteServicio ODetalleTramiteServicio { get; set; }

    public DocumentoCliente ODocumentoCliente { get; set; }
    public DocumentoInvestigador ODocumentoInvestigador { get; set; }
    public int? IdentificadorCliente { get; set; }
    public List<ServicioTramite> OServicio { get; set; }

    public string Seleccionados { get; set; }
    public List<int> SelectedServiceIds { get; set; } = new List<int>();
    public string Cantidad { get; set; }
    public List<int> Cantidades { get; set; } = new List<int>();

    public string SubtotalString { get; set; }

    public List<decimal> Subtotales { get; set; } = new List<decimal>();
    //public DocumentoInvestigador ODocumentoInvestigador { get; set; }

    //public ServicioTramite OServicio { get; set; }
    //public Cliente OCliente { get; set; }
    //public Usuario OUsuario { get; set; }
    //public Documento ODocumento { get; set; }
}
