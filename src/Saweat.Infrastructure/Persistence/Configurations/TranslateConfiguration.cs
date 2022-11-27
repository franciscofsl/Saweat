using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saweat.Application.Contracts.Translates;
using Saweat.Domain.Common;
using Saweat.Domain.Entities;
using Saweat.Shared;

namespace Saweat.Infrastructure.Persistence.Configurations;

public class TranslateConfiguration : IEntityTypeConfiguration<Translate>
{
    public void Configure(EntityTypeBuilder<Translate> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Culture).IsRequired();
        builder.Property(_ => _.Key).IsRequired();
        builder.Property(_ => _.Value).IsRequired();

        var translates = SpanishTranslates()
            .Concat(EnglishTranslate());

        builder.HasData(translates);
    }

    private List<Translate> SpanishTranslates()
    {
        return new List<Translate>()
        {
            new Translate(GuidGenerator.Create(), SupportedCultures.Spanish, CommonTranslates.Warning, "Aviso")
        };
    }

    private List<Translate> EnglishTranslate()
    {
        return new List<Translate>()
        {
            new Translate(GuidGenerator.Create(), SupportedCultures.English, CommonTranslates.Warning, "Warning")
        };
    }
}