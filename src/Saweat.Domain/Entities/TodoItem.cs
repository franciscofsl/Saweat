using Saweat.Domain.Common;

namespace Saweat.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Code { get; set; }
}
