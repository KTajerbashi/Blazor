using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace BlazorWebApp.Services;

public class Timer : IDisposable
{
    private readonly Histogram<double> _histogram;
    private readonly KeyValuePair<string, object?>[] _tags;
    private readonly Stopwatch _stopwatch;

    public Timer(Histogram<double> histogram, KeyValuePair<string, object?>[] tags)
    {
        _histogram = histogram;
        _tags = tags;
        _stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        _stopwatch.Stop();
        _histogram.Record(_stopwatch.Elapsed.TotalSeconds, _tags);
    }
}
