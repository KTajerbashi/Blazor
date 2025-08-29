using BlazorWebApp;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.AddWebAppServices().ConfigureWebAppPipeline();

    app.Run();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("=================================");
    Console.WriteLine(ex.ToString());
    Console.WriteLine("=================================");
    //Log.Fatal(ex, "Application start-up failed");
}
finally
{
    //Log.CloseAndFlush();
}