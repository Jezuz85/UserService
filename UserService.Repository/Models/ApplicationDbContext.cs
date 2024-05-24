using Microsoft.EntityFrameworkCore;
using UserService.Core.Configuration;
using UserService.Core.Entities;

namespace UserService.Repository.Models;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:desinglabsserver.database.windows.net,1433;Initial Catalog=dbDesingLabs;Persist Security Info=False;User ID=AdminJesus;Password=kv6Y5DvZ%OOvKmB1TZrt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        modelBuilder.ApplyConfiguration(new ProductoConfiguration());
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Producto> Producto { get; set; }
}