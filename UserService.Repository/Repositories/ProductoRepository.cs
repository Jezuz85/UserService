using AutoMapper;
using UserService.Core.Dtos;
using UserService.Core.Entities;
using UserService.Repository.Interfaces;
using UserService.Repository.Models;

namespace UserService.Repository.Repositories;

public class ProductoRepository : GenericRepository<ProductoDTO>, IProductoRepository
{
    private readonly IMapper _mapper;
    public ProductoRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public override void AddAsync(ProductoDTO entity)
    {
        var producto = _mapper.Map<Producto>(entity);

        _context.Producto.Add(producto);
        _context.SaveChanges();
    }

    public Task<IEnumerable<Producto>> GetByCantidadAsync(int cantidad)
    {
        return Task.FromResult<IEnumerable<Producto>>(_context.Producto.Where(x => x.Stock == cantidad));
    }

    public override Task<IEnumerable<ProductoDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public override Task<ProductoDTO?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void AddAsync(Producto entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Producto entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Producto entity)
    {
        throw new NotImplementedException();
    }
}