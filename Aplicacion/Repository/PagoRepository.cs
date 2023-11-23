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
}