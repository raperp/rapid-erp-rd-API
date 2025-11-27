using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidERP.Domain.Entities.SalesmanModels;

namespace RapidERP.Infrastructure.EntityConfiguration.SalesmanConfigurations;
public class SalesmanConfiguration : IEntityTypeConfiguration<Salesman>
{
    public void Configure(EntityTypeBuilder<Salesman> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(15).IsRequired(false);
        builder.Property(x => x.Commission).HasPrecision(18, 2).IsRequired(false);
        builder.Property(x => x.Territory).IsRequired(false);
        builder.Property(x => x.Experience).HasPrecision(18, 2).IsRequired(false);
        builder.Property(x => x.ManagerId).IsRequired(false);
        builder.Property(x => x.Phone).IsRequired();
        builder.Property(x => x.Email).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(200).IsRequired(false);
    }
}
