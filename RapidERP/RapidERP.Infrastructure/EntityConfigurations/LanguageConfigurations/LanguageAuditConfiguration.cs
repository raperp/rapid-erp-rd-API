using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfigurations;
public class LanguageAuditConfiguration : IEntityTypeConfiguration<LanguageAudit>
{
    public void Configure(EntityTypeBuilder<LanguageAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.LanguageId).HasColumnOrder(1).HasMaxLength(40).IsRequired();
        builder.Property(x => x.ISONumeric).HasColumnOrder(2).HasMaxLength(4).IsRequired();
        builder.Property(x => x.Name).HasColumnOrder(3).HasMaxLength(40).IsRequired();
        builder.Property(x => x.ISO2Code).HasColumnOrder(4).HasMaxLength(2).IsRequired();
        builder.Property(x => x.ISO3Code).HasColumnOrder(5).HasMaxLength(3).IsRequired();
        builder.Property(x => x.IconURL).HasColumnOrder(6).IsRequired();
        builder.Property(x => x.Browser).HasColumnOrder(7).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Location).HasColumnOrder(8).HasMaxLength(40).IsRequired();
        builder.Property(x => x.DeviceIP).HasColumnOrder(9).HasMaxLength(15).IsRequired();
        builder.Property(x => x.LocationURL).HasColumnOrder(10).IsRequired();
        builder.Property(x => x.DeviceName).HasColumnOrder(11).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Latitude).HasColumnOrder(12).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasColumnOrder(13).HasPrecision(9, 6);
        builder.Property(x => x.ActionBy).HasColumnOrder(14);
        builder.Property(x => x.ActionAt).HasColumnOrder(15);
       
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.ActionTypeId);
        builder.Ignore(x => x.ExportTypeId);
        builder.Ignore(x => x.ExportTo);
        builder.Ignore(x => x.SourceURL);
    }
}
