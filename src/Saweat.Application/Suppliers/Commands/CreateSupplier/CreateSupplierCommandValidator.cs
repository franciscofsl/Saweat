using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Saweat.Application.Common.Interfaces;
using Saweat.Domain.Entities;

namespace Saweat.Application.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    private readonly IRepository<Supplier> _supplierRepository;
    
    public CreateSupplierCommandValidator(IRepository<Supplier> supplierRepository)
    {
        _supplierRepository = supplierRepository;
        
        RuleFor(_ => _.Name)
            .NotEmpty();

        RuleFor(_ => _.Surname)
            .NotEmpty();

        RuleFor(_ => _.IdentifyNumber)
            .NotEmpty();
        
        RuleFor(x => x).MustAsync(async (createSupplierCommand ,cancellation) => {
            bool exists = await _supplierRepository
                .AnyAsync(_ => _.IdentifyNumber.Equals(createSupplierCommand.IdentifyNumber, StringComparison.InvariantCultureIgnoreCase) &&
                               _.Id != createSupplierCommand.Id);
            return !exists;
        });
    }
}
