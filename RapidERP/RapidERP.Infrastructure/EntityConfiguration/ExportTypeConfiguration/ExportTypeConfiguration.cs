using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ExportTypeConfiguration;

public class ExportTypeConfiguration : IEntityTypeConfiguration<ExportType>
{
    public void Configure(EntityTypeBuilder<ExportType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
    }
}
