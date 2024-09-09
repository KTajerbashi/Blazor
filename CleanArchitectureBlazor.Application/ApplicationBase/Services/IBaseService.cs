namespace CleanArchitectureBlazor.Application.ApplicationBase.Services;

public interface IBaseService<TEntity>
{
    Task<TEntity> GetAsync(Guid key);
    TEntity Get(Guid key);

    Task<TEntity> GetAsync(long id);
    TEntity Get(long id);

    Task<IEnumerable<TEntity>> GetAsync();
    IEnumerable<TEntity> Get();

    Guid Insert(TEntity entity);
    Guid InsertAsync(TEntity entity);

    void Delete(Guid key);
    Task DeleteAsync(Guid key);

}


