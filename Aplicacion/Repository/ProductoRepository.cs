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

    public async Task<IEnumerable<Producto>> productosSinPedido()
    {
        var productosSinPedido = await (
            from producto in _context.Productos
            join detallePedido in _context.DetallePedidos
                on producto.CodigoProducto equals detallePedido.CodigoProducto into detallesPedidos
            from detallePedido in detallesPedidos.DefaultIfEmpty()
            where detallePedido == null
            select producto
        )
        .Include(p => p.GamaNavigation)
        .ToListAsync();

        return productosSinPedido;
    }
}