using CleanArchitectureBlazor.Application.ApplicationBase.Services;
using CleanArchitectureBlazor.Core.CoreBase.Entities;
using CleanArchitectureBlazor.Infrastructure.ApplicationContext;
using CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Pattern;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Dapper;

namespace CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Services;

public abstract class BaseService<TEntity> : UnitOfWork<DbContextApplication>, IBaseService<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbConnection _dbConnection;
    protected BaseService(DbContextApplication context) : base(context)
    {
        _dbConnection = Context.Database.GetDbConnection();
    }

    public void Delete(Guid key)
    {
        var entity = Context.Set<TEntity>().Where(item => item.Key.Equals(key)).Single();
        entity.Delete();
        SaveChanges();
    }

    public async Task DeleteAsync(Guid key)
    {
        var entity = await Context.Set<TEntity>().Where(item => item.Key.Equals(key)).SingleAsync();
        entity.Delete();
        await SaveChangesAsync();
    }

    public async Task Execute(string query, object parameters)
    {
        await _dbConnection.ExecuteAsync(query, parameters);
    }

    public async Task<Model> Execute<Model>(string query, object parameters)
    {
        return await _dbConnection.ExecuteScalarAsync<Model>(query, parameters);
    }

    public TEntity Get(Guid key) => Context.Set<TEntity>().Where(item => item.Key.Equals(key)).Single();

    public TEntity Get(long id) => Context.Set<TEntity>().Find(id);

    public IEnumerable<TEntity> Get() => Context.Set<TEntity>().Where(item => !item.IsDeleted && item.IsActive).ToList();

    public async Task<TEntity> GetAsync(Guid key) => await Context.Set<TEntity>().Where(item => item.Key.Equals(key)).SingleAsync();

    public async Task<TEntity> GetAsync(long id) => await Context.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> GetAsync() => await Context.Set<TEntity>().Where(item => !item.IsDeleted && item.IsActive).ToListAsync();

    public Guid Insert(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        SaveChanges();
        return entity.Key;
    }

    public async Task<Guid> InsertAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        SaveChanges();
        return entity.Key;
    }

    public async Task<TModel> ReadFirstAsync<TModel>(string query, object parameters)
    {
        return await _dbConnection.QueryFirstAsync<TModel>(query, parameters, commandType: System.Data.CommandType.Text);
    }

    public async Task<TModel> ReadFirstBySpAsync<TModel>(string spName, object parameters)
    {
        return await _dbConnection.QueryFirstAsync<TModel>(spName.Trim(), parameters, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<TModel>> ReadListAsync<TModel>(string query, object parameters)
    {
        return await _dbConnection.QueryAsync<TModel>(query, parameters, commandType: System.Data.CommandType.Text);
    }

    public async Task<IEnumerable<TModel>> ReadListBySpAsync<TModel>(string spName, object parameters)
    {
        return await _dbConnection.QueryAsync<TModel>(spName.Trim(), parameters, commandType: System.Data.CommandType.StoredProcedure);
    }
}
