using BlazorWebApp.Repositories;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace BlazorWebApp.Services;

public class OpenTelemetryMetricsService : IMetricsService
{
    private readonly Meter _meter;
    private readonly Counter<long> _pageViewCounter;
    private readonly Histogram<long> _databaseQueryHistogram;
    private readonly Counter<long> _userLoginCounter;
    private readonly Counter<long> _exceptionCounter;
    private readonly Counter<long> _businessEventCounter;
    private readonly Histogram<double> _requestDurationHistogram;
    private readonly Histogram<double> _httpRequestDurationHistogram;
    private readonly ObservableGauge<long> _memoryGauge;
    private readonly Dictionary<string, Gauge<double>> _gauges = new();

    public OpenTelemetryMetricsService(ILogger<OpenTelemetryMetricsService> logger)
    {
        try
        {
            _meter = new Meter("BlazorServerApp.Metrics", "1.0.0");

            // Counters
            _pageViewCounter = _meter.CreateCounter<long>(
                "blazor_page_views_total",
                unit: "views",
                description: "Total number of page views");

            _userLoginCounter = _meter.CreateCounter<long>(
                "user_logins_total",
                unit: "logins",
                description: "Total number of user logins");

            _exceptionCounter = _meter.CreateCounter<long>(
                "exceptions_total",
                unit: "exceptions",
                description: "Total number of exceptions");

            _businessEventCounter = _meter.CreateCounter<long>(
                "business_events_total",
                unit: "events",
                description: "Total number of business events");

            // Histograms
            _databaseQueryHistogram = _meter.CreateHistogram<long>(
                "database_query_duration_milliseconds",
                unit: "ms",
                description: "Duration of database queries in milliseconds");

            _requestDurationHistogram = _meter.CreateHistogram<double>(
                "request_duration_seconds",
                unit: "s",
                description: "Duration of requests in seconds");

            _httpRequestDurationHistogram = _meter.CreateHistogram<double>(
                "http_request_duration_seconds",
                unit: "s",
                description: "Duration of HTTP requests in seconds");

            // Gauges
            _memoryGauge = _meter.CreateObservableGauge<long>(
                "process_memory_bytes",
                observeValue: () => Process.GetCurrentProcess().WorkingSet64,
                unit: "bytes",
                description: "Process memory usage in bytes");

            logger.LogInformation("OpenTelemetry metrics service initialized successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to initialize OpenTelemetry metrics service");
            throw;
        }
    }

    public void TrackPageView(string pageName)
    {
        _pageViewCounter.Add(1, new KeyValuePair<string, object?>("page", pageName));
    }

    public void TrackDatabaseQueryTime(string queryName, long milliseconds)
    {
        _databaseQueryHistogram.Record(milliseconds, new KeyValuePair<string, object?>("query", queryName));
    }

    public void TrackUserLogin(string username)
    {
        _userLoginCounter.Add(1, new KeyValuePair<string, object?>("user", username));
    }

    public void TrackException(string exceptionType)
    {
        _exceptionCounter.Add(1, new KeyValuePair<string, object?>("type", exceptionType));
    }

    public void TrackBusinessEvent(string eventName, string category = "")
    {
        var tags = new List<KeyValuePair<string, object?>>
        {
            new("event", eventName)
        };

        if (!string.IsNullOrEmpty(category))
        {
            tags.Add(new KeyValuePair<string, object?>("category", category));
        }

        _businessEventCounter.Add(1, tags.ToArray());
    }



    public void TrackHttpRequest(string method, string route, int statusCode, long durationMs)
    {
        var tags = new KeyValuePair<string, object?>[]
        {
            new("method", method),
            new("route", route),
            new("status_code", statusCode.ToString())
        };

        _httpRequestDurationHistogram.Record(durationMs / 1000.0, tags);
    }

    public void TrackGaugeValue(string gaugeName, double value, params KeyValuePair<string, object?>[] tags)
    {
        if (!_gauges.TryGetValue(gaugeName, out var gauge))
        {
            gauge = _meter.CreateGauge<double>(
                gaugeName,
                unit: "units",
                description: $"Custom gauge: {gaugeName}");
            _gauges[gaugeName] = gauge;
        }

        gauge.Record(value, tags);
    }


    public TimerR TrackRequestDuration(string requestName)
    {
        var tags = new KeyValuePair<string, object?>[]
        {
            new("request", requestName)
        };

        return new Timer(_requestDurationHistogram, tags);
    }



}