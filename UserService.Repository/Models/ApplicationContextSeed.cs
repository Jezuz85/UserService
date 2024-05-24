using System.Reflection;
using System.Text.Json;
using UserService.Core.Entities;

namespace UserService.Repository.Models;

public class ApplicationContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (ruta != null)
        {
            var path = Path.Combine(ruta, "Data");

            if (!context.Users.Any())
            {
                var users = await File.ReadAllTextAsync(Path.Combine(path, "seed.json"));
                List<Users>? usersList = JsonSerializer.Deserialize<List<Users>>(users);

                if (usersList != null)
                {
                    foreach (var item in usersList)
                    {
                        context.Users.Add(item);
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}