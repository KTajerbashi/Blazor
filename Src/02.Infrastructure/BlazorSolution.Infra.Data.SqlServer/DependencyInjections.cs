using BlazorSolution.Core.Application.Common;
using BlazorSolution.Infra.Data.SqlServer.Common;
using BlazorSolution.Infra.Data.SqlServer.Common.DataBase;
using BlazorSolution.Infra.Data.SqlServer.Common.Providers.JsonConvertor;
using BlazorSolution.Infra.Data.SqlServer.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace BlazorSolution.Infra.Data.SqlServer;

public static class DependencyInjections
{
    public static IServiceCollection AddInfraDataDependecies(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        => services
        .AddDatabaseDependecies(configuration)
        .AddDependencies()
        .AddUnitOfWork(assemblies)
        .AddIdentityConfiguration(configuration)
        .AddSingletonRepositories(assemblies)
        .AddScopeRepositories(assemblies)
        .AddTransientRepositories(assemblies)
        ;
    private static IServiceCollection AddDatabaseDependecies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IEventStore, EventStore>();
        services.AddNewtonSoftSerializer();
        return services;
    }
    private static IServiceCollection AddSingletonRepositories(this IServiceCollection services, Assembly[] assemblies)
    {
        services
            .Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(IAggregateRepository<,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithSingletonLifetime()
            );
        return services;
    }
    private static IServiceCollection AddScopeRepositories(this IServiceCollection services, Assembly[] assemblies)
    {
        services
        .Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IAggregateRepository<,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services, Assembly[] assemblies)
    {
        services
        .Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(UnitOfWork<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        return services;
    }
    private static IServiceCollection AddTransientRepositories(this IServiceCollection services, Assembly[] assemblies)
    {
        services
        .Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IAggregateRepository<,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
        return services;
    }

    private static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders()
            ;

        return services;
    }
}
