using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ActionTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ActionTypeConfigurations;
public class ActionTypeConfiguration : IEntityTypeConfiguration<ActionType>
{
    public void Configure(EntityTypeBuilder<ActionType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false);
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.DraftedBy).IsRequired(false);
        builder.Property(x => x.DraftedAt).IsRequired(false);
        builder.Property(x => x.DeletedBy).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);
        builder.Ignore(x => x.Menu);
        builder.Ignore(x => x.MenuId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.StatusType);
        builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
