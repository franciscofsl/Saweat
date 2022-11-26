using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saweat.Domain.Entities;
using Saweat.Shared;

namespace Saweat.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(t => t.Code)
            .HasMaxLength(CommonConst.CodeMaxLenght)
            .IsRequired();
    }
}
