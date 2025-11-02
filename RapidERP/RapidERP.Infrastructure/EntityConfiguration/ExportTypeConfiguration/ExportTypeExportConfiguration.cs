using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.ExportTypeConfiguration;
public class ExportTypeExportConfiguration : IEntityTypeConfiguration<ExportTypeExport>
{
    public void Configure(EntityTypeBuilder<ExportTypeExport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ExportTo).IsRequired();
        builder.Property(x => x.SourceURL).IsRequired();
    }
}
