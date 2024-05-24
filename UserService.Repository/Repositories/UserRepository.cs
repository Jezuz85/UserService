using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;
using UserService.Repository.Interfaces;
using UserService.Repository.Models;

namespace UserService.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Users?> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<Users?>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddUser(Users? user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(Users? user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}