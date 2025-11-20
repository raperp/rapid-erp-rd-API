using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MainModuleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.MainModuleConfigurations;

public class MainModuleAuditConfiguration : IEntityTypeConfiguration<MainModuleAudit>
{
    public void Configure(EntityTypeBuilder<MainModuleAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(3).IsRequired(false);
        builder.Property(x => x.IconURL).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
        builder.Property(x => x.SourceURL).IsRequired(false);
        builder.Property(x => x.ExportTo).IsRequired(false);
    }
}
