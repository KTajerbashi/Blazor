using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Application.Common;

public interface IDomainEventDispatcher
{
    void Dispatch(IReadOnlyCollection<IDomainEvent> events);
}