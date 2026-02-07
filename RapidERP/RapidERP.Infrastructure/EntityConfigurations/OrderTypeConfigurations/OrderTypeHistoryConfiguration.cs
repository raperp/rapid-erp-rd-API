using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.OrderTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.OrderTypeConfigurations;

public class OrderTypeHistoryConfiguration : IEntityTypeConfiguration<OrderTypeHistory>
{
    public void Configure(EntityTypeBuilder<OrderTypeHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        //builder.Property(x => x.Latitude).HasPrecision(9, 6);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        //builder.Property(x => x.ExportTypeId).IsRequired(false);
        //builder.Property(x => x.SourceURL).IsRequired(false);
        //builder.Property(x => x.ExportTo).IsRequired(false);
    }
}
