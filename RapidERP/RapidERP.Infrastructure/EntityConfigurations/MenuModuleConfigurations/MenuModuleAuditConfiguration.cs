using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MenuModuleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.MenuModuleConfigurations;

public class MenuModuleAuditConfiguration : IEntityTypeConfiguration<MenuModuleAudit>
{
    public void Configure(EntityTypeBuilder<MenuModuleAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(3).IsRequired(false);
        builder.Property(x => x.SubModuleId).IsRequired(false);
        builder.Property(x => x.IconURL).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
        builder.Property(x => x.SourceURL).IsRequired(false);
        builder.Property(x => x.ExportTo).IsRequired(false);
    }
}
