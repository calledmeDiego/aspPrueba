using Microsoft.AspNetCore.Mvc.Rendering;

namespace SustentacionASPNETCoreMVC.Models.ViewModels;

public class ClienteViewModel
{
    public Cliente OCliente { get; set; }
    public List<SelectListItem> OListaTipoClientes { get; set; }

}
