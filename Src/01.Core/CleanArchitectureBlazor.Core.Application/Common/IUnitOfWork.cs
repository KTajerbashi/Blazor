namespace CleanArchitectureBlazor.Core.Application.Common;

public interface IUnitOfWork
{
    void BeginTransaction();
    Task BeginTransactionAsync();

    void CommitTransaction();
    Task CommitTransactionAsync();

    void RollbackTransaction();
    Task RollbackTransactionAsync();

}
