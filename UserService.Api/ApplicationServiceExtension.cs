using UserService.Core.Services;
using UserService.Repository.Repositories;
using UserService.Services.Services;

namespace UserService.Api;

public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.WithOrigins("https://localhost:4201")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductoService, ProductoService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}