using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.RiderModels;

namespace RapidERP.Infrastructure.EntityConfiguration.RiderConfigurations;

public class RiderAuditConfiguration : IEntityTypeConfiguration<RiderHistory>
{
    public void Configure(EntityTypeBuilder<RiderHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.MobileNumber).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.CountryId).IsRequired(false);
        builder.Property(x => x.StateId).IsRequired(false);
        builder.Property(x => x.CityId).IsRequired(false);
        builder.Property(x => x.AreaId).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
        builder.Property(x => x.SourceURL).IsRequired(false);
        builder.Property(x => x.ExportTo).IsRequired(false);
    }
}
