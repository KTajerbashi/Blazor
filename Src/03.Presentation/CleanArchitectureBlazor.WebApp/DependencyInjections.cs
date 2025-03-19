using CleanArchitectureBlazor.Core.Application;
using CleanArchitectureBlazor.Core.Application.Common.Extensions;
using CleanArchitectureBlazor.Infra.Data.SqlServer;
using CleanArchitectureBlazor.WebApp.Common.Swagger;
using CleanArchitectureBlazor.WebApp.Data;
using CleanArchitectureBlazor.WebApp.Extensions;
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
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseSwaggerServices();
        }

        await Task.CompletedTask;

        app.UseLoggingMiddleware();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        // Enable authentication and authorization
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapBlazorHub();
        
        app.MapControllers();

        app.MapFallbackToPage("/_Host");

        return app;
    }


}
