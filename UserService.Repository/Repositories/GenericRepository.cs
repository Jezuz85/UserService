using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;
using UserService.Repository.Interfaces;
using UserService.Repository.Models;

namespace UserService.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual void AddAsync(T entity)
    {
        _context.Set<T>().AddAsync(entity);
    }

    public virtual void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual async Task<T?> GetAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}