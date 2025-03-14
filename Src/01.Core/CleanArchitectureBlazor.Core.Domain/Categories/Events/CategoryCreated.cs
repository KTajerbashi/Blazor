using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Domain.Categories.Events;

public class CategoryCreated : IDomainEvent
{
    public string Title { get; }

    public CategoryCreated(string title)
    {
        Title = title;
    }
}
