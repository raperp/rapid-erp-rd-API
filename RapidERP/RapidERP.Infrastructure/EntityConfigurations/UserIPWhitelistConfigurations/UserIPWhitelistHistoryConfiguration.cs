using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.UserIPWhitelistModels;

namespace RapidERP.Infrastructure.EntityConfigurations.UserIPWhitelistConfigurations;

public class UserIPWhitelistHistoryConfiguration : IEntityTypeConfiguration<UserIPWhitelistHistory>
{
    public void Configure(EntityTypeBuilder<UserIPWhitelistHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.UserIPWhitelistId).HasColumnOrder(1);
        builder.Property(x => x.ActionTypeId).IsRequired(false).HasColumnOrder(2);
        builder.Property(x => x.ExportTypeId).IsRequired(false).HasColumnOrder(3);
        builder.Property(x => x.UserId).IsRequired().HasColumnOrder(4);
        builder.Property(x => x.IPAddress).HasMaxLength(15).IsRequired(false).HasColumnOrder(5);
        builder.Property(x => x.ExportTo).IsRequired(false).HasColumnOrder(6);
        builder.Property(x => x.SourceURL).IsRequired(false).HasColumnOrder(7);
        builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(8);
        builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(9);
        builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(10);
        builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(11);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(12);
        builder.Property(x => x.Latitude).HasPrecision(9, 6).HasColumnOrder(13);
        builder.Property(x => x.Longitude).HasPrecision(9, 6).HasColumnOrder(14);
        builder.Property(x => x.ActionBy).HasColumnOrder(15);
        builder.Property(x => x.ActionAt).HasColumnOrder(16);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.LanguageId);
        builder.Ignore(x => x.Name);
    }
}
