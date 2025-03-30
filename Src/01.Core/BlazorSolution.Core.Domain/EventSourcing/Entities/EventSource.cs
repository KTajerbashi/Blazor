using BlazorSolution.Core.Domain.Common;
using System.Runtime.InteropServices;

namespace BlazorSolution.Core.Domain.EventSourcing.Entities;

/// <summary>
/// برای این الگو دیگر از موارد زیر استفاده نمیشود
/// UnitOfWork
/// EventOutbox
/// </summary>

[Table("EventSource", Schema = "EventSourcing")]
public class EventSource : Aggregate
{

    public Guid Sequence { get; set; }

    public int Version { get; set; }

    public string Name { get; set; }

    public string AggregateId { get; set; }

    public string Data { get; set; }

    public string Aggregate { get; set; }
}
