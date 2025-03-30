namespace BlazorSolution.Core.Application.Common.Providers;

public interface IJsonConvertor
{
    string Serialize<TInput>(TInput input);
    TOutput Deserialize<TOutput>(string input);
    object Deserialize(string input, Type type);
}
