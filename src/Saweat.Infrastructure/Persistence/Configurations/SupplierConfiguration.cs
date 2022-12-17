using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saweat.Domain.Entities;
using Saweat.Shared;

namespace Saweat.Infrastructure.Persistence.Configurations;

public class SupplierConfiguration: IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(_ => _.Id);
        
        builder.Property(t => t.Name)
            .HasMaxLength(CommonConst.SmallStringLenght)
            .IsRequired();
        
        builder.Property(t => t.Surname)
            .HasMaxLength(CommonConst.BigStringLenght)
            .IsRequired();

        builder.Property(t => t.Name)
            .HasMaxLength(CommonConst.SmallStringLenght)
            .IsRequired();
    }
}
