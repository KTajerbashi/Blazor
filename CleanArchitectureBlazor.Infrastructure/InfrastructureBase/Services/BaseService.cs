using CleanArchitectureBlazor.Application.ApplicationBase.Services;
using CleanArchitectureBlazor.Infrastructure.ApplicationContext;

namespace CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Services;

public abstract class BaseService<TEntity> : IBaseService<TEntity>
{
    protected DbContextApplication Context;

    protected BaseService(DbContextApplication context)
    {
        Context = context;
    }

    public void Delete(Guid key)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid key)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(Guid key)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> Get()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(Guid key)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Guid Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Guid InsertAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
