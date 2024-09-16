namespace CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Models;

public interface IBaseModel
{
    Guid Key { get; set; }
}
public interface IBaseModel<T> : IBaseModel
{
    T Id { get; set; }
}
public abstract class BaseModel<T> : IBaseModel<T>
{
    public T Id { get; set; }
    public Guid Key { get; set; }
}
public abstract class BaseModel : BaseModel<long>
{
}
