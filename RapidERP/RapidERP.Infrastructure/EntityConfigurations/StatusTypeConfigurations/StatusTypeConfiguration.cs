using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.StatusTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.StatusTypeConfigurations;
public class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
{
    public void Configure(EntityTypeBuilder<StatusType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(4).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.IsDefault).IsRequired(false);
        builder.Property(x => x.IsDraft).IsRequired(false);
    }
}
