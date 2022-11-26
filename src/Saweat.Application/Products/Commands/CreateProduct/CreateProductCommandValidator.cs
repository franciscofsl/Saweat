using FluentValidation;
using Saweat.Shared;

namespace Saweat.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(v => v.Code)
            .MaximumLength(CommonConst.CodeMaxLenght)
            .NotEmpty();
    }
}
