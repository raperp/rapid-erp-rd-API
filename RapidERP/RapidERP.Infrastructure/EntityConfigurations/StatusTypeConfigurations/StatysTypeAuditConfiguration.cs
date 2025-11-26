using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.StatusTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.StatusTypeConfigurations;

public class StatysTypeAuditConfiguration : IEntityTypeConfiguration<StatusTypeAudit>
{
    public void Configure(EntityTypeBuilder<StatusTypeAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
