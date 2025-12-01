using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.RoleModules;

namespace RapidERP.Infrastructure.EntityConfigurations.RoleConfigurations;

public class RoleAuditConfiguration : IEntityTypeConfiguration<RoleHistory>
{
    public void Configure(EntityTypeBuilder<RoleHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
    }
}
