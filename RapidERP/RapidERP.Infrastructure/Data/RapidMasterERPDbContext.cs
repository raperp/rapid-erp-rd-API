using Microsoft.EntityFrameworkCore;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Entities.OrderTypeModels;
using RapidERP.Domain.Entities.RiderModels;
using RapidERP.Domain.Entities.RoleModules;
using RapidERP.Domain.Entities.SalesmanModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Entities.SupplierModels;
using RapidERP.Domain.Entities.SupplierTypeModels;
using RapidERP.Domain.Entities.TableModules;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Entities.UserModels;

namespace RapidERP.Infrastructure.Data;

public class RapidMasterERPDbContext(DbContextOptions<RapidMasterERPDbContext> options) : DbContext(options)
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

    public DbSet<SupplierType> SupplierTypes { get; set; }
    public DbSet<SupplierTypeAudit> SupplierTypeAudits { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierAudit> SupplierAudits { get; set; }

    public DbSet<OrderType> OrderTypes { get; set; }
    public DbSet<OrderTypeAudit> OrderTypeAudits { get; set; }

    public DbSet<Rider> Riders { get; set; }
    public DbSet<RiderAudit> RiderAudits { get; set; }

    public DbSet<Table> Tables { get; set; }
    public DbSet<TableAudit> TableAudits { get; set; }

    public DbSet<Kitchen> Kitchens { get; set; }
    public DbSet<KitchenAudit> KitchenAudits { get; set; }

    public DbSet<MainModule> MainModules { get; set; }
    public DbSet<MainModuleAudit> MainModuleAudits { get; set; }

    public DbSet<Submodule> Submodules { get; set; }
    public DbSet<SubmoduleAudit> SubmoduleAudits { get; set; }

    public DbSet<MenuModule> MenuModules { get; set; }
    public DbSet<MenuModuleAudit> MenuModuleAudits { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<UserAudit> UserAudits { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleAudit> RoleAudits { get; set; }

    public DbSet<TextModule> TextModules { get; set; }
    public DbSet<TextModuleAudit> TextModuleAudits { get; set; }

    public DbSet<MessageModule> MessageModules { get; set; }
    public DbSet<MessageModuleAudit> MessageModuleAudits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RapidMasterERPDbContext).Assembly);
    }
}
