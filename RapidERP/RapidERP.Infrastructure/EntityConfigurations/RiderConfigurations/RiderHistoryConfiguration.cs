using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.RiderModels;

namespace RapidERP.Infrastructure.EntityConfiguration.RiderConfigurations;

public class RiderHistoryConfiguration : IEntityTypeConfiguration<RiderHistory>
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
        builder.Property(x => x.ExportTypeId).IsRequired(false);
        builder.Property(x => x.SourceURL).IsRequired(false);
        builder.Property(x => x.ExportTo).IsRequired(false);
        builder.Property(x => x.Browser).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Location).HasMaxLength(40).IsRequired();
        builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired();
        builder.Property(x => x.LocationURL).IsRequired();
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.ActionBy);
        builder.Property(x => x.ActionAt);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.LanguageId);
        
    }
}
