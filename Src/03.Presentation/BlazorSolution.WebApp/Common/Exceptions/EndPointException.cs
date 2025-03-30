namespace BlazorSolution.WebApp.Common.Exceptions;

public class EndPointException : Exception
{
    public EndPointException(string msg) : base(msg) { }
    public EndPointException(string msg, Exception exception) : base(msg, exception) { }
}
public class NotFoundException : Exception
{
    public NotFoundException(string msg) : base(msg) { }
}
