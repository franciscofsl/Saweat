using Microsoft.AspNetCore.Mvc;
using Saweat.Application.Contracts.Common;
using Saweat.Application.Contracts.Products;

namespace Saweat.Blazor.Server.Controllers;

[ApiController]
[Route("app/api/[controller]")]
public class ProductsController : Controller, ICrudService<ProductForListDto>
{
    [HttpGet]
    public async Task<QueryResult<ProductForListDto>> GetAllAsync()
    {
        var items = Enumerable.Range(1, 10)
            .Select(_ => new ProductForListDto
            { 
                Code = $"Code {_}",
            });

        return new QueryResult<ProductForListDto>(items);
    }
}
