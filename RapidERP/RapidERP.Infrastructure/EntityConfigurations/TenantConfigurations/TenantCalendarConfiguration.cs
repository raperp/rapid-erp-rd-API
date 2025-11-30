using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.EntityConfigurations.TenantConfigurations;

public class TenantCalendarConfiguration : IEntityTypeConfiguration<TenantCalendar>
{
    public void Configure(EntityTypeBuilder<TenantCalendar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.TenantId).HasColumnOrder(1);
        builder.Property(x => x.CalendarId).HasColumnOrder(2);
        builder.Property(x => x.DefaultCalendarId).HasColumnOrder(3);
        builder.Ignore(x => x.Name);
    }
}
