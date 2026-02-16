using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfigurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired().HasColumnOrder(1);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(2);
        builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired().HasColumnOrder(3);
        builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired().HasColumnOrder(4);
        builder.Property(x => x.IconURL).HasMaxLength(15).IsRequired().HasColumnOrder(5);
        //builder.Ignore(x => x.MenuModule);
        //builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.StatusType);
        //builder.Ignore(x => x.StatusTypeId);
        //builder.Ignore(x => x.Language);
        //builder.Ignore(x => x.LanguageId);
        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);

        //builder.HasMany(x => x.Tenants)
        //    .WithOne(x => x.Language)
        //    .HasForeignKey(x => x.LanguageId)
        //    .OnDelete(DeleteBehavior.NoAction);
    }
}
