namespace CleanArchitectureBlazor.Core.Domain.Common;

public interface IEntity
{
    bool IsActive { get; protected set; }
    bool IsDeleted { get; protected set; }
    Guid Key { get; protected set; }
    void Delete();
}
public interface IEntity<TId> : IEntity
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    TId Id { get; set; }
}
public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    public TId Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid Key { get; set; } = Guid.NewGuid();

    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }

    public bool Equals(Entity<TId>? other)
    {
        throw new NotImplementedException();
    }
}
public abstract class Aggregate<TId> : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    private readonly List<IDomainEvent> _events = new();
    public IReadOnlyCollection<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent @event) => _events.Add(@event);
    public void ClearEvent() => _events.Clear();
}

public abstract class Aggregate : Aggregate<long>
{
}


public interface IDomainEvent
{

}