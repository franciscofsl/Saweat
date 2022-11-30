using Saweat.Application.Contracts.Common;
using Saweat.Application.Contracts.Products;
using System.Net.Http.Json;

namespace Saweat.Blazor.Client.Common;

public abstract class BaseCrudClient<TDto> : ICrudService<TDto> where TDto : class
{
    private readonly HttpClient _httpClient;
    
    public BaseCrudClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    protected abstract string BaseUrl { get; }

    public async Task<QueryResult<TDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<QueryResult<TDto>>($"api/{BaseUrl}");
    }
} 