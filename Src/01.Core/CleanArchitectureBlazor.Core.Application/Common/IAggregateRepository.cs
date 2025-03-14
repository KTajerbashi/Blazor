using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Application.Common;

public interface IAggregateRepository<TAggregate, TId> : IUnitOfWork
    where TAggregate : Aggregate<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    Task<TId> CreateAsync(TAggregate aggregate,CancellationToken cancellationToken);
    Task<IEnumerable<TAggregate>> GetAsync(CancellationToken cancellationToken);
    Task<TAggregate> GetAsync(TId id,CancellationToken cancellationToken);
    Task<TAggregate> GetAsync(Guid key, CancellationToken cancellationToken);
    Task DeleteAsync(Guid key,CancellationToken cancellationToken);
    Task DeleteAsync(TAggregate aggregate,CancellationToken cancellationToken);

    string ContextId();

    void SaveChange();
    Task SaveChangeAsync();

}
