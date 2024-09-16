using CleanArchitectureBlazor.AppApi.HostedExtensions;

StartApplication.RunProgram(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    builder
    .ConfigurationService()
    .ConfigurationPipline()
    .Run();
});

