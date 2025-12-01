using Microsoft.EntityFrameworkCore;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Entities.CalendarModels;
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
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Entities.SupplierModels;
using RapidERP.Domain.Entities.SupplierTypeModels;
using RapidERP.Domain.Entities.TableModules;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Entities.UserModels;
using Table = RapidERP.Domain.Entities.TableModules.Table;

namespace RapidERP.Infrastructure.Data;

public class RapidERPDbContext(DbContextOptions<RapidERPDbContext> options) : DbContext(options)
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageHistory> LanguageAudits { get; set; } 

    public DbSet<ExportType> ExportTypes { get; set; }
    public DbSet<ExportTypeHistory> ExportTypeAudits { get; set; } 

    public DbSet<ActionType> ActionTypes { get; set; }
    public DbSet<ActionTypeHistory> ActionTypeHistories { get; set; }

    public DbSet<StatusType> StatusTypes { get; set; }
    public DbSet<StatusTypeHistory> StatusTypeAudits { get; set; }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantLicense> TenantLicenses { get; set; }
    public DbSet<TenantLanguage> TenantLanguages { get; set; }
    public DbSet<TenantCalendar> TenantCalendars { get; set; }
    public DbSet<TenantHistory> TenantHistories { get; set; }

    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryHistory> CountryAudits { get; set; }

    public DbSet<State> States { get; set; }
    public DbSet<StateHistory> StateAudits { get; set; }

    public DbSet<Currency> Currencies { get; set; }
    public DbSet<CurrencyHistory> CurrencyAudits { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<CityHistory> CityAudits { get; set; }

    public DbSet<Area> Areas { get; set; }
    public DbSet<AreaHistory> AreaAudits { get; set; }

    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentHistory> DepartmentAudits { get; set; }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<DesignationHistory> DesignationAudits { get; set; }

    public DbSet<Salesman> Salesmen { get; set; }
    public DbSet<SalesmanHistory> SalesmanAudits { get; set; }

    public DbSet<SupplierType> SupplierTypes { get; set; }
    public DbSet<SupplierTypeHistory> SupplierTypeAudits { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierHistory> SupplierAudits { get; set; }

    public DbSet<OrderType> OrderTypes { get; set; }
    public DbSet<OrderTypeHistory> OrderTypeAudits { get; set; }

    public DbSet<Rider> Riders { get; set; }
    public DbSet<RiderHistory> RiderAudits { get; set; }

    public DbSet<Table> Tables { get; set; }
    public DbSet<TableHistory> TableAudits { get; set; }

    public DbSet<Kitchen> Kitchens { get; set; }
    public DbSet<KitchenHistory> KitchenAudits { get; set; }

    public DbSet<MainModule> MainModules { get; set; }
    public DbSet<MainModuleHistory> MainModuleAudits { get; set; }

    public DbSet<Submodule> Submodules { get; set; }
    public DbSet<SubmoduleHistory> SubmoduleAudits { get; set; }

    public DbSet<MenuModule> MenuModules { get; set; }
    public DbSet<MenuModuleHistory> MenuModuleAudits { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<UserHistory> UserAudits { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleHistory> RoleAudits { get; set; }

    public DbSet<TextModule> TextModules { get; set; }
    public DbSet<TextModuleHistory> TextModuleAudits { get; set; }

    public DbSet<MessageModule> MessageModules { get; set; }
    public DbSet<MessageModuleHistory> MessageModuleAudits { get; set; }

    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<CalendarHistory> CalendarHistories { get; set; }

    public DbSet<Solution> Solutions { get; set; }
    public DbSet<SolutionHistory> SolutionHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RapidERPDbContext).Assembly);
    }
}
