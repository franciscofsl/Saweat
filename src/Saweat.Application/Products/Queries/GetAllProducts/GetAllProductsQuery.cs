using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saweat.Application.Common.Interfaces;
using Saweat.Application.Contracts.Common;
using Saweat.Domain.Entities;

namespace Saweat.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<QueryResult<ProductForListDto>>;

public class GetTodosQueryHandler : IRequestHandler<GetAllProductsQuery, QueryResult<ProductForListDto>>
{
    private readonly IReadOnlyRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler( IReadOnlyRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
 
    public async Task<QueryResult<ProductForListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = await _repository.GetQueryableAsync();
        
        var items = await query
            .AsNoTracking()
            .ProjectTo<ProductForListDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new QueryResult<ProductForListDto>(items);
    }
}
