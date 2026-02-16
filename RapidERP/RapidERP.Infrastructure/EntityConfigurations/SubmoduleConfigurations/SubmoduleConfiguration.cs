using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SubmoduleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.SubmoduleConfigurations;

public class SubmoduleConfiguration : IEntityTypeConfiguration<Submodule>
{
    public void Configure(EntityTypeBuilder<Submodule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x => x.IconURL).IsRequired();

        //builder.Ignore(x => x.MenuModule);
        //builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.StatusType);
        //builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);
    }
}
