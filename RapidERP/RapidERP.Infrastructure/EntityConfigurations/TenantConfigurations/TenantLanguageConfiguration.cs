using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.EntityConfigurations.TenantConfigurations;

public class TenantLanguageConfiguration : IEntityTypeConfiguration<TenantLanguage>
{
    public void Configure(EntityTypeBuilder<TenantLanguage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.TenantId).HasColumnOrder(1);
        builder.Property(x => x.InterfaceLanguageId).HasColumnOrder(2);
        builder.Property(x => x.DataLanguageId).HasColumnOrder(3);
        builder.Property(x => x.DefaultLanguageId).HasColumnOrder(4);
        builder.Ignore(x => x.Name);
    }
}
