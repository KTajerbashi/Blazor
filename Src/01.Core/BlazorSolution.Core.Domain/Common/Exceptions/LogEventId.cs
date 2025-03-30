namespace BlazorSolution.Core.Domain.Common.Exceptions;

public static class LogEventId
{
    public static int Error = 500;

    public static int Domain = 100;
    public static int Application = 101;
    public static int Infrastructure = 102;
    public static int EndPoint = 103;
}