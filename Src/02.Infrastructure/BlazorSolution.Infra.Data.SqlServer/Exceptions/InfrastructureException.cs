namespace BlazorSolution.Infra.Data.SqlServer.Exceptions;

public class InfrastructureException : Exception
{
    public InfrastructureException(string message, Exception exception) : base(message, exception)
    {

    }
    public InfrastructureException(string message) : base(message)
    {

    }
}
