using Microsoft.EntityFrameworkCore;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.SalesmanModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Infrastructure.Data;
public class RapidERPDbContext(DbContextOptions<RapidERPDbContext> options) : DbContext(options)
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageAudit> LanguageAudits { get; set; } 

    public DbSet<ExportType> ExportTypes { get; set; }
    public DbSet<ExportTypeAudit> ExportTypeAudits { get; set; } 

    public DbSet<ActionType> ActionTypes { get; set; }
    public DbSet<ActionTypeAudit> ActionTypeAudits { get; set; }

    public DbSet<StatusType> StatusTypes { get; set; }
    public DbSet<StatusTypeAudit> StatusTypeAudits { get; set; }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantAudit> TenantAudits { get; set; }

    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryAudit> CountryAudits { get; set; }

    public DbSet<State> States { get; set; }
    public DbSet<StateAudit> StateAudits { get; set; }

    public DbSet<Currency> Currencies { get; set; }
    public DbSet<CurrencyAudit> CurrencyAudits { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<CityAudit> CityAudits { get; set; }

    public DbSet<Area> Areas { get; set; }
    public DbSet<AreaAudit> AreaAudits { get; set; }

    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentAudit> DepartmentAudits { get; set; }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<DesignationAudit> DesignationAudits { get; set; }

    public DbSet<Salesman> Salesmen { get; set; }
    public DbSet<SalesmanAudit> SalesmanAudits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RapidERPDbContext).Assembly);
    }
}
