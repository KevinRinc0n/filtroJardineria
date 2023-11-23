namespace Api.Dtos;

public class EmpleadoRepDto
{
    public string Nombre { get; set; } 
    public string Apellido1 { get; set; } 
    public OficinaCiuDto CodigoOficinaNavigation { get; set; }
}
