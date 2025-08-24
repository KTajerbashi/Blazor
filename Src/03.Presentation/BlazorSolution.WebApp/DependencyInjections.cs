using BlazorSolution.WebApp.Components;
using BlazorSolution.WebApp.Providers.Serilog;

namespace BlazorSolution.WebApp;

public static class DependencyInjections
{
    public static WebApplication AddWebAppServices(this WebApplicationBuilder builder)
    {
        builder.AddSerilog();
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        return builder.Build();
    }

    public static async Task<WebApplication> UseWebAppAsync(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSerilog();

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        await Task.CompletedTask;
        return app;
    }
}
