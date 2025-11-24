using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MenuModules;

namespace RapidERP.Infrastructure.EntityConfigurations.MenuConfigurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(3).IsRequired(false);
        builder.Property(x => x.SubModuleId).IsRequired(false);
        builder.Property(x => x.IconURL).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Ignore(x => x.Menu);
        builder.Ignore(x => x.MenuId);
    }
}
