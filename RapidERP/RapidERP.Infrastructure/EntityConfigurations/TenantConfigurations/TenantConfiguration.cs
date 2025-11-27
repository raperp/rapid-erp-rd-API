using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.EntityConfiguration.TenantConfigurations;
public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Contact).HasMaxLength(3).IsRequired(false);
        builder.Property(x => x.Phone).HasMaxLength(5).IsRequired(false);
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.Address).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.Website).HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false);
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.DraftedBy).IsRequired(false);
        builder.Property(x => x.DraftedAt).IsRequired(false);
        builder.Property(x => x.DeletedBy).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);
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
