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

    public async Task<IEnumerable<object>> jefeEmpleados()
    {
        return await _context.Empleados
            .Join(_context.Empleados, e => e.CodigoJefe, j => j.CodigoEmpleado, (e, j) => new { Empleado = e, Jefe = j })
            .Join(_context.Empleados, ej => ej.Jefe.CodigoJefe, jj => jj.CodigoEmpleado, (ej, jj) => new { Empleado = ej.Empleado, Jefe = ej.Jefe, JefeDelJefe = jj })
            .Select(result => new
            {
                NombreEmpleado = result.Empleado.Nombre,
                NombreJefe = result.Jefe.Nombre,
                NombreJefeDelJefe = result.JefeDelJefe.Nombre
            })
            .ToListAsync();
    }
}