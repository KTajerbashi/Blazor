using CleanArchitectureBlazor.AppApi.Components;
using CleanArchitectureBlazor.AppApi.Extensions;
using CleanArchitectureBlazor.Infra.DataSql.Extensions;
namespace CleanArchitectureBlazor.AppApi.HostedExtensions;

public static class HostedService
{
    public static WebApplication ConfigurationService(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.Services.AddMainServices();

        builder.Services.AddHttpClient();

        builder.Services.AddInfrastructure(configuration, "DefaultConnection");

        builder.Services.AddIdentityServices(configuration);

        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
        builder.Services.AddControllers();

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

        app.UseCors("AllowAllOrigins");

        app.UseRouting();

        app.UseStaticFiles();

        app.UseAntiforgery();

        app.UseIdentity();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}