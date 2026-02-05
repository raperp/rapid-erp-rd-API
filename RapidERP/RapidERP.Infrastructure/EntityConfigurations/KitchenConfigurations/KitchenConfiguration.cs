using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.KitchenModels;

namespace RapidERP.Infrastructure.EntityConfiguration.KitchenConfigurations
{
    public class KitchenConfiguration : IEntityTypeConfiguration<Kitchen>
    {
        public void Configure(EntityTypeBuilder<Kitchen> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.PrinterId).IsRequired(false);
            builder.Ignore(x => x.IsDefault);
            builder.Ignore(x => x.IsDraft);
            builder.Ignore(x => x.IsDraft);
            //builder.Ignore(x => x.Language);
            //builder.Ignore(x => x.LanguageId);
        }
    }
}
