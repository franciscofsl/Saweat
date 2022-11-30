using FluentAssertions;
using Saweat.Domain.Entities;
using Xunit;

namespace Saweat.Domain.Tests.Products;

public class ProductTest
{
    [Fact]
    public void Product_Set_Code()
    {
        var product = new Product();
        var newCode = "New Code";
        product.SetCode(newCode);
        product.Code.Should().Be(newCode);
    }
}
