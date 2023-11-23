namespace Api.Dtos;

public class PagoDto
{
    public string FomaPago { get; set; } 

    public string IdTransaccion { get; set; } 

    public DateOnly FechaPago { get; set; }

    public decimal Total { get; set; }

}