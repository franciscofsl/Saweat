using MediatR;
using Saweat.Application.Common.Interfaces;
using Saweat.Application.Contracts.Common;
using Saweat.Domain.Common;
using Saweat.Domain.Entities;
using Saweat.Domain.Events;

namespace Saweat.Application.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CommandResult<Guid>>
{
    private readonly IRepository<Supplier> _repository;
    private readonly CreateSupplierCommandValidator _validator;

    public CreateSupplierCommandHandler(IRepository<Supplier> repository,
        CreateSupplierCommandValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<CommandResult<Guid>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return CommandResult<Guid>.Invalid(validationResult.Errors);
        }

        var supplier = new Supplier(GuidGenerator.Create(), request.Name, request.Surname, request.IdentifyNumber);

        supplier.AddDomainEvent(new SupplierCreatedEvent(supplier));

        await _repository.InsertAsync(supplier);
        await _repository.SaveChangesAsync();

        return CommandResult<Guid>.Successful(supplier.Id);
    }
}
