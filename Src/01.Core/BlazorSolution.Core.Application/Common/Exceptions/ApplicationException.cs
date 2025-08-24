namespace BlazorSolution.Core.Application.Common.Exceptions;

public class AppException : Exception
{
    public AppException(string msg) : base(msg) { }
    public AppException(string msg, Exception exception) : base(msg, exception) { }
}



public class AccessDenideException : Exception
{
    public AccessDenideException(string msg) : base(msg) { }
}

public class BadRequestException : Exception
{
    public BadRequestException(string msg) : base(msg) { }
}

