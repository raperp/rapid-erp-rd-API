using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Infrastructure.EntityConfiguration.CountryConfigurations;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.DialCode).HasMaxLength(4).IsRequired();
        builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired();
        builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired();
        builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired();
        builder.Property(x => x.TenantId).IsRequired(false);
        builder.Property(x => x.RegionId).IsRequired(false);
        builder.Property(x => x.StateId).IsRequired(false);
        builder.Property(x => x.TimeZoneId).IsRequired(false);

        builder.Ignore(x => x.Tenant);
        //builder.Ignore(x => x.Language);
        //builder.Ignore(x => x.LanguageId);
        
        builder.HasMany(x => x.States)
               .WithOne(x => x.Country)
               .HasForeignKey(x => x.CountryId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
