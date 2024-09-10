using CleanArchitectureBlazor.Server.AppHosted;

StartApplication.RunProgram(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    builder
    .ConfigurationService()
    .ConfigurationPipline()
    .Run();
});
