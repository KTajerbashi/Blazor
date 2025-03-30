using Microsoft.JSInterop;

namespace BlazorSolution.WebApp.Extensions;

public static class FileUtil
{
    public static void SaveAsAsync(IJSRuntime jsRuntime, string fileName, byte[] content)
    {
        var fileStream = new MemoryStream(content);
        using var streamRef = new DotNetStreamReference(fileStream);
        jsRuntime.InvokeVoidAsync("downloadFile", fileName, streamRef);
    }
}

public class FileDownloadService
{
    private readonly IJSRuntime _jsRuntime;

    public FileDownloadService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SaveAsAsync(string fileName, byte[] content)
    {
        var fileStream = new MemoryStream(content);
        using var streamRef = new DotNetStreamReference(fileStream);
        await _jsRuntime.InvokeVoidAsync("downloadFile", fileName, streamRef);
    }
}