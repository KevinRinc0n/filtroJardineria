using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPago: IGenericRepository<Pago>
{
    Task<IEnumerable<Pago>> paypal2008();
    Task<IEnumerable<string>> formasPago();
}