using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ExportTypeConfigurations;

public class ExportTypeAuditConfiguration : IEntityTypeConfiguration<ExportTypeAudit>
{
    public void Configure(EntityTypeBuilder<ExportTypeAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.MenuId);
        builder.Ignore(x => x.ActionTypeId);
        builder.Ignore(x => x.ExportTo);
        builder.Ignore(x => x.SourceURL);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
