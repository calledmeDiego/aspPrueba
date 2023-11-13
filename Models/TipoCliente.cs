using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SustentacionASPNETCoreMVC.Models.Tramites;

namespace SustentacionASPNETCoreMVC.Models;

public class TipoCliente
{
    public TipoCliente()
    {
        Clientes = new HashSet<Cliente>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTipoCliente { get; set; }
    [MaxLength(20)]
    public string Descripcion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; }
    



}
