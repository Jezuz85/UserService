using Microsoft.AspNetCore.Mvc;
using UserService.Core.Dtos;
using UserService.Services.Services;

namespace UserService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpPost]
    public void Post([FromBody] ProductoDTO producto)
    {
        _productoService.AddAsync(producto);
    }

    [HttpGet]
    public Task<IEnumerable<ProductoDTO>> Get()
    {
        return _productoService.GetAllAsync();
    }

}