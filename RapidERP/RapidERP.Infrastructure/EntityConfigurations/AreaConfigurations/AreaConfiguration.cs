using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.AreaModules;

namespace RapidERP.Infrastructure.EntityConfiguration.AreaConfigurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(3).IsRequired(false);
        }
    }
}
