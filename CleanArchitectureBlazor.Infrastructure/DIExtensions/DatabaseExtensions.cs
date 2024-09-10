using CleanArchitectureBlazor.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBlazor.Infrastructure.DIExtensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string sectionName)
        => services.AddDatabaseContext(configuration, sectionName);
    private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        var connectionString = configuration["ConnectionStrings:DefaultConnection"];
        
        services.AddDbContext<DbContextApplication>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString(sectionName));
        });
        return services;
    }

}
