using Asp.Versioning;
using AspNetCoreRateLimit;
using UserService.Services.Services;
using UserService.Repository.Repositories;
// ReSharper disable All

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


    public static void ConfigureRateLimit(this IServiceCollection services)
    {
        // Agregar soporte para el caché en memoria
        services.AddMemoryCache();
        
        // Configurar RateLimit utilizando configuraciones en memoria
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();

        // Configurar las opciones de rate limit basadas en IP
        services.Configure<IpRateLimitOptions>(options =>
        {
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*", // Aplicar a todos los endpoints
                    Limit = 3, // Límite de 3 solicitudes
                    Period = "5s" // Periodo de 5 segundos
                }
            };
        });
    }
     
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            // Configura la versión por defecto de la API como 1.0
            options.DefaultApiVersion = new ApiVersion(1, 0);
            
            // Asume que la versión por defecto es 1.0 cuando no se especifica
            options.AssumeDefaultVersionWhenUnspecified = true;
            
            // Utiliza el segmento de la URL para leer la versión de la API
            //options.ApiVersionReader = new UrlSegmentApiVersionReader();

            // Utiliza el encabezado "api-version" para leer la versión de la API
            //options.ApiVersionReader = new HeaderApiVersionReader("api-version");

            // utiliza query string para leer la versión de la API
            options.ApiVersionReader = new QueryStringApiVersionReader("v");
            
            // Informa a los clientes sobre las versiones soportadas y obsoletas de la API
            options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            // Formato del nombre del grupo de la API en la documentación
            options.GroupNameFormat = "'v'VVV";
            
            // Sustituye la versión de la API en la URL de la documentación
            options.SubstituteApiVersionInUrl = true;
        });
    }

}