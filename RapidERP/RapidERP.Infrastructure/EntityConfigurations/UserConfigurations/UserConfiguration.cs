using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.UserModels;

namespace RapidERP.Infrastructure.EntityConfigurations.UserConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.RoleId).HasColumnOrder(1);
        //builder.Property(x => x.StatusTypeId).HasColumnOrder(2);
        builder.Property(x => x.Name).HasMaxLength(30).IsRequired().HasColumnOrder(3);
        builder.Property(x => x.Address).HasMaxLength(80).IsRequired(false).HasColumnOrder(4);
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired(false).HasColumnOrder(5);
        builder.Property(x => x.Email).HasMaxLength(20).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.UserName).HasMaxLength(15).IsRequired().HasColumnOrder(7);
        builder.Property(x => x.Password).HasMaxLength(10).IsRequired().HasColumnOrder(8);
        builder.Property(x => x.OTP).HasMaxLength(15).IsRequired(false).HasColumnOrder(9);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.MenuModule);
        //builder.Ignore(x => x.MenuModuleId);
        //builder.Ignore(x => x.Language);
        //builder.Ignore(x => x.LanguageId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
