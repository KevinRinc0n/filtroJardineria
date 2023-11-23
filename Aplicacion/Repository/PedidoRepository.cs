using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class PedidoRepository : GenericRepository<Pedido>, IPedido
{
    private readonly jardineriaFiltroContext _context;

    public PedidoRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }
}