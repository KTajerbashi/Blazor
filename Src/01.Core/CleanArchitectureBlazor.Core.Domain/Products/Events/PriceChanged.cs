using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Domain.Products.Events;

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
