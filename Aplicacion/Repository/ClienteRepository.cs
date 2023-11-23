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
}