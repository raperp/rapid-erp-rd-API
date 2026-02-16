using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.EntityConfiguration.TenantConfigurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.MenuModuleId).HasColumnOrder(1);
        builder.Property(x => x.CountryId).IsRequired(false).HasColumnOrder(2);
        builder.Property(x => x.StateId).IsRequired(false).HasColumnOrder(3);
        //builder.Property(x => x.StatusTypeId).HasColumnOrder(4);
        //builder.Property(x => x.LanguageId).HasColumnOrder(5);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.Contact).HasMaxLength(30).IsRequired().HasColumnOrder(7);
        builder.Property(x => x.Phone).HasMaxLength(15).IsRequired().HasColumnOrder(8);
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired().HasColumnOrder(9);
        builder.Property(x => x.Address).HasMaxLength(30).IsRequired().HasColumnOrder(10);
        builder.Property(x => x.Email).HasMaxLength(20).IsRequired().HasColumnOrder(11);
        builder.Property(x => x.Website).HasMaxLength(20).IsRequired().HasColumnOrder(12);
        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.Country);
        //builder.Ignore(x => x.State);

        //builder.HasMany(x => x.Countries)
        //.WithOne(x => x.Tenant)
        //.HasForeignKey(x => x.TenantId)
        //.OnDelete(DeleteBehavior.NoAction);
    }
}
