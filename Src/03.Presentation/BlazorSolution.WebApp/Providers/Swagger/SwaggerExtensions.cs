using Microsoft.OpenApi.Models;

namespace BlazorSolution.WebApp.Providers.Swagger;
public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        // Add Swagger services
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My Razor Pages API",
                Version = "v1",
                Description = "API documentation for Razor Pages Application"
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerServices(this WebApplication app)
    {
        var configuration = app.Configuration;
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AngularJS & Razor Pages API V1");
                var vPersonalised = Convert.ToBoolean(configuration["SwaggerOptions:Personalised"]);
                if (vPersonalised) // True if we want to use a custom Swagger UI
                {
                    c.DocumentTitle = configuration["SwaggerOptions:DocTitle"]; // Custom document title
                    c.HeadContent = configuration["SwaggerOptions:HeaderImg"];  // Custom header image
                    c.InjectStylesheet(configuration["SwaggerOptions:PathCss"]); // Custom CSS styles
                }
            });
        }
        return app;
    }
}


