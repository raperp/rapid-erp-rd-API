using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MainModuleModels;

namespace RapidERP.Infrastructure.EntityConfiguration.MainModuleConfigurations;

public class MainModuleConfiguration : IEntityTypeConfiguration<MainModule>
{
    public void Configure(EntityTypeBuilder<MainModule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(3).IsRequired(false);
        builder.Property(x => x.IconURL).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
    }
}
