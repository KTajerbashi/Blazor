using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBlazor.Core.ApplicationService.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}
