namespace CleanArchitectureBlazor.Domain.Test.Exceptions;

public class DataExistException : Exception
{
    public DataExistException(string msg) : base(msg)
    {

    }
}
