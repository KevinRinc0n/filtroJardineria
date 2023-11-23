using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly jardineriaFiltroContext _context;

    public EmpleadoRepository(jardineriaFiltroContext context) : base(context)
    {
        _context = context;
    }
}