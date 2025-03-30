using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Application.Common;

public interface IDomainEventDispatcher
{
    void Dispatch(IReadOnlyCollection<IDomainEvent> events);
}