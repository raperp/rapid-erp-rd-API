using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.RiderModels;

namespace RapidERP.Infrastructure.EntityConfiguration.RiderConfigurations;

public class RiderConfiguration : IEntityTypeConfiguration<Rider>
{
    public void Configure(EntityTypeBuilder<Rider> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.MobileNumber).HasMaxLength(15).IsRequired(false);
    }
}
