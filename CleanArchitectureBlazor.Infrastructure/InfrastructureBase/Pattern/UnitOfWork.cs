using CleanArchitectureBlazor.Application.ApplicationBase.Pattern;
using CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Databases;

namespace CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Pattern;

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseContext
{
    protected TContext Context;
    protected UnitOfWork(TContext context)
    {
        Context = context;
    }

    public void BeginTransaction() => Context.Database.BeginTransaction();
   
    public async Task BeginTransactionAsync() => await Context.Database.BeginTransactionAsync();

    public void CommitTransaction() => Context.Database.CommitTransaction();

    public async Task CommitTransactionAsync() => await Context.Database.CommitTransactionAsync();

    public void Dispose()
    {
        Context.Dispose();
    }

    public void RollbackTransaction() => Context.Database.RollbackTransaction();

    public async Task RollbackTransactionAsync() => await Context.Database.RollbackTransactionAsync();

    public int SaveChanges() => Context.SaveChanges();
   
    public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
   
}
