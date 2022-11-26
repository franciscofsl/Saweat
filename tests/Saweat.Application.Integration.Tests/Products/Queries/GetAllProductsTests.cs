using FluentAssertions;
using Saweat.Application.Products.Commands.CreateProduct;
using Saweat.Application.Products.Queries.GetAllProducts;
using System.Threading.Tasks;
using Xunit;

namespace Saweat.Application.Integration.Tests.Products.Queries;

public class GetAllProductsTests : TestBase
{
    [Fact]
    public async Task Should_Get_All_Products()
    {
        for (int i = 0; i < 10; i++)
        {
            await SendAsync(new CreateProductCommand()
            {
                Code = $"Code {i}"
            });
        }
        
        var response = await SendAsync(new GetAllProductsQuery());
        response.Items.Should().HaveCount(10);
    }
}
