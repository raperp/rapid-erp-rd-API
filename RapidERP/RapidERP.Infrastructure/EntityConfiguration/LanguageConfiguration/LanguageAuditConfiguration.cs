using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfiguration;
public class LanguageAuditConfiguration : IEntityTypeConfiguration<LanguageAudit>
{
    public void Configure(EntityTypeBuilder<LanguageAudit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired();
        builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired();
        builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired();
        builder.Property(x => x.Icon).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Ignore(x => x.ActionTypeId);
        builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.DeviceName);
    }
}
