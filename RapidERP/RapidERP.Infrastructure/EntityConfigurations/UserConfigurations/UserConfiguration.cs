using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.UserModels;

namespace RapidERP.Infrastructure.EntityConfigurations.UserConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.Address).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.OTP).HasMaxLength(15).IsRequired(false);
    }
}
