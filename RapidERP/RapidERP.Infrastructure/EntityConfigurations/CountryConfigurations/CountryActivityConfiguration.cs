using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Infrastructure.EntityConfigurations.CountryConfigurations;

public class CountryActivityConfiguration : IEntityTypeConfiguration<CountryActivity>
{
    public void Configure(EntityTypeBuilder<CountryActivity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CountryId);
        builder.Property(x => x.ActivityTypeId);
        builder.Property(x => x.PageViewStartedAt);
        builder.Property(x => x.PageViewEndedAt);
        builder.Property(x => x.Browser).HasMaxLength(50);
        builder.Property(x => x.Location).HasMaxLength(100);
        builder.Property(x => x.LocationURL);
        builder.Property(x => x.DeviceIP).HasMaxLength(45);
        builder.Property(x => x.DeviceName).HasMaxLength(50);
        builder.Property(x => x.OS).HasMaxLength(20);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.ActionTypeId);
        builder.Property(x => x.ActionBy);
        builder.Property(x => x.ActionAt);
    }
}
