using Microsoft.EntityFrameworkCore;
using Repositories;

namespace ProductApi.Infrastrucre.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("sqliteconnection"),
            prj => prj.MigrationsAssembly("ProductApi"));
        });
    }
}