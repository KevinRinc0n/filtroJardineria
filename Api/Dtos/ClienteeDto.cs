namespace Api.Dtos;

public class ClienteeDto
{
    public string NombreCliente { get; set; } 
    public EmpleadoDto CodigoEmpleadoRepVentasNavigation { get; set; }
}