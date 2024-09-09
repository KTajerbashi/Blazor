namespace CleanArchitectureBlazor.Core.CoreBase.Entities;

public interface IEntity
{
}
public interface IEntity<T> : IEntity
{
    T Id { get; set; }
    Guid Key { get; set; }
}
public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public Guid Key { get; set; }
}
public abstract class Entity : Entity<long>
{
}
