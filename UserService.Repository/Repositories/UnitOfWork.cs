using AutoMapper;
using UserService.Repository.Interfaces;
using UserService.Repository.Models;

namespace UserService.Repository.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private IUserRepository? _userRepository;
    private IProductoRepository? _productoRepository;
    private IMapper? _mapper;

    public UnitOfWork(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IProductoRepository ProductoRepository
    {
        get
        {
            return _productoRepository ??= new ProductoRepository(_context, _mapper);
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