using CleanArchitectureBlazor.Core.Application;
using CleanArchitectureBlazor.Infra.Data.SqlServer;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBlazor.WebApp;

public static class DependencyInjections
{
    public static IServiceCollection AddWebAppDependecies(this IServiceCollection services, IConfiguration configuration)
        => services
        .AddInfraDataDependecies(configuration)
        .AddApplicationDependecies()
        ;
  
}
