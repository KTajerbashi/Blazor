using CleanArchitectureBlazor.Core.Application;
using CleanArchitectureBlazor.Core.Application.Common.Extensions;
using CleanArchitectureBlazor.Infra.Data.SqlServer;
using CleanArchitectureBlazor.WebApp.Common.Swagger;
using CleanArchitectureBlazor.WebApp.Data;

namespace CleanArchitectureBlazor.WebApp;

public static class DependencyInjections
{
    public static IServiceCollection AddWebAppDependecies(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblies = AssemblyProviderExtensions.GetAssemblies(new string[] { "CleanArchitectureBlazor" });

        services.AddControllers();

        services.AddRazorPages();

        services.AddServerSideBlazor();

        services.AddSingleton<WeatherForecastService>();

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

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        
        app.MapControllers();

        app.MapFallbackToPage("/_Host");

        return app;
    }


}
