using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ExportTypeConfiguration;

public class ExportTypeTrackerConfiguration : IEntityTypeConfiguration<ExportTypeTracker>
{
    public void Configure(EntityTypeBuilder<ExportTypeTracker> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ExportTo).HasMaxLength(30).IsRequired();
        builder.Property(x => x.SourceURL).IsRequired();
        builder.Property(x => x.Browser).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Location).HasMaxLength(40).IsRequired();
        builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired();
        builder.Property(x => x.GoogleMapUrl).IsRequired();
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Latitude).HasPrecision(9, 6).IsRequired();
        builder.Property(x => x.Longitude).HasPrecision(9, 6).IsRequired();
        builder.Property(x => x.ActionBy).IsRequired();
        builder.Property(x => x.ActionAt).IsRequired();
    }
}
