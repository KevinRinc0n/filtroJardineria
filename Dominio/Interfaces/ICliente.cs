using Dominio.Entities;

namespace Dominio.Interfaces;

public interface ICliente: IGenericRepository<Cliente>
{
    Task<IEnumerable<Cliente>> clientePagosYRepresentante();
    Task<IEnumerable<Cliente>> sinPagos();
    Task<IEnumerable<Cliente>> clientess();
    Task<IEnumerable<Cliente>> sinPagos2();
}