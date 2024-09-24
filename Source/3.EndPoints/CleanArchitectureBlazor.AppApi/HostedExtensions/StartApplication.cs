using Serilog;

namespace CleanArchitectureBlazor.AppApi.HostedExtensions;


public class StartApplication
{
    public static void RunProgram(Action action)
    {
        try
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .Console()
                .CreateBootstrapLogger();
            Log.Information("Application Started  ...");
            action();
        }
        catch (Exception ex)
        {
            Log.Fatal($"Application Exception => {ex.Message}");
        }
        finally
        {
            Log.Information($"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")} => Finally Logging ....");
            Log.CloseAndFlushAsync();
        }

    }
}
