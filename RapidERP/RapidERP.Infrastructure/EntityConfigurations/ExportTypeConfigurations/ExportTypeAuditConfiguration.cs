using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ExportTypeConfigurations;

public class ExportTypeAuditConfiguration : IEntityTypeConfiguration<ExportTypeHistory>
{
    public void Configure(EntityTypeBuilder<ExportTypeHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.ExportTypeId).HasColumnOrder(1);
        builder.Property(x => x.LanguageId).HasColumnOrder(2);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired().HasColumnOrder(3);
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false).HasColumnOrder(4);
        builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(7);
        builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(8);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(9);
        builder.Property(x => x.Latitude).HasPrecision(9, 6).HasColumnOrder(10);
        builder.Property(x => x.Longitude).HasPrecision(9, 6).HasColumnOrder(11);
        builder.Property(x => x.ActionBy).HasColumnOrder(12);
        builder.Property(x => x.ActionAt).HasColumnOrder(13);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.ActionTypeId);
        builder.Ignore(x => x.ExportTo);
        builder.Ignore(x => x.SourceURL);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
