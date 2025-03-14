using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Domain.Common;
using CleanArchitectureBlazor.Core.Domain.Outbox.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

public abstract class BaseDataContext : DbContext
{
    protected BaseDataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<EventOutbox> EventOutboxes => Set<EventOutbox>();

    #region override
    public override int SaveChanges()
    {
        HandleBeforeSaveChange();
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        HandleBeforeSaveChange();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        HandleBeforeSaveChange();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleBeforeSaveChange();
        return base.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region DbSets
    #endregion

    #region Methods
    private void HandleBeforeSaveChange()
    {
        AddToOutbox();
    }
    #endregion

    private void AddToOutbox()
    {
        var entities = ChangeTracker
            .Entries<Aggregate>()
            .Where(item => item.State == EntityState.Added || item.State == EntityState.Modified)
            .Select(item => item.Entity).ToList();

        var dateTime = DateTime.Now;
        foreach (var entity in entities)
        {
            foreach (var @event in entity.Events)
            {
                EventOutboxes.Add(new EventOutbox()
                {
                    EventId = Guid.NewGuid(),
                    AccuredByUserId = 1,
                    AccureOn = dateTime,
                    Aggregated = 1,
                    AggregateName = entity.GetType().Name,
                    AggregateTypeName = entity.GetType().FullName,
                    EventName = @event.GetType().Name,
                    EventTypeName = @event.GetType().FullName,
                    EventPayload = JsonConvert.SerializeObject(@event),
                    IsProcessed = false

                });

            }
        }
    }

    private void DispatchEvents()
    {
        var dispatcher = this.GetService<IDomainEventDispatcher>();

        var entities = ChangeTracker
            .Entries<Aggregate>()
            .Where(item => item.State == EntityState.Added || item.State == EntityState.Modified)
            .Select(item => item.Entity)
            .ToList();

        foreach (var entity in entities)
        {
            dispatcher.Dispatch(entity.Events);
            entity.ClearEvent();
        }
    }
}
