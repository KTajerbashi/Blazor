using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Domain.Common;
using BlazorSolution.Core.Domain.Outbox.Entities;
using BlazorSolution.Infra.Data.SqlServer.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

namespace BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

public abstract class BaseDataContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
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

    public IEnumerable<string> GetIncludePaths(Type clrEntityType)
    {
        var entityType = Model.FindEntityType(clrEntityType);
        var includedNavigations = new HashSet<INavigation>();
        var stack = new Stack<IEnumerator<INavigation>>();
        while (true)
        {
            var entityNavigations = new List<INavigation>();
            foreach (var navigation in entityType.GetNavigations())
            {
                if (includedNavigations.Add(navigation))
                    entityNavigations.Add(navigation);
            }
            if (entityNavigations.Count == 0)
            {
                if (stack.Count > 0)
                    yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
            }
            else
            {
                foreach (var navigation in entityNavigations)
                {
                    var inverseNavigation = navigation.Inverse;
                    if (inverseNavigation != null)
                        includedNavigations.Add(inverseNavigation);
                }
                stack.Push(entityNavigations.GetEnumerator());
            }
            while (stack.Count > 0 && !stack.Peek().MoveNext())
                stack.Pop();
            if (stack.Count == 0) break;
            entityType = stack.Peek().Current.TargetEntityType;
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
