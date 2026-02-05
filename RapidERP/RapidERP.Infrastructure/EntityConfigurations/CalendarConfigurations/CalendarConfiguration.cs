using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calendar = RapidERP.Domain.Entities.CalendarModels.Calendar;

namespace RapidERP.Infrastructure.EntityConfigurations.CalendarConfigurations;

public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.TenantId).HasColumnOrder(1);
        builder.Property(x => x.MenuModuleId).HasColumnOrder(2);
        //builder.Property(x => x.LanguageId).HasColumnOrder(3);
        builder.Property(x => x.StatusTypeId).HasColumnOrder(4);
        builder.Property(x => x.Code).HasMaxLength(3).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.Name).HasMaxLength(10).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.StartDate).IsRequired(false).HasColumnOrder(7);
        builder.Property(x => x.EndDate).IsRequired(false).HasColumnOrder(8);
        builder.Property(x => x.TotalMonth).HasColumnOrder(9);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
        builder.Ignore(x => x.Tenant);
    }
}
