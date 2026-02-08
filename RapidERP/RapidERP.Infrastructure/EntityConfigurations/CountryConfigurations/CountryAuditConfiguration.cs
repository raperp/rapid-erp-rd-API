using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Infrastructure.EntityConfiguration.CountryConfigurations;
//public class CountryAuditConfiguration : IEntityTypeConfiguration<CountryAudit>
public class CountryAuditConfiguration  
{
    //public void Configure(EntityTypeBuilder<CountryAudit> builder)
    //{
    //    builder.HasKey(x => x.Id);
    //    builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
    //    builder.Property(x => x.ISO3Code).HasMaxLength(3).IsRequired();
    //    builder.Property(x => x.ISO2Code).HasMaxLength(2).IsRequired();
    //    builder.Property(x => x.ISONumeric).HasMaxLength(4).IsRequired();
    //    builder.Property(x => x.Code).HasMaxLength(4).IsRequired(false);

    //    //builder.Property(x => x.LanguageId).IsRequired(false);
    //}
}
