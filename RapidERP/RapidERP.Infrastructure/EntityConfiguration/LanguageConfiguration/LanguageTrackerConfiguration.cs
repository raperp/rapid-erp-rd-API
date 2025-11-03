using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfiguration;
public class LanguageTrackerConfiguration : IEntityTypeConfiguration<LanguageTracker>
{
    public void Configure(EntityTypeBuilder<LanguageTracker> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Browser).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Location).HasMaxLength(40).IsRequired();
        builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired();
        builder.Property(x => x.GoogleMapUrl).IsRequired();
        builder.Property(x => x.ActionBy).IsRequired();
        builder.Property(x => x.ActionAt).IsRequired();
        builder.Ignore(x => x.Latitude);
        builder.Ignore(x => x.Longitude);
        builder.Ignore(x => x.DeviceName);
        builder.Ignore(x => x.ActionTypeId);
        builder.Ignore(x => x.StatusTypeId);
    }
}
