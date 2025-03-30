using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Products.Events;

public class PriceChanged : IDomainEvent
{
    public int Value { get; }
    public long ProductId { get; set; }

    public PriceChanged(long productId, int value)
    {
        Value = value;
        ProductId = productId;
    }

}
