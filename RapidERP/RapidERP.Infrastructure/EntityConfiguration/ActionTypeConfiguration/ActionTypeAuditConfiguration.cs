using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ActionTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ActionTypeConfiguration;
public class ActionTypeAuditConfiguration : IEntityTypeConfiguration<ActionTypeAudit>
{
    public void Configure(EntityTypeBuilder<ActionTypeAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
        builder.Ignore(x => x.StatusType);
        builder.Ignore(x => x.StatusTypeId);
    }
}
