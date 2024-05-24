using UserService.Core.Dtos;
using UserService.Core.Entities;

namespace UserService.Repository.Interfaces;

public interface IProductoRepository : IGenericRepository<ProductoDTO>
{
    Task<IEnumerable<Producto>> GetByCantidadAsync(int cantidad);
}