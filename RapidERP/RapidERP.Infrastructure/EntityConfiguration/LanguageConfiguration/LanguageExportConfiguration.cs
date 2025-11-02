using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.EntityConfiguration.LanguageConfiguration;
public class LanguageExportConfiguration : IEntityTypeConfiguration<LanguageExport>
{
    public void Configure(EntityTypeBuilder<LanguageExport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ExportTo).IsRequired();
        builder.Property(x => x.SourceURL).IsRequired();
    }
}
