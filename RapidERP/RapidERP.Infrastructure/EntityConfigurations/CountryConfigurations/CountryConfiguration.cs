using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Infrastructure.EntityConfiguration.CountryConfigurations;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TenantId).IsRequired(false);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.DialCode).HasMaxLength(4).IsRequired();
        builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired();
        builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired();
        builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false);
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.DraftedBy).IsRequired(false);
        builder.Property(x => x.DraftedAt).IsRequired(false);
        builder.Property(x => x.SoftDeletedBy).IsRequired(false);
        builder.Property(x => x.SoftDeletedAt).IsRequired(false);
        builder.Property(x => x.RestoredBy).IsRequired(false);
        builder.Property(x => x.RestoredAt).IsRequired(false);
    }
}
