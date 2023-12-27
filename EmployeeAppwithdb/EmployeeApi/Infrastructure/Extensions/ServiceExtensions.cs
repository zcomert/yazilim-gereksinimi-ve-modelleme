using Microsoft.EntityFrameworkCore;
using Repositories;

namespace EmployeeApi.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
                .AddDbContext<RepositoryContext>(options =>
                {
                    options.UseSqlite(configuration
                    .GetConnectionString("sqliteconnection"),
                    prj => prj.MigrationsAssembly("EmployeeApi"));
                });
    }
}