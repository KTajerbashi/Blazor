using Microsoft.JSInterop;

namespace BlazorWebApp.Services;

public class ReportService
{
    private readonly HttpClient _http;
    private readonly IJSRuntime _js;

    public ReportService(HttpClient http, IJSRuntime js)
    {
        _http = http;
        _http.BaseAddress = new Uri("https://localhost:7003/");
        _js = js;
    }

    public async Task DownloadStaticReportAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Reports/StaticReport");
            var data = await response.Content.ReadAsByteArrayAsync();

            var base64 = Convert.ToBase64String(data);
            await _js.InvokeVoidAsync("downloadFileFromStream", "StaticReport.pdf", base64);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}