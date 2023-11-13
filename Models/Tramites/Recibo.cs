using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models.Tramites;

public class Recibo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRecibo { get; set; }
    public int? IdCliente { get; set; }
    
    [ForeignKey(nameof(IdCliente))]
    public virtual Cliente Cliente { get; set; }
    public int NumRecibo { get; set; }
    public DateTime FechaEmision { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; }
}
