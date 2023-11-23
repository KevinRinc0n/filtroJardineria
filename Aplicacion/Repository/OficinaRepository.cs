using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class OficinaRepository : GenericRepository<Oficina>, IOficina
{
    private readonly jardineriaFiltroContext _context;

    public OficinaRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }
}