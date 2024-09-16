

namespace CleanArchitectureBlazor.Core.Domain.BaseCoreDomain;


public interface IEntity
{
    bool IsActive { get; protected set; }
    bool IsDeleted { get; protected set; }
    Guid Key { get; protected set; }
    void Delete();
}
public interface IEntity<T> : IEntity
{
    T Id { get; set; }
}
public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid Key { get; set; }

    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }
}
public abstract class Entity : Entity<long>
{
}
