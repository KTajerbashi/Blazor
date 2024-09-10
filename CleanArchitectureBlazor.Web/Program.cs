using CleanArchitectureBlazor.Web;
using CleanArchitectureBlazor.Web.AppHosted;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

StartApplication.RunProgram(() =>
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder
    .ConfigurationService()
    .ConfigurationPipline()
    .RunAsync();
});
