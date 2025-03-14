using CleanArchitectureBlazor.WebApp;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

var builder = WebApplication.CreateBuilder(args);
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
IConfiguration configuration = builder.Configuration;

builder.Services.AddWebAppDependecies(configuration);

var app = builder.Build();

app.UseWebAppDependecies();

app.Run();
