using System.Reflection;
using System.Threading.Tasks.Sources;

namespace BlazorSolution.Core.Domain.Common;

public interface IEntity
{
    bool IsActive { get; }
    bool IsDeleted { get; }
    Guid Key { get; }
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
    TId Id { get; }
}
public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected Entity()
    {
        //CreatedDate = DateTime.UtcNow;
        //CreatedByUserId = 1;
        IsActive = true;
        IsDeleted = false;
    }
    public TId Id { get; protected set; }
    public int Version { get; protected set; }
    public bool IsActive { get; private set; }
    public bool IsDeleted { get; private set; }
    public Guid Key { get; private set; } = Guid.NewGuid();

    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public long CreatedByUserId { get; private set; } = 1;
    public DateTime? UpdateDate { get; private set; }
    public long? UpdatedByUserId { get; private set; }

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

    protected Aggregate(IReadOnlyList<IDomainEvent> @events)
    {
        if (@events == null || @events.Count == 0) return;

        foreach (var @event in @events)
        {
            Mutate(@event);
            Version++;
        }
    }
    protected Aggregate()
    {

    }
    protected void Apply(IDomainEvent @event)
    {
        Mutate(@event);
        AddEvent(@event);
    }
    private void Mutate(IDomainEvent @event)
    {
        //((dynamic)this).On((dynamic)@event);
        var onMethod = GetType().GetMethod("On",BindingFlags.Instance | BindingFlags.NonPublic,new Type[] { @event.GetType()});
        onMethod.Invoke(this, new[] { @event });
    }
}

public abstract class Aggregate : Aggregate<long>
{
    protected Aggregate(IReadOnlyList<IDomainEvent> @events) : base(events)
    {

    }
    protected Aggregate() : base()
    {

    }
}


public interface IDomainEvent
{

}