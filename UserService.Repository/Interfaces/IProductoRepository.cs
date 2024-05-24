using UserService.Core.Entities;

namespace UserService.Repository.Interfaces;

public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<IEnumerable<Producto>> GetByCantidadAsync(int cantidad);
}