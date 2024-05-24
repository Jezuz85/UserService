using UserService.Core.Entities;

namespace UserService.Repository.Interfaces;

public interface IUserRepository
{
    Task<Users?> GetUserById(int id);

    Task<IEnumerable<Users?>> GetAllUsers();

    Task AddUser(Users? user);

    Task UpdateUser(Users? user);

    Task DeleteUser(int id);
}