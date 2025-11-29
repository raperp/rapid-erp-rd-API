using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfigurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired();
        builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired();
        builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired();
        builder.Property(x => x.IconURL).HasMaxLength(15).IsRequired();
        builder.Ignore(x => x.MenuModule);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.StatusType);
        builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.Language);
        builder.Ignore(x => x.LanguageId);

        builder.HasMany(x => x.Tenants)
            .WithOne(x => x.Language)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
