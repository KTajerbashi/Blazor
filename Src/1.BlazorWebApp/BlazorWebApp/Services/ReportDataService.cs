using BlazorWebApp.Models;
using BlazorWebApp.Repositories;

namespace BlazorWebApp.Services;
public class ReportDataService : IReportDataService
{
    public List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = DateTime.Now.AddDays(-10),
                CustomerName = "John Doe",
                TotalAmount = 1500.50m,
                Products = GetProducts().Where(p => p.Id <= 3).ToList()
            },
            new Order
            {
                OrderId = 2,
                OrderDate = DateTime.Now.AddDays(-5),
                CustomerName = "Jane Smith",
                TotalAmount = 2750.25m,
                Products = GetProducts().Where(p => p.Id > 3).ToList()
            }
        };
    }

    public List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.00m, Quantity = 5, Category = "Electronics" },
            new Product { Id = 2, Name = "Mouse", Price = 25.50m, Quantity = 20, Category = "Electronics" },
            new Product { Id = 3, Name = "Keyboard", Price = 75.00m, Quantity = 15, Category = "Electronics" },
            new Product { Id = 4, Name = "Monitor", Price = 300.00m, Quantity = 8, Category = "Electronics" },
            new Product { Id = 5, Name = "Desk", Price = 200.00m, Quantity = 12, Category = "Furniture" }
        };
    }
}