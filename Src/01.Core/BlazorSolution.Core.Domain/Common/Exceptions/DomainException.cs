namespace BlazorSolution.Core.Domain.Common.Exceptions;

public class DomainException : Exception
{
    public DomainException(string msg) : base(msg) { }
    public DomainException(string msg, Exception exception) : base(msg, exception) { }
}
