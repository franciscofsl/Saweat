using Saweat.Domain.Common;
using Saweat.Domain.Entities;

namespace Saweat.Domain.Events;

public class ProductCreatedEvent : BaseEvent
{
    public ProductCreatedEvent(Product item)
    {
        Item = item;
    }

    public Product Item { get; }
}
