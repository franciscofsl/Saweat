using FluentAssertions;
using Saweat.Application.Common.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Saweat.Application.Integration.Tests.Translate;

public class SpanishTranslatesTests : TestBase
{
    [Fact]
    [UseCulture("es-ES")]
    public async Task Should_Localize_Translate()
    {
        var stringLocalizer = GetRequiredService<IStringLocalizer>();
        var value = stringLocalizer["Common:Warning"];
        value.Should().Be("Aviso");
    }
}
