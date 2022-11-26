namespace Saweat.Application.Contracts.Common;

public sealed class QueryResult<TDto> where TDto : class 
{
    public QueryResult(IEnumerable<TDto> items)
    {
        Items = items.ToList().AsReadOnly();
    }
    
    public IReadOnlyCollection<TDto> Items { get; }
}
