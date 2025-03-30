using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Products.Events;

public class TitleChanged : IDomainEvent
{
    public string Title { get; }
    public long ProductId { get; set; }

    public TitleChanged(long productId, string title)
    {
        ProductId = productId;
        Title = title;
    }

}
