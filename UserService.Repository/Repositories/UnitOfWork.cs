using UserService.Repository.Interfaces;
using UserService.Repository.Models;

namespace UserService.Repository.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private IUserRepository? _userRepository;
    private IProductoRepository? _productoRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IProductoRepository ProductoRepository
    {
        get
        {
            return _productoRepository ??= new ProductoRepository(_context);
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepository ??= new UserRepository(_context);
        }
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}