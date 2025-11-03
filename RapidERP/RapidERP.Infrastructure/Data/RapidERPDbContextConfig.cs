using Microsoft.EntityFrameworkCore;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.Data;
public class RapidERPDbContextConfig(DbContextOptions<RapidERPDbContextConfig> options) : DbContext(options)
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageAudit> LanguageAudits { get; set; }
    public DbSet<LanguageTracker> LanguageTrackers { get; set; }

    public DbSet<ExportType> ExportTypes { get; set; }
    public DbSet<ExportTypeAudit> ExportTypeAudits { get; set; }
    public DbSet<ExportTypeTracker> ExportTypeTrackers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RapidERPDbContextConfig).Assembly);
        modelBuilder.Entity<ExportTypeAudit>().ToTable("ExportTypeAudits", x => x.ExcludeFromMigrations());
        modelBuilder.Entity<ExportTypeTracker>().ToTable("ExportTypeTrackers", x => x.ExcludeFromMigrations());
        modelBuilder.Entity<LanguageAudit>().ToTable("LanguageAudits", x => x.ExcludeFromMigrations());
        modelBuilder.Entity<LanguageTracker>().ToTable("LanguageTrackers", x => x.ExcludeFromMigrations());
    }
}
