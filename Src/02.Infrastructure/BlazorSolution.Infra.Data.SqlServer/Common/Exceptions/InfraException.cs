namespace BlazorSolution.Infra.Data.SqlServer.Common.Exceptions;

public class InfraException : Exception
{
    public InfraException(string msg) : base(msg) { }
    public InfraException(string msg, Exception exception) : base(msg, exception) { }
}
