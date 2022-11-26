using AutoMapper;
using Saweat.Application.Products.Queries.GetAllProducts;
using Saweat.Domain.Entities;

namespace Saweat.Application.Products;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, ProductForListDto>();
    }
}
