using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MessageModuleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.MessageModuleConfigurations;

public class MessageModuleConfiguration : IEntityTypeConfiguration<MessageModule>
{
    public void Configure(EntityTypeBuilder<MessageModule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
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
        builder.Ignore(x => x.StatusType);
        builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.MenuModule);
        builder.Ignore(x => x.MenuModuleId);
    }
}
