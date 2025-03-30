namespace BlazorSolution.Core.Application.Common.Exceptions;

public class ApplicationException : Exception
{
    public ApplicationException(string msg) : base(msg) { }
    public ApplicationException(string msg, Exception exception) : base(msg, exception) { }
}



public class AccessDenideException : Exception
{
    public AccessDenideException(string msg) : base(msg) { }
}

public class BadRequestException : Exception
{
    public BadRequestException(string msg) : base(msg) { }
}

