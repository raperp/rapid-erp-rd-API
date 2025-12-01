using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.AreaModules;

namespace RapidERP.Infrastructure.EntityConfiguration.AreaConfigurations
{
    public class AreaAuditConfiguration : IEntityTypeConfiguration<AreaHistory>
    {
        public void Configure(EntityTypeBuilder<AreaHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Latitude).HasPrecision(9, 6);
            builder.Property(x => x.Longitude).HasPrecision(9, 6);
            builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
            builder.Property(x => x.ExportTypeId).IsRequired(false);
            builder.Property(x => x.SourceURL).IsRequired(false);
            builder.Property(x => x.ExportTo).IsRequired(false);
            builder.Property(x => x.StateId).IsRequired(false);
            builder.Property(x => x.CountryId).IsRequired(false);
            builder.Property(x => x.CityId).IsRequired(false);
        }
    }
}
