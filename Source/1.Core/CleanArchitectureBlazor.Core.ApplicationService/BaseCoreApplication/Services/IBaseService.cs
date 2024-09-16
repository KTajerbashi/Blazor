using CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Patterns;

namespace CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Services;

public interface IBaseService<TEntity> : IUnitOfWork, IQueryDapper
{
    TEntity Get(Guid key);
    Task<TEntity> GetAsync(Guid key);

    TEntity Get(long id);
    Task<TEntity> GetAsync(long id);

    IEnumerable<TEntity> Get();
    Task<IEnumerable<TEntity>> GetAsync();

    Guid Insert(TEntity entity);
    Task<Guid> InsertAsync(TEntity entity);

    void Delete(Guid key);
    Task DeleteAsync(Guid key);

}
