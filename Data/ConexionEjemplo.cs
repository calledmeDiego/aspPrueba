using System.Data.SqlClient;

namespace SustentacionASPNETCoreMVC.Data;

public class ConexionEjemplo
{
    private string cadenaSQL;

    public ConexionEjemplo()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        cadenaSQL = builder.GetSection("ConnectionStrings:SQLConnection").Value;
    }

    public string GetCadenaSQL()
    {
        return cadenaSQL;
    }
}
