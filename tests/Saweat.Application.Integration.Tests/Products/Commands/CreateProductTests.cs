using FluentAssertions;
using Saweat.Application.Products.Commands.CreateProduct;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Saweat.Application.Integration.Tests.Products.Commands;

public class CreateProductTests : TestBase
{
    [Fact]
    public async Task Create_Product()
    {
        var productId = await SendAsync(new CreateProductCommand()
        {
            Code = "Code"
        });
        productId.Should().NotBe(Guid.Empty);
    }
}
