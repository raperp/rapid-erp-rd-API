using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ExportTypeConfigurations;

public class ExportTypeConfiguration : IEntityTypeConfiguration<ExportType>
{
    public void Configure(EntityTypeBuilder<ExportType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Ignore(x => x.MenuModule);
        builder.Ignore(x => x.MenuModuleId);
        builder.Ignore(x => x.Tenant);
        builder.Ignore(x => x.TenantId);
        builder.Ignore(x => x.StatusType);
        builder.Ignore(x => x.StatusTypeId);
        builder.Ignore(x => x.IsDefault);
        builder.Ignore(x => x.IsDraft);
    }
}
