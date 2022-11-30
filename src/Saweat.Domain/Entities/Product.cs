using Saweat.Domain.Common;

namespace Saweat.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public Product()
    {
        
    }
    
    public Product(Guid id, string code)
        : base(id)
    {
        Code = code;
    }

    public string Code { get; private set; }

    public void SetCode(string input)
    {
        Code = input;
    }
}