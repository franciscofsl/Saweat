using FluentAssertions;
using Saweat.Application.Products.Commands.CreateProduct;
using Saweat.Shared;
using Saweat.Tests.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Saweat.Application.UnitTests.Tests.Products.Validations;

public class CreateProductCommandValidatorTest
{
    [Fact]
    public async Task Product_Code_Should_Not_Be_Empty()
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(new CreateProductCommand()
        {
            Code = string.Empty
        });
        validationResult.IsValid.Should().BeFalse();
        var error = validationResult.Errors.First();
        error.PropertyName.Should().Be(nameof(CreateProductCommand.Code));
    }
    
    [Fact]
    public async Task Product_Code_Should_Not_Be_Null()
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(new CreateProductCommand()
        {
            Code = null
        });
        validationResult.IsValid.Should().BeFalse();
        var error = validationResult.Errors.First();
        error.PropertyName.Should().Be(nameof(CreateProductCommand.Code));
    }
    
    [Fact]
    public async Task Product_Code_Should_Not_Be_Too_Long()
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(new CreateProductCommand()
        {
            Code = StringHelper.GenerateString(CommonConst.CodeMaxLenght + 1)
        });
        validationResult.IsValid.Should().BeFalse();
        var error = validationResult.Errors.First();
        error.PropertyName.Should().Be(nameof(CreateProductCommand.Code));
    }
}
