using UserService.Repository.Interfaces;

namespace UserService.Repository.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IProductoRepository ProductoRepository { get; }

    Task<bool> SaveAsync();
}