using CleanArchitectureBlazor.Infrastructure.DIExtensions;
using CleanArchitectureBlazor.Server.Components;
using CleanArchitectureBlazor.Server.Extensions.Identity;

namespace CleanArchitectureBlazor.Server.AppHosted;

public static class HostedService
{
    public static WebApplication ConfigurationService(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddInfrastructure(configuration, "DefaultConnection");

        builder.Services.AddIdentityServices(configuration);

        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();

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
        else
        {
            app.UseWebAssemblyDebugging();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseAntiforgery();
        
        app.UseIdentity();

        app
            .MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(CleanArchitectureBlazor.Client._Imports).Assembly);
        return app;
    }
}