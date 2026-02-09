using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TextModuleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.TextModuleConfigurations;

public class TextModuleConfiguration : IEntityTypeConfiguration<TextModule>
{
    public void Configure(EntityTypeBuilder<TextModule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.StatusType);
        //builder.Ignore(x => x.StatusTypeId);
    }
}
