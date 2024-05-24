using AutoMapper;
using UserService.Core.Dtos;
using UserService.Core.Entities;
using UserService.Repository.Repositories;
using UserService.Services.Services;

namespace UserService.Core.Services;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void AddAsync(ProductoDTO entity)
    {
        var producto = _mapper.Map<Producto>(entity);
        _unitOfWork.ProductoRepository.AddAsync(producto);
    }

    public async Task<IEnumerable<Producto>> GetByCantidadAsync(int cantidad)
    {
        return await _unitOfWork.ProductoRepository.GetByCantidadAsync(cantidad);
    }

    public async Task<IEnumerable<ProductoDTO>> GetAllAsync()
    {
        var result = await _unitOfWork.ProductoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductoDTO>>(result);
    }
}