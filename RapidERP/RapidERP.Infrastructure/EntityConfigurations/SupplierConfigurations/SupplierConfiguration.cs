using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SupplierModels;

namespace RapidERP.Infrastructure.EntityConfiguration.SupplierConfigurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.ContactPersonName).HasMaxLength(40).IsRequired(false);
        builder.Property(x => x.Website).IsRequired(false);
        builder.Property(x => x.Mobile).IsRequired(false);
        builder.Property(x => x.Email).IsRequired(false);
        builder.Property(x => x.PaymentTermsId).IsRequired(false);
        builder.Property(x => x.DueDays).IsRequired(false);
        builder.Property(x => x.DepositTypeId).IsRequired(false);
        builder.Property(x => x.PaymentTypeId).IsRequired(false);
        builder.Property(x => x.DepositAmount).HasPrecision(18, 2).IsRequired(false);
        builder.Property(x => x.ExchangeRate).HasPrecision(18, 2).IsRequired(false);
        builder.Property(x => x.LocalAmount).HasPrecision(18, 2).IsRequired(false);
    }
}
