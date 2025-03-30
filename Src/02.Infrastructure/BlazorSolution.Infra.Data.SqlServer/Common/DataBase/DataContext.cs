using BlazorSolution.Core.Domain.Categories.Entities;
using BlazorSolution.Core.Domain.Customers.Entities;
using BlazorSolution.Core.Domain.EventSourcing.Entities;
using BlazorSolution.Core.Domain.Orders.Entities;
using BlazorSolution.Core.Domain.Products.Entities;
using BlazorSolution.Core.Application.Common.Extensions;
using BlazorSolution.Core.Domain.Outbox.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

public class DataContext : BaseDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        modelBuilder.AddSecurityConfiguration();
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Discount> Discounts => Set<Discount>();
    public DbSet<EventSource> EventSources => Set<EventSource>();

}
