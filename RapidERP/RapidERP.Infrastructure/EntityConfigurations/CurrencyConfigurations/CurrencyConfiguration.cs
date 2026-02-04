using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CurrencyModels;

namespace RapidERP.Infrastructure.EntityConfiguration.CurrencyConfigurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.TenantId).HasColumnOrder(1);
        builder.Property(x => x.MenuModuleId).HasColumnOrder(2);
        builder.Property(x => x.LanguageId).HasColumnOrder(3);
        builder.Property(x => x.StatusTypeId).HasColumnOrder(4);
        builder.Property(x => x.Code).HasMaxLength(4).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.Icon).IsRequired(false).HasColumnOrder(7);
        builder.Property(x => x.IsDefault).IsRequired().HasColumnOrder(8);
        builder.Property(x => x.IsDraft).IsRequired().HasColumnOrder(9);
        
        //builder.HasMany(x => x.Countries)
        //        .WithOne(x => x.Currency)
        //        .HasForeignKey(x => x.CurrencyId)
        //        .OnDelete(DeleteBehavior.NoAction);
    }
}
