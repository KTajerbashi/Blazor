using BlazorSolution.Core.Application.Common;

namespace BlazorSolution.Core.Application.EventSourcing.Models;

public class EventSourceDTO : BaseDTO
{
    public Guid Sequence { get; set; }
    public int Version { get; set; }
    public string Name { get; set; }
    public string AggregateId { get; set; }
    public string Data { get; set; }
    public string Aggregate { get; set; }


}
