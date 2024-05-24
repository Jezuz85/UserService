using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Core.Entities;

namespace UserService.Core.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Precio).IsRequired();
        builder.Property(x => x.Stock).IsRequired();
        builder.HasOne(x => x.Users).WithMany(x => x.Productos).HasForeignKey(x => x.UserId);
    }
}