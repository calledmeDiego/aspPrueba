namespace SustentacionASPNETCoreMVC.Models.Tramites;

public class DocumentoInvestigador : Documento
{
    public int? IdCarnet { get; set; }
    public int? NumCarnet { get; set; }
    public string Nombre { get; set; }
    public string Leg { get; set; }
    public int? Cuaderno { get; set; }
    public int? Libro { get; set; }
    //public int Seccion { get; set; }
    public int? Anio { get; set; }
    public string Escribano { get; set; }
    //public string FondoDoc{ get; set; }
    public int? Expediente { get; set; }
    public int? Paqt { get; set; }
    
}
