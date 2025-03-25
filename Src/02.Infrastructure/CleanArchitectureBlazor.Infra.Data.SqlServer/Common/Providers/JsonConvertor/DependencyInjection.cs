using CleanArchitectureBlazor.Core.Application.Common.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Common.Providers.JsonConvertor;

public static class DependencyInjection
{
    public static IServiceCollection AddNewtonSoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonConvertor, JsonConvertor>();
}