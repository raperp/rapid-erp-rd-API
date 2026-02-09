using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ActionTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ActionTypeConfigurations;
public class ActionTypeConfiguration : IEntityTypeConfiguration<ActionType>
{
    public void Configure(EntityTypeBuilder<ActionType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        //builder.Property(x => x.LanguageId).HasColumnOrder(1);
        builder.Property(x => x.Name).HasMaxLength(10).IsRequired().HasColumnOrder(2);
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false).HasColumnOrder(3);
        //builder.Ignore(x => x.MenuModule);
        //builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.StatusType);
        //builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
