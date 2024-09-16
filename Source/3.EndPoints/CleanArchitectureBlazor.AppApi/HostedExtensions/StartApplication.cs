namespace CleanArchitectureBlazor.AppApi.HostedExtensions;

public class StartApplication
{
    public static void RunProgram(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
}
