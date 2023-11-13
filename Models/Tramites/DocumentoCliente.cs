using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models.Tramites;

public class DocumentoCliente : Documento
{
    public string EscrituraPersona { get; set; }
    public string OtorgamientoPersona { get; set; }
    public string FavorecimientoPersona { get; set; }
    public DateTime? DiaSuscrito { get; set; }
    public string ExNotario { get; set; }

    public string Aclaramiento { get; set; }
    //public string FondoDoc { get; set; }
    //public string SeccionDoc { get; set; }
    public string SerieDoc { get; set; }
    public string NombreApe { get; set; }

    public DateTime? FechaFD { get; set; }
    public string Provincia { get; set; }
    public string Distrito { get; set; }

    //public List<DocumentoInvestigador> ODocumentoInvestigador { get; set; }
    public int IdTipoTramite { get; set; }
    [ForeignKey(nameof(IdTipoTramite))]
    public TipoTramite? TipoTramite { get; set; }
}
