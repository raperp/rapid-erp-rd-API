using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SolutionModels;

namespace RapidERP.Infrastructure.EntityConfigurations.SolutionConfigurations;

public class SolutionHistoryConfiguration : IEntityTypeConfiguration<SolutionHistory>
{
    public void Configure(EntityTypeBuilder<SolutionHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.SolutionId).HasColumnOrder(1);
        //builder.Property(x => x.TenantId).IsRequired(false).HasColumnOrder(2);
        //builder.Property(x => x.MenuModuleId).IsRequired(false).HasColumnOrder(3);
        //builder.Property(x => x.LanguageId).IsRequired(false).HasColumnOrder(4);
        builder.Property(x => x.ActionTypeId).IsRequired(false).HasColumnOrder(5);
        //builder.Property(x => x.ExportTypeId).IsRequired(false).HasColumnOrder(6);
        //builder.Property(x => x.ExportTo).IsRequired(false).HasColumnOrder(7);
        //builder.Property(x => x.SourceURL).IsRequired(false).HasColumnOrder(8);
        builder.Property(x => x.Code).HasMaxLength(3).IsRequired().HasColumnOrder(9);
        builder.Property(x => x.Name).HasMaxLength(10).IsRequired().HasColumnOrder(10);
        builder.Property(x => x.Icon).IsRequired(false).HasColumnOrder(11);
        builder.Property(x => x.Description).IsRequired(false).HasColumnOrder(12);
        //builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(13);
        //builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(14);
        //builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(15);
        //builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(16);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(17);
        //builder.Property(x => x.Latitude).HasPrecision(9, 6).IsRequired().HasColumnOrder(18);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6).IsRequired().HasColumnOrder(19);
        //builder.Property(x => x.ActionBy).IsRequired().HasColumnOrder(20);
        //builder.Property(x => x.ActionAt).IsRequired().HasColumnOrder(21);
        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);
    }
}
