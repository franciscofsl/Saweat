using Saweat.Application.Common.Interfaces;
using Saweat.Domain.Entities;

namespace Saweat.Application.Products.Queries.GetAllProducts;

public class ProductForListDto : IMapFrom<Product>
{
    public Guid Id { get; set; }

    public string? Code { get; set; }
}
 