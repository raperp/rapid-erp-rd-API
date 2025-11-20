using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SupplierTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.SupplierTypeConfigurations;
public class SupplierTypeAuditConfiguration : IEntityTypeConfiguration<SupplierTypeAudit>
{
    public void Configure(EntityTypeBuilder<SupplierTypeAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.VATNumber).HasMaxLength(60).IsRequired();
        builder.Property(x => x.Website).IsRequired(false);
        builder.Property(x => x.Phone).IsRequired(false);
        builder.Property(x => x.Street).IsRequired(false);
        builder.Property(x => x.PostCode).IsRequired(false);
        builder.Property(x => x.Website).IsRequired(false);
        builder.Property(x => x.CountryId).IsRequired(false);
        builder.Property(x => x.CurrencyId).IsRequired(false);
        builder.Property(x => x.LanguageId).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
    }
}
