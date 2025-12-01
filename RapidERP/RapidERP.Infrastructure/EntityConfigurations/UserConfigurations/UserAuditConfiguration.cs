using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.UserModels;

namespace RapidERP.Infrastructure.EntityConfigurations.UserConfigurations;

public class UserAuditConfiguration : IEntityTypeConfiguration<UserHistory>
{
    public void Configure(EntityTypeBuilder<UserHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.Address).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.OTP).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.ExportTypeId).IsRequired(false);
    }
}
