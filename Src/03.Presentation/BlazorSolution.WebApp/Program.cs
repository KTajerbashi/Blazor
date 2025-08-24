

try
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.AddWebAppServices().ConfigureWebAppPipeline();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}