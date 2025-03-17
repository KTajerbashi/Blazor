using CleanArchitectureBlazor.WebApp;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using CleanArchitectureBlazor.WebApp.Common.Serilog;
using Serilog;
using CleanArchitectureBlazor.WebApp.Middlewares.LoggingHandler;

var builder = WebApplication.CreateBuilder(args);
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
IConfiguration configuration = builder.Configuration;
Log.Information("Application started");
try
{
    builder.AddSerilogServices();

    builder.Services.AddWebAppDependecies(configuration);

    var app = builder.Build();
    

    app.UseWebAppDependecies();

    app.UseSerilogServices();

    app.Run();
}
catch (Exception ex)
{
    Log.Error("An error occurred: {ErrorMessage}", ex.Message);
    throw;
}