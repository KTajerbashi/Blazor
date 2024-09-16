using CleanArchitectureBlazor.Core.ApplicationService.Repositories.Privilege;
using CleanArchitectureBlazor.Core.ApplicationService.Repositories.Security;
using CleanArchitectureBlazor.Core.ApplicationService.Repositories.Setting;
using CleanArchitectureBlazor.Infra.DataSql.Context;
using CleanArchitectureBlazor.Infra.DataSql.Services.Privilege;
using CleanArchitectureBlazor.Infra.DataSql.Services.Security;
using CleanArchitectureBlazor.Infra.DataSql.Services.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBlazor.Infra.DataSql.Extensions;


public static class DatabaseExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string sectionName)
        => services
        .AddDatabaseContext(configuration, sectionName)
        .AddSingletonServices()
        .AddScopedServices()
        .AddTransientServices()
        ;
    private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddDbContext<DbContextApplication>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString(sectionName));
        });
        return services;
    }
    private static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        return services;
    }
    private static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleMenuService, RoleMenuService>();
        return services;
    }
    private static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        return services;
    }

}
