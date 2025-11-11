using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.StatusTypeModels;

namespace RapidERP.Infrastructure.EntityConfiguration.StatusTypeConfiguration;

public class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
{
    public void Configure(EntityTypeBuilder<StatusType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Ignore(x => x.StatusType);
        builder.Ignore(x => x.StatusTypeId);
    }
}
