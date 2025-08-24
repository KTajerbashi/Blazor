

var app = await WebApplication
    .CreateBuilder(args)
    .AddWebAppServices()
    .UseWebAppAsync();
app.Run();
