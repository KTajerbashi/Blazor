using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Products.Events;

public class DiscountCreated : IDomainEvent
{
    public string Title { get; }
    public int Value { get; }
    public long ProductId { get; set; }
    public DiscountCreated(string title, int value, long productId)
    {
        Title = title;
        Value = value;
        ProductId = productId;
    }
}
