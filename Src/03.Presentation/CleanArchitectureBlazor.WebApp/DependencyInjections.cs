using CleanArchitectureBlazor.Core.Application;
using CleanArchitectureBlazor.Core.Application.Common.Extensions;
using CleanArchitectureBlazor.Infra.Data.SqlServer;
using CleanArchitectureBlazor.WebApp.Common.Swagger;
using CleanArchitectureBlazor.WebApp.Data;
using CleanArchitectureBlazor.WebApp.Extensions;
using CleanArchitectureBlazor.WebApp.Middlewares.ExceptionHandler;
using CleanArchitectureBlazor.WebApp.Middlewares.LoggingHandler;

namespace CleanArchitectureBlazor.WebApp;

public static class DependencyInjections
{
    public static IServiceCollection AddWebAppDependecies(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblies = AssemblyProviderExtensions.GetAssemblies(new string[] { "CleanArchitectureBlazor" });

        // Register HttpClient
        services.AddHttpClient(); // Register HttpClient with default configuration

        services.AddControllers();

        services.AddRazorPages();

        // Add Identity UI (for login, register, etc.)
        services.AddRazorPages().AddRazorRuntimeCompilation();

        services.AddServerSideBlazor();

        services.AddSingleton<WeatherForecastService>();
        services.AddScoped<FileDownloadService>();
        services.AddServerSideBlazor();

        services.AddInfraDataDependecies(configuration, assemblies);

        services.AddApplicationDependecies();

        services.AddSwaggerServices();

        return services;
    }

    public static async Task<WebApplication> UseWebAppDependecies(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // 1. Exception handling (should come first)
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerServices();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        // 2. Security-related middleware
        app.UseHttpsRedirection();

        // 3. Static files (before routing)
        app.UseStaticFiles();

        // 4. Routing (needs to come before auth and endpoint middleware)
        app.UseRouting();

        // 5. Custom middleware
        app.UseLoggingMiddleware();
        app.UseApiExceptionHandler();

        // 6. Authentication & Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        // 7. Endpoint configuration
        app.MapControllers();
        app.MapRazorPages();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        await Task.CompletedTask;
        return app;
    }

}
