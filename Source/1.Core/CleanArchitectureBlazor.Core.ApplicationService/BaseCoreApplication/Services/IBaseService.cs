using CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Patterns;
using System.Linq.Expressions;

namespace CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Services;

public interface IBaseService<TEntity> : IUnitOfWork, IQueryDapper
{
    TEntity Get(Guid key);
    Task<TEntity> GetAsync(Guid key);

    TEntity Get(long id);
    Task<TEntity> GetAsync(long id);

    IEnumerable<TEntity> Get();
    Task<IEnumerable<TEntity>> GetAsync();

    Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includes = ""
            );


    Guid Insert(TEntity entity);
    Task<Guid> InsertAsync(TEntity entity);

    void Delete(Guid key);
    Task DeleteAsync(Guid key);

}
