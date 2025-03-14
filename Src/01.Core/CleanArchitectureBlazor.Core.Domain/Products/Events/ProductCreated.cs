using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Domain.Products.Events;

public class ProductCreated : IDomainEvent
{
    public string Title { get; }
    public string Description { get; }
    public int Price { get; }
    public long CategoryId { get; }
    public ProductCreated(string title, string description, int price, long categoryId)
    {
        Title = title;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}