using Saweat.Domain.Common;

namespace Saweat.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public Product()
    {
        
    }
    
    public Product(Guid id, Guid supplierId, string code, string name, int stock)
        : base(id)
    {
        SupplierId = supplierId;
        Code = code;
        Name = name;
        Stock = stock;
    }

    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public Guid SupplierId { get;  set; }
    
    public int Stock { get; set; }
    
    public virtual Supplier Supplier { get; set; }
    
 
}