using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CityModels;

namespace RapidERP.Infrastructure.EntityConfiguration.CityConfigurations
{
    public class CityHistoryConfiguration : IEntityTypeConfiguration<CityHistory>
    {
        public void Configure(EntityTypeBuilder<CityHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(3).IsRequired();
            //builder.Property(x => x.Latitude).HasPrecision(9, 6);
            //builder.Property(x => x.Longitude).HasPrecision(9, 6);
            //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
            //builder.Property(x => x.ExportTypeId).IsRequired(false);
            //builder.Property(x => x.SourceURL).IsRequired(false);
            //builder.Property(x => x.ExportTo).IsRequired(false);
            builder.Property(x => x.StateId).IsRequired(false);
            builder.Property(x => x.CountryId).IsRequired(false);
        }
    }
}
