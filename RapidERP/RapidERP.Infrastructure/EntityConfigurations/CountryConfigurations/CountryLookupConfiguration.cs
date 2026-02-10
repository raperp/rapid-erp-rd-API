using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Infrastructure.EntityConfigurations.CountryConfigurations;

public class CountryLookupConfiguration : IEntityTypeConfiguration<CountryLookup>
{
    public void Configure(EntityTypeBuilder<CountryLookup> builder)
    {
        builder.HasKey(x => x.Id);
        //builder.Property(x => x.CountryId).IsRequired(false);
        //builder.Property(x => x.LanguageId).IsRequired(false);
        //builder.Property(x => x.Localization).IsRequired(false);
        builder.Property(x => x.ISONumeric).IsRequired(false);
        builder.Property(x => x.ISO2Code).IsRequired(false);
        builder.Property(x => x.ISO3Code).IsRequired(false);
    }
}
