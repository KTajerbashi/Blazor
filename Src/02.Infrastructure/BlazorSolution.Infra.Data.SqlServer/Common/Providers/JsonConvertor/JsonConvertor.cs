using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using BlazorSolution.Core.Application.Common.Providers;

namespace BlazorSolution.Infra.Data.SqlServer.Common.Providers.JsonConvertor;

/// <summary>
/// This Factory Used From Newtonsoft Package
/// </summary>
public class JsonConvertor : IJsonConvertor
{
    private readonly ILogger<JsonConvertor> _logger;

    public JsonConvertor(ILogger<JsonConvertor> logger)
    {
        _logger = logger;
        _logger.LogInformation("Newton Soft Serializer Start working");
    }

    public TOutput Deserialize<TOutput>(string input)
    {
        _logger.LogTrace("Newton Soft Serializer Deserialize with name {input}", input);

        return string.IsNullOrWhiteSpace(input) ? default : JsonConvert.DeserializeObject<TOutput>(input);
    }

    public object Deserialize(string input, Type type)
    {
        _logger.LogTrace("Newton Soft Serializer Deserialize with name {input} and type {type}", input, type);

        return string.IsNullOrWhiteSpace(input) ? default : JsonConvert.DeserializeObject(input, type);
    }

    public string Serialize<TInput>(TInput input)
    {
        _logger.LogTrace("Newton Soft Serializer Serilize with name {input}", input);

        return input == null ? string.Empty : JsonConvert.SerializeObject(input, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
    }

    public void Dispose() => _logger.LogInformation("Newton Soft Serializer Stop working");
}
