namespace BlazorWebApp.Repositories;

public interface IMetricsService
{
    void TrackPageView(string pageName);
    void TrackDatabaseQueryTime(string queryName, long milliseconds);
    void TrackUserLogin(string username);
    void TrackException(string exceptionType);
    void TrackBusinessEvent(string eventName, string category = "");
    TimerR TrackRequestDuration(string requestName);
    void TrackHttpRequest(string method, string route, int statusCode, long durationMs);
    void TrackGaugeValue(string gaugeName, double value, params KeyValuePair<string, object?>[] tags);
}
