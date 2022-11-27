using FluentAssertions;
using Saweat.Application.Integration.Tests.Helpers;
using Saweat.Application.Products.Commands.CreateProduct;
using Saweat.Shared;
using System.Threading.Tasks;
using Xunit;

namespace Saweat.Application.Integration.Tests.Products.Commands;

public class CreateProductTests : TestBase
{
    [Fact]
    public async Task Create_Product()
    {
        var commandResult = await SendAsync(new CreateProductCommand()
        {
            Code = "Code"
        });
        
        commandResult.AttachedObject.Should().NotBeEmpty();
        commandResult.Errors.Should().BeEmpty();
        commandResult.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Not_Create_Product_If_Code_Is_To_Long()
    {
        var commandResult = await SendAsync(new CreateProductCommand()
        {
            Code = StringHelper.GenerateString(CommonConst.CodeMaxLenght + 1)
        });
        
        commandResult.AttachedObject.Should().BeEmpty();
        commandResult.Errors.Should().HaveCount(1);
        commandResult.IsValid.Should().BeFalse();
    }
}
