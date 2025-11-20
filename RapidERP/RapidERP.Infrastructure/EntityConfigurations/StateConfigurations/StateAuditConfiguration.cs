using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SateModules;

namespace RapidERP.Infrastructure.EntityConfiguration.StateConfigurations
{
    public class StateAuditConfiguration : IEntityTypeConfiguration<StateAudit>
    {
        public void Configure(EntityTypeBuilder<StateAudit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(4).IsRequired();
            builder.Property(x => x.Latitude).HasPrecision(9, 6);
            builder.Property(x => x.Longitude).HasPrecision(9, 6);
            builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
            builder.Property(x => x.ExportTypeId).IsRequired(false);
            builder.Property(x => x.SourceURL).IsRequired(false);
            builder.Property(x => x.ExportTo).IsRequired(false);
            builder.Property(x => x.CountryId).IsRequired(false);
            builder.Property(x => x.MenuId).IsRequired(false);
            builder.Property(x => x.LanguageId).IsRequired(false);
        }
    }
}
