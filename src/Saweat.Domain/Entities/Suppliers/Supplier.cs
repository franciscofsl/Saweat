using Saweat.Domain.Common;
using System.Collections.ObjectModel;

namespace Saweat.Domain.Entities;

public class Supplier : BaseAuditableEntity
{
    private readonly List<Product> _products = new();
    
    public Supplier()
    {
        
    }
    
    public Supplier(Guid id, string name, string surname, string identifyNumber)
        : base(id)
    {
        Name = name;
        Surname = surname;
        IdentifyNumber = identifyNumber;
    }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string IdentifyNumber { get; set; }

    public virtual IReadOnlyList<Product> Products => _products.AsReadOnly();
}
