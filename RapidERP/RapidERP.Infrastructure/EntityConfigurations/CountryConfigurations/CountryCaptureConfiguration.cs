using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Infrastructure.EntityConfigurations.CountryConfigurations;

public class CountryCaptureConfiguration : IEntityTypeConfiguration<CountryCapture>
{
    public void Configure(EntityTypeBuilder<CountryCapture> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Ignore(x => x.Name);
    }
}
