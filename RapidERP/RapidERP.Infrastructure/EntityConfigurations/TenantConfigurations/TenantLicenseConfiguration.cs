using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.EntityConfigurations.TenantConfigurations;

public class TenantLicenseConfiguration : IEntityTypeConfiguration<TenantLicense>
{
    public void Configure(EntityTypeBuilder<TenantLicense> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.TenantId).HasColumnOrder(1);
        builder.Property(x => x.LicenseNumber).HasMaxLength(20).HasColumnOrder(2);
        builder.Property(x => x.LimitUsers).HasMaxLength(4).HasColumnOrder(3);
        builder.Property(x => x.ERPPlan).HasMaxLength(20).HasColumnOrder(4);
        builder.Property(x => x.IssueAt).HasColumnOrder(5);
        builder.Property(x => x.ValidityDays).HasMaxLength(20).HasColumnOrder(6);
        builder.Property(x => x.ExpiryAt).HasMaxLength(20).HasColumnOrder(7);
        builder.Property(x => x.ReminderAt).HasMaxLength(20).HasColumnOrder(8);
        builder.Ignore(x => x.Name);
    }
}
