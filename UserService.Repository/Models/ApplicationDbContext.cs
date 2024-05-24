using Microsoft.EntityFrameworkCore;
using UserService.Core.Configuration;
using UserService.Core.Entities;

namespace UserService.Repository.Models;

public class ApplicationDbContext : DbContext
{
    private string server = "serverdesinglabs";
    private string database = "bd_Designlabs";
    private string userId = "AdminOmniman";
    private string password = "MortalKombat1985"; 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server=tcp:{server}.database.windows.net,1433;Initial Catalog={database};Persist Security Info=False;User ID={userId};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        modelBuilder.ApplyConfiguration(new ProductoConfiguration());
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Producto> Producto { get; set; }
}