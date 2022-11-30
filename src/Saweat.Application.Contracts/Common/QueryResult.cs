using System.Text.Json.Serialization;

namespace Saweat.Application.Contracts.Common;

public sealed class   QueryResult<TItem> where TItem : class
{
    public int TotalCount => Items?.Count() ?? 0;
    
    public IEnumerable<TItem> Items { get; set;  }

    public QueryResult()
    {
        
    } 
    
    [JsonConstructor]
    public QueryResult(IEnumerable<TItem> items)
    { 
        Items = items;
    }
    

    public static QueryResult<TItem> Empty => new(Enumerable.Empty<TItem>());
}