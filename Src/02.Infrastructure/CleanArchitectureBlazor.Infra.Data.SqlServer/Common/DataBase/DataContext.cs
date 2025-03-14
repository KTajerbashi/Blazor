using CleanArchitectureBlazor.Core.Domain.Categories.Entities;
using CleanArchitectureBlazor.Core.Domain.Customers.Entities;
using CleanArchitectureBlazor.Core.Domain.Orders.Entities;
using CleanArchitectureBlazor.Core.Domain.Outbox.Entities;
using CleanArchitectureBlazor.Core.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

public class DataContext : BaseDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
 
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Discount> Discounts => Set<Discount>();

}
