using UserService.Core.Entities;
using UserService.Repository.Interfaces;
using UserService.Repository.Models;

namespace UserService.Repository.Repositories;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    public ProductoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override void AddAsync(Producto entity)
    {
        _context.Producto.Add(entity);
        _context.SaveChanges();
    }

    public Task<IEnumerable<Producto>> GetByCantidadAsync(int cantidad)
    {
        return Task.FromResult<IEnumerable<Producto>>(_context.Producto.Where(x => x.Stock == cantidad));
    }

    public override Task<IEnumerable<Producto>> GetAllAsync()
    {
       var productos = _context.Producto.ToList(); 
       return Task.FromResult<IEnumerable<Producto>>(productos);

    }

    public override Task<Producto?> GetAsync(int id)
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