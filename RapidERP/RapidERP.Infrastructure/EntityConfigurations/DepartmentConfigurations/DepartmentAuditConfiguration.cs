using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.DepartmentModels;

namespace RapidERP.Infrastructure.EntityConfiguration.DepartmentConfigurations;
public class DepartmentAuditConfiguration : IEntityTypeConfiguration<DepartmentHistory>
{
    public void Configure(EntityTypeBuilder<DepartmentHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(3).IsRequired();
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
        builder.Property(x => x.SourceURL).IsRequired(false);
        builder.Property(x => x.ExportTo).IsRequired(false);
    }
}
