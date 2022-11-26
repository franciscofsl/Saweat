using MediatR;
using Saweat.Application.Contracts.Common;
using Saweat.Domain.Entities;
using Saweat.Domain.Events;

namespace Saweat.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<Guid>
{
    public string Code { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IDbContext _context;

    public CreateProductCommandHandler(IDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Code = request.Code
        };

        entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Set<Product>().Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
