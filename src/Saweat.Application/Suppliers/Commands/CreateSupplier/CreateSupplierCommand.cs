using MediatR;
using Saweat.Application.Contracts.Common;

namespace Saweat.Application.Suppliers.Commands.CreateSupplier;

public record CreateSupplierCommand : IRequest<CommandResult<Guid>>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string Surname { get; set; }

    public string IdentifyNumber { get; set; }
}
