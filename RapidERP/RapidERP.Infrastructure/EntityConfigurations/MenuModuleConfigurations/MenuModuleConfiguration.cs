using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MenuModuleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.MenuModuleConfigurations;

public class MenuModuleConfiguration : IEntityTypeConfiguration<MenuModule>
{
    public void Configure(EntityTypeBuilder<MenuModule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x => x.IconURL).IsRequired();
        builder.Property(x => x.SubmoduleId).IsRequired(false);
        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);
        //builder.Ignore(x => x.MenuModule);
        //builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.StatusType);
        //builder.Ignore(x => x.StatusTypeId);
        
        //builder.Ignore(x => x.SubmoduleId);

        //builder.HasMany(x => x.Submodules)
        //        .WithOne(x => x.Menu)
        //        .HasForeignKey(x => x.MenuId)
        //        .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Tenants)
                .WithOne(x => x.MenuModule)
                .HasForeignKey(x => x.MenuModuleId)
                .OnDelete(DeleteBehavior.NoAction);
    }
}
