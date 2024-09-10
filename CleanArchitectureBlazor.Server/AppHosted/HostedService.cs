using CleanArchitectureBlazor.Infrastructure.DIExtensions;
using CleanArchitectureBlazor.Server.Components;

namespace CleanArchitectureBlazor.Server.AppHosted;

public static class HostedService
{
    public static WebApplication ConfigurationService(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddInfrastructure(configuration, "DefaultConnection");

        return builder.Build();
    }
    public static WebApplication ConfigurationPipline(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
        return app;
    }
}