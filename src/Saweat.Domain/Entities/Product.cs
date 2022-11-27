using Saweat.Domain.Common;

namespace Saweat.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public Product()
    {
        
    }
    
    public Product(Guid id)
        : base(id)
    {
    }

    public string Code { get; set; }
}