using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MainModuleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.MainModuleConfigurations;

public class MainModuleHistoryConfiguration : IEntityTypeConfiguration<MainModuleHistory>
{
    public void Configure(EntityTypeBuilder<MainModuleHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(4).IsRequired();
        builder.Property(x => x.IconURL).IsRequired();
        //builder.Property(x => x.Latitude).HasPrecision(9, 6);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
