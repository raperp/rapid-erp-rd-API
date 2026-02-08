using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.MessageModuleModels;

namespace RapidERP.Infrastructure.EntityConfigurations.MessageModuleConfigurations;

public class MessageModuleHistoryConfiguration : IEntityTypeConfiguration<MessageModuleHistory>
{
    public void Configure(EntityTypeBuilder<MessageModuleHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        //builder.Property(x => x.Latitude).HasPrecision(9, 6);
        //builder.Property(x => x.Longitude).HasPrecision(9, 6);
        //builder.Property(x => x.DeviceName).HasMaxLength(10).IsRequired(false);
        //builder.Ignore(x => x.TenantId);
        //builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
