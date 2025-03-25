namespace CleanArchitectureBlazor.Core.Application.Common.Exceptions;

public class SystemException : Exception
{
    public SystemException(string msg) : base(msg) { }
    public SystemException(string msg, Exception exception) : base(msg, exception) { }
}

