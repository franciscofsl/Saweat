using Saweat.Domain.Common;
using Saweat.Domain.Entities;

namespace Saweat.Domain.Events;

public class SupplierCreatedEvent : BaseEvent
{
    public SupplierCreatedEvent(Supplier item)
    {
        Item = item;
    }

    public Supplier Item { get; }
}
