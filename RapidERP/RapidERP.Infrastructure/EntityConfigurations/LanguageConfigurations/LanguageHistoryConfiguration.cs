using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfigurations;
public class LanguageHistoryConfiguration : IEntityTypeConfiguration<LanguageHistory>
{
    public void Configure(EntityTypeBuilder<LanguageHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.LanguageId).HasMaxLength(40).IsRequired().HasColumnOrder(1);
        builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired().HasColumnOrder(2);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(3);
        builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired().HasColumnOrder(4);
        builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.IconURL).IsRequired().HasColumnOrder(6);
        //builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(7);
        //builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(8);
        //builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(9);
        //builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(10);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(11);
        //builder.Property(x => x.Latitude).HasPrecision(9, 6).HasColumnOrder(12);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6).HasColumnOrder(13);
        //builder.Property(x => x.ActionBy).HasColumnOrder(14);
        //builder.Property(x => x.ActionAt).HasColumnOrder(15);

        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);
        //builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.ActionTypeId);
        //builder.Ignore(x => x.ExportTypeId);
        //builder.Ignore(x => x.ExportTo);
        //builder.Ignore(x => x.SourceURL);
    }
}
