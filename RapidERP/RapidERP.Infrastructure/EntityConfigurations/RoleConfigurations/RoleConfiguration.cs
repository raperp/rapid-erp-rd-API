using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.RoleModules;

namespace RapidERP.Infrastructure.EntityConfigurations.RoleConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        //builder.Property(x => x.StatusTypeId).HasColumnOrder(1);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(2);
        //builder.Ignore(x => x.MenuModule);
        //builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.Language);
        //builder.Ignore(x => x.LanguageId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
