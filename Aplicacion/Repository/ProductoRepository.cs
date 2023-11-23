using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly jardineriaFiltroContext _context;

    public ProductoRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }
}