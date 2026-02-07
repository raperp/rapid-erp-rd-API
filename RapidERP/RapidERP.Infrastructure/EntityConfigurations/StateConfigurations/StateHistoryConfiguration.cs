using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SateModules;

namespace RapidERP.Infrastructure.EntityConfiguration.StateConfigurations
{
    public class StateHistoryConfiguration : IEntityTypeConfiguration<StateHistory>
    {
        public void Configure(EntityTypeBuilder<StateHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(0);
            builder.Property(x => x.StateId).HasColumnOrder(1);
            builder.Property(x => x.MenuModuleId).HasColumnOrder(2);
            builder.Property(x => x.CountryId).HasColumnOrder(3);
            //builder.Property(x => x.LanguageId).HasColumnOrder(4);
            builder.Property(x => x.ActionTypeId).HasColumnOrder(5);
            //builder.Property(x => x.ExportTypeId).HasColumnOrder(6);
            //builder.Property(x => x.ExportTo).IsRequired().HasColumnOrder(7);
            //builder.Property(x => x.SourceURL).IsRequired().HasColumnOrder(8);
            builder.Property(x => x.Code).HasMaxLength(4).IsRequired().HasColumnOrder(9);
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired().HasColumnOrder(10);
            builder.Property(x => x.IsDefault).HasColumnOrder(11);
            builder.Property(x => x.IsDraft).HasColumnOrder(12);
            //builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(13);
            //builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(14);
            //builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(15);
            //builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(16);
            //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(17);
            //builder.Property(x => x.Latitude).HasPrecision(9, 6).IsRequired().HasColumnOrder(18);
            //builder.Property(x => x.Longitude).HasPrecision(9, 6).IsRequired().HasColumnOrder(19);
            //builder.Property(x => x.ActionBy).IsRequired().HasColumnOrder(20);
            //builder.Property(x => x.ActionAt).IsRequired().HasColumnOrder(21);
            builder.Ignore(x => x.TenantId);
        }
    }
}
