using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SupplierTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.SupplierTypeConfigurations;
public class SupplierTypeConfiguration : IEntityTypeConfiguration<SupplierType>
{
    public void Configure(EntityTypeBuilder<SupplierType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.VATNumber).HasMaxLength(60).IsRequired();
        builder.Property(x => x.Website).IsRequired(false);
        builder.Property(x => x.Phone).IsRequired(false);
        builder.Property(x => x.Street).IsRequired(false);
        builder.Property(x => x.PostCode).IsRequired(false);
        builder.Property(x => x.Website).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);        
    }
}
