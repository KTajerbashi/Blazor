using BlazorWebApp.Models;

namespace BlazorWebApp.Repositories;

public interface IReportDataService
{
    List<Order> GetOrders();
    List<Product> GetProducts();
}
