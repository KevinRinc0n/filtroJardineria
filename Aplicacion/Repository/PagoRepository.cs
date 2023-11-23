using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;


namespace Aplicacion.Repository;

public class PagoRepository : GenericRepository<Pago>, IPago
{
    private readonly jardineriaFiltroContext _context;

    public PagoRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pago>> paypal2008()
    {
        var paypal2008 = await _context.Pagos
        .Where(p => p.FechaPago.Year == 2008 && p.FomaPago == "Paypal")
        .OrderByDescending(p => p.Total)
        .ToListAsync();

        return paypal2008;
    }

    public async Task<IEnumerable<string>> formasPago()
    {
        var formasPago = await _context.Pagos
            .Select(p => p.FomaPago)
            .Distinct()
            .ToListAsync();

        return formasPago;
    }
}