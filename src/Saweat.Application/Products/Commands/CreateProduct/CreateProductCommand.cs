using MediatR;
using Saweat.Application.Common.Interfaces;
using Saweat.Application.Contracts.Common;
using Saweat.Domain.Common;
using Saweat.Domain.Entities;
using Saweat.Domain.Events;

namespace Saweat.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<CommandResult<Guid>>
{
    public string Code { get; set; }

    public string Name { get; set; }
    
    public Guid SupplierId { get; set; }
    
    public int Stock { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResult<Guid>>
{
    private readonly IRepository<Product> _repository;
    private readonly CreateProductCommandValidator _validator;

    public CreateProductCommandHandler(IRepository<Product> repository,
        CreateProductCommandValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<CommandResult<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return CommandResult<Guid>.Invalid(validationResult.Errors);
        }

        var product = new Product(GuidGenerator.Create(), request.SupplierId, request.Code, request.Name, request.Stock);

        product.AddDomainEvent(new ProductCreatedEvent(product));

        await _repository.InsertAsync(product);
        await _repository.SaveChangesAsync();

        return CommandResult<Guid>.Successful(product.Id);
    }
}
