using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Table = RapidERP.Domain.Entities.TableModules.Table;

namespace RapidERP.Infrastructure.EntityConfiguration.TableConfigurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        //builder.Ignore(x => x.Language);
        //builder.Ignore(x => x.LanguageId);
        builder.Ignore(x => x.IsDefault);
        //builder.Ignore(x => x.IsDraft);
    }
}
