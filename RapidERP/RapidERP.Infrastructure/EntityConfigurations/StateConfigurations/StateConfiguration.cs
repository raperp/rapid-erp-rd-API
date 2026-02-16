using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SateModules;

namespace RapidERP.Infrastructure.EntityConfiguration.StateConfigurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        //builder.Property(x => x.MenuModuleId).HasColumnOrder(1);
        builder.Property(x => x.CountryId).HasColumnOrder(2);
        //builder.Property(x => x.StatusTypeId).HasColumnOrder(3);
        //builder.Property(x => x.LanguageId).HasColumnOrder(4);
        builder.Property(x => x.Code).HasMaxLength(4).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.IsDefault).HasColumnOrder(7);
        //builder.Property(x => x.IsDraft).HasColumnOrder(8);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.Tenant);

        //builder.HasMany(x => x.Tenants)
        //.WithOne(x => x.State)
        //.HasForeignKey(x => x.StateId)
        //.OnDelete(DeleteBehavior.NoAction);
    }
}
