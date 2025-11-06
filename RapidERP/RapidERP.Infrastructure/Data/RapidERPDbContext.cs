using Microsoft.EntityFrameworkCore;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.Data;
public class RapidERPDbContext(DbContextOptions<RapidERPDbContext> options) : DbContext(options)
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageAudit> LanguageAudits { get; set; } 

    public DbSet<ExportType> ExportTypes { get; set; }
    public DbSet<ExportTypeAudit> ExportTypeAudits { get; set; } 

    public DbSet<ActionType> ActionTypes { get; set; }
    public DbSet<ActionTypeAudit> ActionTypeAudits { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RapidERPDbContext).Assembly);
        modelBuilder.Entity<ActionType>().ToTable("ActionTypes", x => x.ExcludeFromMigrations());
        modelBuilder.Entity<ActionTypeAudit>().ToTable("ActionTypeAudits", x => x.ExcludeFromMigrations());
    }
}
