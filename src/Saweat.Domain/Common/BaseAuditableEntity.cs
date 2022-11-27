namespace Saweat.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    protected BaseAuditableEntity()
    {
        
    }
    
    protected BaseAuditableEntity(Guid id) 
        : base(id)
    {
    }
    
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
