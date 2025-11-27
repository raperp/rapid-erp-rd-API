using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SateModules;

namespace RapidERP.Infrastructure.EntityConfiguration.StateConfigurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(4).IsRequired();
        builder.Property(x => x.MenuId).IsRequired(false);
        builder.Property(x => x.TenantId).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Ignore(x => x.Tenant);

        builder.HasMany(x => x.Tenants)
        .WithOne(x => x.State)
        .HasForeignKey(x => x.StateId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
