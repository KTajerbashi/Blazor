using BlazorSolution.WebApp;
using BlazorSolution.WebApp.Components;

var app = await WebApplication.CreateBuilder(args).AddWebAppServices().UseWebAppAsync();





app.Run();
