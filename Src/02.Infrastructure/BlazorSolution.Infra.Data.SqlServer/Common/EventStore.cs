using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Application.EventSourcing.Models;
using BlazorSolution.Core.Domain.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
namespace BlazorSolution.Infra.Data.SqlServer.Common;

public class EventStore : IEventStore
{
    private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
    {
        NullValueHandling = NullValueHandling.Ignore,
        TypeNameHandling = TypeNameHandling.All,
    };
    private readonly IDbConnection _dbConnection;
    private readonly IConfiguration _configuration;
    public EventStore(IConfiguration configuration)
    {
        _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        _configuration = configuration;
    }
    public IReadOnlyList<IDomainEvent> Get(string aggregateTypeName, long id)
    {
        string command = @"SELECT * FROM EventSourcing.EventSource ES WHERE ES.Aggregate = @Aggregate AND ES.AggregateId = @AggregateId";
        var parameter = new
        {
            Aggregate = aggregateTypeName,
            AggregateId = id.ToString(),
        };
        List<EventSourceDTO> eventSourceDTOs = _dbConnection.Query<EventSourceDTO>(command,parameter,commandType:CommandType.Text).ToList();
        List<IDomainEvent> domainEvents = new List<IDomainEvent>();
        foreach (var eventSource in eventSourceDTOs)
        {
            var myObject = JsonConvert.DeserializeObject(eventSource.Data,_serializerSettings);
            domainEvents.Add(myObject as IDomainEvent);
        }
        return domainEvents;
    }

    public void Save(string aggregateTypeName, long id, int currentVersion, IReadOnlyList<IDomainEvent> domainEvents)
    {
        string insertCommand = @"
INSERT INTO [EventSourcing].[EventSource]
    ([Sequence],[Version],[Name],[AggregateId],[Data],[Aggregate],[IsActive],[IsDeleted],[Key],[CreatedDate],[CreatedByUserId],[UpdateDate],[UpdatedByUserId])
VALUES
    (NEWID(),@Version,@Name,@AggregateId,@Data,@Aggregate,1,0,NEWID(),GETDATE(),@CreatedByUserId,NULL,NULL)
";
        var itemToSave = domainEvents.Select(item => new
        {
            Version = ++currentVersion,
            item.GetType().Name,
            AggregateId=id,
            Data=JsonConvert.SerializeObject(item,_serializerSettings),
            Aggregate = aggregateTypeName,
            CreatedByUserId=1,
        }).ToList();
        _dbConnection.Execute(insertCommand, itemToSave);
    }
}
