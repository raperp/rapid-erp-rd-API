using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.EntityConfiguration.TenantConfigurations;

public class TenantHistoryConfiguration : IEntityTypeConfiguration<TenantHistory>
{
    public void Configure(EntityTypeBuilder<TenantHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.TenantId).HasColumnOrder(1);
        builder.Property(x => x.MenuModuleId).IsRequired(false).HasColumnOrder(2);
        builder.Property(x => x.CountryId).IsRequired(false).HasColumnOrder(3);
        builder.Property(x => x.StateId).IsRequired(false).HasColumnOrder(4);
        //builder.Property(x => x.LanguageId).IsRequired(false).HasColumnOrder(5);
        builder.Property(x => x.CalendarId).IsRequired(false).HasColumnOrder(6);
        builder.Property(x => x.ActionTypeId).IsRequired(false).HasColumnOrder(7);
        //builder.Property(x => x.ExportTypeId).IsRequired(false).HasColumnOrder(8);
        //builder.Property(x => x.ExportTo).IsRequired(false).HasColumnOrder(9);
        //builder.Property(x => x.SourceURL).IsRequired(false).HasColumnOrder(10);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired(false).HasColumnOrder(11);
        builder.Property(x => x.Contact).HasMaxLength(30).IsRequired(false).HasColumnOrder(12);
        builder.Property(x => x.Phone).HasMaxLength(15).IsRequired(false).HasColumnOrder(13);
        builder.Property(x => x.Mobile).HasMaxLength(15).IsRequired(false).HasColumnOrder(14);
        builder.Property(x => x.Address).HasMaxLength(30).IsRequired(false).HasColumnOrder(15);
        builder.Property(x => x.Email).HasMaxLength(20).IsRequired(false).HasColumnOrder(16);
        builder.Property(x => x.Website).HasMaxLength(20).IsRequired(false).HasColumnOrder(17);
        builder.Property(x => x.LicenseNumber).HasMaxLength(20).IsRequired(false).HasColumnOrder(18);
        builder.Property(x => x.LimitUsers).HasMaxLength(4).IsRequired(false).HasColumnOrder(19);
        builder.Property(x => x.ERPPlan).HasMaxLength(20).IsRequired(false).HasColumnOrder(20);
        builder.Property(x => x.IssueAt).IsRequired(false).HasColumnOrder(21);
        builder.Property(x => x.ValidityDays).HasMaxLength(20).IsRequired(false).HasColumnOrder(22);
        builder.Property(x => x.ExpiryAt).HasMaxLength(20).IsRequired(false).HasColumnOrder(23);
        builder.Property(x => x.ReminderAt).HasMaxLength(20).IsRequired(false).HasColumnOrder(24);
        builder.Property(x => x.InterfaceLanguageId).IsRequired(false).HasColumnOrder(25);
        builder.Property(x => x.DataLanguageId).IsRequired(false).HasColumnOrder(26);
        builder.Property(x => x.DefaultLanguageId).IsRequired(false).HasColumnOrder(27);
        builder.Property(x => x.DefaultCalendarId).IsRequired(false).HasColumnOrder(28);
        //builder.Property(x => x.Browser).HasMaxLength(15).IsRequired().HasColumnOrder(29);
        //builder.Property(x => x.Location).HasMaxLength(40).IsRequired().HasColumnOrder(30);
        //builder.Property(x => x.DeviceIP).HasMaxLength(15).IsRequired().HasColumnOrder(31);
        //builder.Property(x => x.LocationURL).IsRequired().HasColumnOrder(32);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired().HasColumnOrder(33);
        //builder.Property(x => x.Latitude).HasPrecision(9, 6).IsRequired().HasColumnOrder(34);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6).IsRequired().HasColumnOrder(35);
        //builder.Property(x => x.ActionBy).IsRequired().HasColumnOrder(36);
        //builder.Property(x => x.ActionAt).IsRequired().HasColumnOrder(37);
        
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
