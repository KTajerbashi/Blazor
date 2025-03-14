using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Domain.Common;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Common;

public class AggregateRepository<TContext, TAggregate, TId> : UnitOfWork<TContext>, IAggregateRepository<TAggregate, TId>
    where TAggregate : Aggregate<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
    where TContext : BaseDataContext
{
    public AggregateRepository(TContext context) : base(context)
    {
    }

    public string ContextId()
    {
        return Context.ContextId.InstanceId.ToString();
    }


    public async Task<TId> CreateAsync(TAggregate aggregate, CancellationToken cancellationToken)
    {
        await Context.Set<TAggregate>().AddAsync(aggregate, cancellationToken);
        //await Context.SaveChangesAsync(cancellationToken);
        return aggregate.Id;
    }



    public async Task DeleteAsync(Guid key, CancellationToken cancellationToken)
    {
        TAggregate aggregate = await Context.Set<TAggregate>().SingleAsync(item => item.Key!.Equals(key),cancellationToken);
        await DeleteAsync(aggregate, cancellationToken);
    }

    public async Task DeleteAsync(TAggregate aggregate, CancellationToken cancellationToken)
    {
        aggregate.Delete();
        //await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<TAggregate>> GetAsync(CancellationToken cancellationToken)
    {
        List<string> includePath = Context.GetIncludePaths(typeof(TAggregate)).ToList();
        IQueryable<TAggregate> query = Context.Set<TAggregate>().AsQueryable();
        foreach (var item in includePath)
        {
            query = query.Include(item);
        }
        return await query.ToListAsync(cancellationToken);
    }
    public async Task<TAggregate> GetAsync(TId id, CancellationToken cancellationToken)
    {
        List<string> includePath = Context.GetIncludePaths(typeof(TAggregate)).ToList();
        IQueryable<TAggregate> query = Context.Set<TAggregate>().AsQueryable();
        foreach (var item in includePath)
        {
            query = query.Include(item);
        }
        return await query.SingleAsync(item => item.Id!.Equals(id), cancellationToken);
    }
    public async Task<TAggregate> GetAsync(Guid key, CancellationToken cancellationToken)
    {
        List<string> includePath = Context.GetIncludePaths(typeof(TAggregate)).ToList();
        IQueryable<TAggregate> query = Context.Set<TAggregate>().AsQueryable();
        foreach (var item in includePath)
        {
            query = query.Include(item);
        }
        return await query.SingleOrDefaultAsync(item => item.Key!.Equals(key), cancellationToken);
    }

    public void SaveChange() => Context.SaveChanges();

    public async Task SaveChangeAsync() => await Context.SaveChangesAsync();
}
