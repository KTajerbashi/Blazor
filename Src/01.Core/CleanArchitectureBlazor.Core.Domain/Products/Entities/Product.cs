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
    public Product(IReadOnlyList<IDomainEvent> events) : base(events)
    {

    }
    public Product(long id, string title, string description, int price, long categoryId)
    {
        //Id = id;
        //Title = title;
        //Description = description;
        //Price = price;
        //CategoryId = categoryId;
        Apply(new ProductCreated(title, description, price, categoryId));
    }
    public void AddDiscount(string title, int value)
    {
        //Discount discount = new Discount(title,value);
        //_discounts.Add(discount);
        Apply(new DiscountCreated(title, value, Id));
    }
    public void ChangePrice(int price)
    {
        //Price = price;
        Apply(new PriceChanged(Id, price));
    }

    public void ChangeTitle(string title)
    {
        //Title = title;
        Apply(new TitleChanged(Id, title));
    }

    private void On(ProductCreated parameter)
    {
        Title = parameter.Title;
        Description = parameter.Description;
        Price = parameter.Price;
        CategoryId = parameter.CategoryId;
    }
    private void On(PriceChanged parameter)
    {
        Id = parameter.ProductId;
        Price = parameter.Value;
    }
    private void On(TitleChanged parameter)
    {
        Id = parameter.ProductId;
        Title = parameter.Title;
    }
}
