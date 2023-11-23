namespace Dominio.Entities;

public partial class Pago
{
    public int CodigoCliente { get; set; }

    public string FomaPago { get; set; } = null!;

    public string IdTransaccion { get; set; } = null!;

    public DateOnly FechaPago { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente CodigoClienteNavigation { get; set; } = null!;
}
