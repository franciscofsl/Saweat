using FluentAssertions;
using Saweat.Application.Products.Commands.CreateProduct;
using Saweat.Application.Suppliers.Commands.CreateSupplier;
using Saweat.Shared;
using Saweat.Tests.Helpers;
using System.Threading.Tasks;
using Xunit;

namespace Saweat.Application.Integration.Tests.Suppliers.Commands;

public class CreateSupplierTests : TestBase
{
    [Fact]
    public async Task Create_Product()
    {
        var commandResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = "Name",
            Surname = "Surname",
            IdentifyNumber = "IdentifyNumber"
        });

        commandResult.AttachedObject.Should().NotBeEmpty();
        commandResult.Errors.Should().BeEmpty();
        commandResult.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Not_Create_Supplier_With_Empty_Name()
    {
        var commandResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = string.Empty,
            Surname = "Surname",
            IdentifyNumber = "IdentifyNumber"
        });

        commandResult.AttachedObject.Should().BeEmpty();
        commandResult.Errors.Should().HaveCountGreaterThan(0);
        commandResult.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task Should_Not_Create_Supplier_With_Null_Name()
    {
        var commandResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = null,
            Surname = "Surname",
            IdentifyNumber = "IdentifyNumber"
        });

        commandResult.AttachedObject.Should().BeEmpty();
        commandResult.Errors.Should().HaveCountGreaterThan(0);
        commandResult.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task Should_Not_Create_Supplier_With_Empty_Surname()
    {
        var commandResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = "Name",
            Surname = string.Empty,
            IdentifyNumber = "IdentifyNumber"
        });

        commandResult.AttachedObject.Should().BeEmpty();
        commandResult.Errors.Should().HaveCountGreaterThan(0);
        commandResult.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task Should_Not_Create_Supplier_With_Null_Surname()
    {
        var commandResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = "Name",
            Surname = null,
            IdentifyNumber = "IdentifyNumber"
        });

        commandResult.AttachedObject.Should().BeEmpty();
        commandResult.Errors.Should().HaveCountGreaterThan(0);
        commandResult.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task Should_Not_Create_Supplier_With_Empty_IdentifyNumber()
    {
        var commandResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = "Name",
            Surname = "Surname",
            IdentifyNumber = string.Empty
        });

        commandResult.AttachedObject.Should().BeEmpty();
        commandResult.Errors.Should().HaveCountGreaterThan(0);
        commandResult.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task Should_Not_Create_Supplier_With_Null_IdentifyNumber()
    {
        var commandResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = "Name",
            Surname = "Surname",
            IdentifyNumber = null
        });

        commandResult.AttachedObject.Should().BeEmpty();
        commandResult.Errors.Should().HaveCount(1);
        commandResult.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task Should_Not_Create_Supplier_With_Duplicated_IdentifyNumber()
    {
        var duplicatedIdentifyNumber = "234235";
        await SendAsync(new CreateSupplierCommand()
        {
            Name = "Name",
            Surname = "Surname",
            IdentifyNumber = duplicatedIdentifyNumber
        });
        
        var duplicatedResult = await SendAsync(new CreateSupplierCommand()
        {
            Name = "Name",
            Surname = "Surname",
            IdentifyNumber = duplicatedIdentifyNumber
        });

        duplicatedResult.AttachedObject.Should().BeEmpty();
        duplicatedResult.Errors.Should().HaveCount(1);
        duplicatedResult.IsValid.Should().BeFalse();
    }
}
