using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CurrencyModels;

namespace RapidERP.Infrastructure.EntityConfiguration.CurrencyConfigurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.Property(x => x.Id);
        builder.Property(x => x.TenantId); 
        builder.Property(x => x.Code).HasMaxLength(4).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Icon).IsRequired(false);
        //builder.Property(x => x.IsDefault).IsRequired(false);
        //builder.Property(x => x.IsDraft).IsRequired(false);

        //builder.HasMany(x => x.Countries)
        //        .WithOne(x => x.Currency)
        //        .HasForeignKey(x => x.CurrencyId)
        //        .OnDelete(DeleteBehavior.NoAction);
    }
}
