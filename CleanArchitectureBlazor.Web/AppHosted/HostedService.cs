using CleanArchitectureBlazor.Infrastructure.DIExtensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

namespace CleanArchitectureBlazor.Web.AppHosted;

public static class HostedService
{
    public static WebAssemblyHost ConfigurationService(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");

        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddInfrastructure(builder.Configuration, "DefaultConnection");
        
        return builder.Build();
    }
    public static WebAssemblyHost ConfigurationPipline(this WebAssemblyHost app)
    {
        return app;
    }
}