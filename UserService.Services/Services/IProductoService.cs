using UserService.Core.Dtos;
using UserService.Core.Entities;

namespace UserService.Services.Services;

public interface IProductoService
{
    void AddAsync(ProductoDTO entity);
    Task<IEnumerable<Producto>> GetByCantidadAsync(int cantidad);
    Task<IEnumerable<ProductoDTO>> GetAllAsync();
    Task<IEnumerable<ProductoDTO>> GetAllV2Async();
}