using Saweat.Application.Contracts.Common;

namespace Saweat.Application.Contracts.Products;

public interface ICrudService<TDto> where TDto : class
{
    // Task CreateAsync(TDto dto);
    // Task UpdateAsync(TDto dto);
    // Task DeleteAsync(TDto id);
    Task<QueryResult<TDto>> GetAllAsync();
    // Task GetByIdAsync(TDto dto);
}