using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SolutionModels;

namespace RapidERP.Infrastructure.EntityConfigurations.SolutionConfigurations;

public class SolutionConfiguration : IEntityTypeConfiguration<Solution>
{
    public void Configure(EntityTypeBuilder<Solution> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.TenantId).HasColumnOrder(1);
        //builder.Property(x => x.MenuModuleId).HasColumnOrder(2);
        //builder.Property(x => x.LanguageId).HasColumnOrder(3);
        //builder.Property(x => x.StatusTypeId).HasColumnOrder(4);
        builder.Property(x => x.Code).HasMaxLength(3).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.Name).HasMaxLength(10).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.Icon).IsRequired(false).HasColumnOrder(7);
        builder.Property(x => x.Description).IsRequired(false).HasColumnOrder(8);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.Tenant);
    }
}
