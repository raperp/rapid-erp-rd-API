using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TableModules;

namespace RapidERP.Infrastructure.EntityConfiguration.TableConfigurations;

public class TableHistoryConfiguration : IEntityTypeConfiguration<TableHistory>
{
    public void Configure(EntityTypeBuilder<TableHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        //builder.Property(x => x.ExportTypeId).IsRequired(false);
        //builder.Property(x => x.SourceURL).IsRequired(false);
        //builder.Property(x => x.ExportTo).IsRequired(false);
        //builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(8);
        //builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(9);
        //builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(10);
        //builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(11);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(12);
        //builder.Property(x => x.Latitude).HasPrecision(9, 6).HasColumnOrder(13);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6).HasColumnOrder(14);
        //builder.Property(x => x.ActionBy).HasColumnOrder(15);
        //builder.Property(x => x.ActionAt).HasColumnOrder(16);
        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);
        //builder.Ignore(x => x.LanguageId);
        
    }
}
