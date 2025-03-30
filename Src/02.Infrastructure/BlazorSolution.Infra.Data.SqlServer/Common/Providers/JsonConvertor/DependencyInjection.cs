using BlazorSolution.Core.Application.Common.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSolution.Infra.Data.SqlServer.Common.Providers.JsonConvertor;

public static class DependencyInjection
{
    public static IServiceCollection AddNewtonSoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonConvertor, JsonConvertor>();
}