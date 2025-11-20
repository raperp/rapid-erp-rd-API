using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SubmoduleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.SubmoduleConfigurations;

public class SubmoduleConfiguration : IEntityTypeConfiguration<Submodule>
{
    public void Configure(EntityTypeBuilder<Submodule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(3).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
    }
}
