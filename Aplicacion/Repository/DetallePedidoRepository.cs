using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedido
{
    private readonly jardineriaFiltroContext _context;

    public DetallePedidoRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }
}