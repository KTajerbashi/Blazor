using CleanArchitectureBlazor.Core.Domain.Common;
using CleanArchitectureBlazor.Core.Domain.Products.Events;

namespace CleanArchitectureBlazor.Core.Domain.Products.Entities;

[Table("Products", Schema = "Business")]
public class Product : Aggregate
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Price { get; private set; }
    public long CategoryId { get; private set; }
    private List<Discount> _discounts =new();
    public IReadOnlyCollection<Discount> Discounts => _discounts;
    public Product(string title, string description, int price, long categoryId)
    {
        Title = title;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        AddEvent(new ProductCreated(title, description, price, categoryId));
    }
    public void AddDiscount(string title, int value)
    {
        Discount discount = new Discount(title,value);
        _discounts.Add(discount);
        AddEvent(new DiscountCreated(title, value, Id));
    }
}
