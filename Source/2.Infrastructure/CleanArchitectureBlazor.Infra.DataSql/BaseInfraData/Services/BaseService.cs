﻿using CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Services;
using CleanArchitectureBlazor.Core.Domain.BaseCoreDomain;
using CleanArchitectureBlazor.Infra.DataSql.BaseInfraData.Pattern;
using CleanArchitectureBlazor.Infra.DataSql.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq.Expressions;

namespace CleanArchitectureBlazor.Infra.DataSql.BaseInfraData.Services;

public abstract class BaseService<TEntity> : UnitOfWork<DbContextApplication>, IBaseService<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbConnection _dbConnection;
    private readonly DbSet<TEntity> _dbSet;
    protected BaseService(DbContextApplication context) : base(context)
    {
        _dbConnection = Context.Database.GetDbConnection();
        _dbSet = Context.Set<TEntity>();
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

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includes = "")
    {
        IQueryable<TEntity> query = _dbSet;
        if (where is not null)
            query.Where(where);
        if (orderBy is not null)
            query = orderBy(query);
        if (!string.IsNullOrEmpty(includes))
        {
            foreach (string include in includes.Split(','))
            {
                query = query.Include(include);
            }
        }

        return await query.ToListAsync();
    }

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
