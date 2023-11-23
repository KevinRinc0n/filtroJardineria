namespace Api.Dtos;

public class EmpleadoRep2Dto
{
    public string Nombre { get; set; } 
    public string Apellido1 { get; set; } 
    public OficinaTelDto CodigoOficinaNavigation { get; set; }
}