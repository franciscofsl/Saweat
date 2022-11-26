using MediatR;
using Saweat.Application.Common.Interfaces;
using Saweat.Application.Contracts.Common;
using Saweat.Domain.Entities;
using Saweat.Domain.Events;

namespace Saweat.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<Guid>
{
    public string? Code { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IRepository<Product> _repository;

    public CreateProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Code = request.Code
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        await _repository.InsertAsync(product);
        await _repository.SaveChangesAsync();

        return product.Id;
    }
}
