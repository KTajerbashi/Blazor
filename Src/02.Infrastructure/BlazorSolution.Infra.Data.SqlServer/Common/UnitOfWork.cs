using BlazorSolution.Core.Application.Common;
using BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

namespace BlazorSolution.Infra.Data.SqlServer.Common;

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseDataContext
{
    protected readonly TContext Context;
    protected UnitOfWork(TContext context)
    {
        Context = context;
    }
    public void BeginTransaction() => Context.Database.BeginTransaction();
    public async Task BeginTransactionAsync() => await Context.Database.BeginTransactionAsync();
    public void CommitTransaction() => Context.Database.CommitTransaction();
    public async Task CommitTransactionAsync() => await Context.Database.CommitTransactionAsync();
    public void RollbackTransaction() => Context.Database.RollbackTransaction();
    public async Task RollbackTransactionAsync() => await Context.Database.RollbackTransactionAsync();
}