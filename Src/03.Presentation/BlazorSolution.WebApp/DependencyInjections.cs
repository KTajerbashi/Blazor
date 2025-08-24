using BlazorSolution.Core.Application;
using BlazorSolution.Core.Application.Common.Extensions;
using BlazorSolution.Infra.Data.SqlServer;
using BlazorSolution.WebApp.Middlewares.ExceptionHandler;
using BlazorSolution.WebApp.Providers.Serilog;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog.Sinks.SystemConsole.Themes;

namespace BlazorSolution.WebApp;

public static class DependencyInjections
{
    public static WebApplication AddWebAppServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        var assemblies = AssemblyProviderExtensions.GetAssembly("BlazorSolution").ToArray();

        builder.AddSerilog();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Add services for Blazor Web App (NEW pattern)
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddInfraDataDependecies(configuration, assemblies);

        builder.Services.AddApplicationDependecies();

        // In AddWebAppServices method, if needed:
        builder.Services.AddAntiforgery(options =>
        {
            options.HeaderName = "X-CSRF-TOKEN";
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

        // Add response compression
        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"]);
        });

        return builder.Build();
    }

    public static WebApplication ConfigureWebAppPipeline(this WebApplication app)
    {
        // Use response compression
        app.UseResponseCompression();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSerilog();

        app.UseApiExceptionHandler();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();    // If you have authentication
        app.UseAuthorization();     // If you have authorization
        app.UseAntiforgery();       // Anti-forgery after auth

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        return app;
    }
}
