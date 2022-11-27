using Saweat.Domain.Common;

namespace Saweat.Domain.Entities;

public class Translate : BaseAuditableEntity
{
    public string Culture { get; }
    public string Key { get; }
    public string Value { get; }

    public Translate()
    {
        
    }
    
    public Translate(Guid id, string culture, string key, string value) : base(id)
    {
        Culture = culture;
        Key = key;
        Value = value;
    }
}
