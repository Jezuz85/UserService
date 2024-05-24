using AutoMapper;
using UserService.Core.Dtos;
using UserService.Core.Entities;
using UserService.Repository.Repositories;

namespace UserService.Services.Services;

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

    public async Task<IEnumerable<ProductoDTO>> GetAllV2Async()
    {
        var result = await _unitOfWork.ProductoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductoDTO>>(result.Where(x => x.Stock > 15));
    }
}