using Serilog;

namespace CleanArchitectureBlazor.AppApi.HostedExtensions;

public class StartApplication
{
    public static void RunProgram(Action action)
    {
        try
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
                .CreateLogger();
            Log.Information("Application Started  ...");
            action();
        }
        catch (Exception ex)
        {
            Log.Warning($"Application Exception => {ex.Message}");
            throw ex;
        }
        finally
        {
            Log.Information($"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")} => Finally Logging ....");
            Log.CloseAndFlushAsync();
        }

    }
}
