using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly jardineriaFiltroContext _context;

    public ClienteRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> clientePagosYRepresentante()
    {
        var clientePago = await _context.Clientes
            .Join(
                _context.Empleados,
                cliente => cliente.CodigoEmpleadoRepVentas,
                empleado => empleado.CodigoEmpleado,
                (cliente, representante) => new { Cliente = cliente, Representante = representante }
            )
            .Join(
                _context.Pagos,
                clienteRepresentante => clienteRepresentante.Cliente.CodigoCliente,
                pago => pago.CodigoCliente,
                (clienteRepresentante, pago) => new { ClienteRepresentante = clienteRepresentante, Pago = pago }
            )
            .Select(result => new Cliente
            {
                CodigoCliente = result.ClienteRepresentante.Cliente.CodigoCliente,
                NombreCliente = result.ClienteRepresentante.Cliente.NombreCliente,

                CodigoEmpleadoRepVentasNavigation = result.ClienteRepresentante.Representante,
                
                Pagos = new List<Pago> { result.Pago }
            })
            .ToListAsync();

        return clientePago;
    }

    public async Task<IEnumerable<Cliente>> sinPagos()
    {
        var sinPagos = await _context.Clientes
        .Where(p => p.Pagos.Count == 0)
        .ToListAsync();

        return sinPagos;
    }

    public async Task<IEnumerable<Cliente>> clientess()
    {
        var clientees = await _context.Clientes
        .Where(p => p.CodigoEmpleadoRepVentasNavigation.Puesto == "Representante Ventas")
        .Include(c => c.CodigoEmpleadoRepVentasNavigation)
        .ThenInclude(c => c.CodigoOficinaNavigation)
        .ToListAsync();

        return clientees;
    }

    public async Task<IEnumerable<Cliente>> sinPagos2()
    {
        var sinPagos = await _context.Clientes
        .Where(p => p.Pagos.Count == 0 && p.CodigoEmpleadoRepVentasNavigation.Puesto == "Representante Ventas")
        .Include(c => c.CodigoEmpleadoRepVentasNavigation)
        .ThenInclude(c => c.CodigoOficinaNavigation)
        .ToListAsync();

        return sinPagos;
    }
}