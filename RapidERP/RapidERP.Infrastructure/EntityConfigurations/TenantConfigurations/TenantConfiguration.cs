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
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(11);
        builder.Property(x => x.Contact).HasMaxLength(30).IsRequired(false).HasColumnOrder(12);
        builder.Property(x => x.Phone).HasMaxLength(15).IsRequired(false).HasColumnOrder(13);
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired(false).HasColumnOrder(14);
        builder.Property(x => x.Address).HasMaxLength(30).IsRequired(false).HasColumnOrder(15);
        builder.Property(x => x.Email).HasMaxLength(20).IsRequired(false).HasColumnOrder(16);
        builder.Property(x => x.Website).HasMaxLength(20).IsRequired(false).HasColumnOrder(17);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);

        //builder.HasMany(x => x.Countries)
        //.WithOne(x => x.Tenant)
        //.HasForeignKey(x => x.TenantId)
        //.OnDelete(DeleteBehavior.NoAction);
    }
}
