using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MainModuleModels;

namespace RapidERP.Infrastructure.EntityConfiguration.MainModuleConfigurations;

public class MainModuleConfiguration : IEntityTypeConfiguration<MainModule>
{
    public void Configure(EntityTypeBuilder<MainModule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(4).IsRequired();
        builder.Property(x => x.IconURL).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false);
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.DraftedBy).IsRequired(false);
        builder.Property(x => x.DraftedAt).IsRequired(false);
        builder.Property(x => x.DeletedBy).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);
        builder.Ignore(x => x.MenuModule);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.StatusType);
        builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
