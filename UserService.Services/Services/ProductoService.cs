using UserService.Core.Dtos;
using UserService.Core.Entities;
using UserService.Repository.Repositories;
using UserService.Services.Services;

namespace UserService.Core.Services;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddAsync(ProductoDTO entity)
    {
        _unitOfWork.ProductoRepository.AddAsync(entity);
    }

    public async Task<IEnumerable<Producto>> GetByCantidadAsync(int cantidad)
    {
        return await _unitOfWork.ProductoRepository.GetByCantidadAsync(cantidad);
    }
}