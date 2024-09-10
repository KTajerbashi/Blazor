namespace CleanArchitectureBlazor.Application.ApplicationBase.Pattern;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    Task BeginTransactionAsync();

    void CommitTransaction();
    Task CommitTransactionAsync();

    void RollbackTransaction();
    Task RollbackTransactionAsync();

    int SaveChanges();
    Task<int> SaveChangesAsync();
}


