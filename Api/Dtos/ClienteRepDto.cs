namespace Api.Dtos;

public class ClienteRepDto
{
    public string NombreCliente { get; set; }
    public EmpleadoRepDto CodigoEmpleadoRepVentasNavigation { get; set; }
}