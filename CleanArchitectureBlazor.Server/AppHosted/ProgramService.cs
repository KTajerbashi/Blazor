namespace CleanArchitectureBlazor.Server.AppHosted;

public static class ProgramService
{
    public static IServiceCollection AddMainServices(this IServiceCollection services)
    {
        services
            .AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });

        services.AddControllers();
        return services;
    }
}
