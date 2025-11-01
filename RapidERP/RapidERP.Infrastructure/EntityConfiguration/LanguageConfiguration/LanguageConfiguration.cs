using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfiguration;
public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired();
        builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired();
        builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired();
        builder.Property(x => x.Icon).HasMaxLength(15).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
    }
}
