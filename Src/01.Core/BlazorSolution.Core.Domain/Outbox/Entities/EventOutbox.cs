using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Outbox.Entities;

[Table("EventOutboxs", Schema = "Business")]
public class EventOutbox : Aggregate
{
    public Guid EventId { get; set; }
    public int AccuredByUserId { get; set; }
    public DateTime AccureOn { get; set; }
    public int Aggregated { get; set; }
    public string AggregateName { get; set; }
    public string? AggregateTypeName { get; set; }
    public string EventName { get; set; }
    public string? EventTypeName { get; set; }
    public string EventPayload { get; set; }
    public bool IsProcessed { get; set; }
}
