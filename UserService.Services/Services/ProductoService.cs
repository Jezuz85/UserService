using AutoMapper;
using UserService.Core.Dtos;
using UserService.Core.Entities;
using UserService.Repository.Repositories;

namespace UserService.Services.Services;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;

    public ProductoService(IUnitOfWork unitOfWork, IMapper mapper, IHttpClientFactory httpClientFactory)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _httpClient = httpClientFactory.CreateClient("MyHttpClient");
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

    public async Task<string> GetExternalDataAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}