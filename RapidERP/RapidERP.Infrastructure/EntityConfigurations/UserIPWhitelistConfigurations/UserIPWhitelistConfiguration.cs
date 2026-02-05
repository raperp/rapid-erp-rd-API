using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.UserIPWhitelistModels;

namespace RapidERP.Infrastructure.EntityConfigurations.UserIPWhitelistConfigurations;

public class UserIPWhitelistConfiguration : IEntityTypeConfiguration<UserIPWhitelist>
{
    public void Configure(EntityTypeBuilder<UserIPWhitelist> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.StatusTypeId).HasColumnOrder(1);
        builder.Property(x => x.UserId).IsRequired().HasColumnOrder(2);
        builder.Property(x => x.IPAddress).HasMaxLength(15).IsRequired(false).HasColumnOrder(3);
        builder.Ignore(x => x.MenuModule);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.Language);
        //builder.Ignore(x => x.LanguageId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.Name);
    }
}
