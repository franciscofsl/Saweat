using FluentAssertions;
using Saweat.Application.Products.Commands.CreateProduct;
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
}
