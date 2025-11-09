using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.EntityConfiguration.TenantConfiguration;
public class TenantAuditConfiguration : IEntityTypeConfiguration<TenantAudit>
{
    public void Configure(EntityTypeBuilder<TenantAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.CountryId).IsRequired(false);
        builder.Property(x => x.StateId).IsRequired(false);
        builder.Property(x => x.Contact).HasMaxLength(3).IsRequired(false);
        builder.Property(x => x.Phone).HasMaxLength(5).IsRequired(false);
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.Address).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.Website).HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
    }
}
