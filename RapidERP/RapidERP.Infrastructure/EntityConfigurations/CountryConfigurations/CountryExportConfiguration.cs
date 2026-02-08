using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Infrastructure.EntityConfigurations.CountryConfigurations;

public class CountryExportConfiguration : IEntityTypeConfiguration<CountryExport>
{
    public void Configure(EntityTypeBuilder<CountryExport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Ignore(x => x.Name);
    }
}
