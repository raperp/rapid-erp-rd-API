using Microsoft.EntityFrameworkCore;
using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Infrastructure.Data;
public class RapidERPDbContext(DbContextOptions<RapidERPDbContext> options) : DbContext(options)
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageAudit> LanguageAudits { get; set; }
    public DbSet<LanguageTracker> LanguageTrackers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RapidERPDbContext).Assembly);
    }
}
