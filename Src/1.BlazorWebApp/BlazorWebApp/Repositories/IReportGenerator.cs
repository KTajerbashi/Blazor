namespace BlazorWebApp.Repositories;

public interface IReportGenerator
{
    byte[] GenerateOrdersReport();
    byte[] GenerateProductsReport();
}
