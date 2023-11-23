using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class GamaProductoRepository : GenericRepository<GamaProducto>, IGamaProducto
{
    private readonly jardineriaFiltroContext _context;

    public GamaProductoRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }
}