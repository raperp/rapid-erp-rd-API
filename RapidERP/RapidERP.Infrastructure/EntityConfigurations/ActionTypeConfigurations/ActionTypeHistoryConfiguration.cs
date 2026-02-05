using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ActionTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ActionTypeConfigurations;

public class ActionTypeHistoryConfiguration : IEntityTypeConfiguration<ActionTypeHistory>
{
    public void Configure(EntityTypeBuilder<ActionTypeHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.ActionTypeId).HasColumnOrder(1);
        //builder.Property(x => x.LanguageId).HasColumnOrder(2);
        builder.Property(x => x.ExportTypeId).HasColumnOrder(3);
        builder.Property(x => x.ExportTo).HasColumnOrder(4);
        builder.Property(x => x.SourceURL).HasColumnOrder(5);
        builder.Property(x => x.Name).HasMaxLength(10).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false).HasColumnOrder(7);
        //builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(8);
        //builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(9);
        //builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(10);
        //builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(11);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(12);
        //builder.Property(x => x.Latitude).HasPrecision(9, 6).HasColumnOrder(13);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6).HasColumnOrder(14);
        //builder.Property(x => x.ActionBy).HasColumnOrder(15);
        //builder.Property(x => x.ActionAt).HasColumnOrder(16);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
