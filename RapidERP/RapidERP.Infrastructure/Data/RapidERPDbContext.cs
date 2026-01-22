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
using RapidERP.Domain.Entities.UserIPWhitelistModels;
using RapidERP.Domain.Entities.UserModels;
using Table = RapidERP.Domain.Entities.TableModules.Table;

namespace RapidERP.Infrastructure.Data;

public class RapidERPDbContext(DbContextOptions<RapidERPDbContext> options) : DbContext(options)
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageHistory> LanguageHistory { get; set; } 
    public DbSet<LanguageTemplate> LanguageTemplate { get; set; } 

    public DbSet<ExportType> ExportTypes { get; set; }
    public DbSet<ExportTypeHistory> ExportTypeHistory { get; set; } 
    public DbSet<ExportTypeTemplate> ExportTypeTemplate { get; set; } 

    public DbSet<ActionType> ActionTypes { get; set; }
    public DbSet<ActionTypeHistory> ActionTypeHistory { get; set; }
    public DbSet<ActionTypeTemplate> ActionTypeTemplate { get; set; }

    public DbSet<StatusType> StatusTypes { get; set; }
    public DbSet<StatusTypeHistory> StatusTypeHistory { get; set; }
    public DbSet<StatusTypeTemplate> StatusTypeTemplate { get; set; }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantLicense> TenantLicenses { get; set; }
    public DbSet<TenantLanguage> TenantLanguages { get; set; }
    public DbSet<TenantCalendar> TenantCalendars { get; set; }
    public DbSet<TenantHistory> TenantHistory { get; set; }
    public DbSet<TenantTemplate> TenantTemplate { get; set; }

    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryHistory> CountryHistory { get; set; }
    public DbSet<CountryTemplate> CountryTemplate { get; set; }

    public DbSet<State> States { get; set; }
    public DbSet<StateHistory> StateHistory { get; set; }
    public DbSet<StateTemplate> StateTemplate { get; set; }

    public DbSet<Currency> Currencies { get; set; }
    public DbSet<CurrencyHistory> CurrencyHistory { get; set; }
    public DbSet<CurrencyTemplate> CurrencyTemplate { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<CityHistory> CityHistory { get; set; }
    public DbSet<CityTemplate> CityTemplate { get; set; }

    public DbSet<Area> Areas { get; set; }
    public DbSet<AreaHistory> AreaHistory { get; set; }
    public DbSet<AreaTemplate> AreaTemplate { get; set; }

    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentHistory> DepartmentHistory { get; set; }
    public DbSet<DepartmentTemplate> DepartmentTemplate { get; set; }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<DesignationHistory> DesignationHistory { get; set; }
    public DbSet<DesignationTemplate> DesignationTemplate { get; set; }

    public DbSet<Salesman> Salesmen { get; set; }
    public DbSet<SalesmanHistory> SalesmanHistory { get; set; }

    public DbSet<SupplierType> SupplierTypes { get; set; }
    public DbSet<SupplierTypeHistory> SupplierTypeHistory { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierHistory> SupplierHistory { get; set; }

    public DbSet<OrderType> OrderTypes { get; set; }
    public DbSet<OrderTypeHistory> OrderTypeHistory { get; set; }

    public DbSet<Rider> Riders { get; set; }
    public DbSet<RiderHistory> RiderHistory { get; set; }

    public DbSet<Table> Tables { get; set; }
    public DbSet<TableHistory> TableHistory { get; set; }

    public DbSet<Kitchen> Kitchens { get; set; }
    public DbSet<KitchenHistory> KitchenHistory { get; set; }
    public DbSet<KitchenTemplate> KitchenTemplate { get; set; }

    public DbSet<MainModule> MainModules { get; set; }
    public DbSet<MainModuleHistory> MainModuleHistory { get; set; }
    public DbSet<MainModuleTemplate> MainModuleTemplate { get; set; }

    public DbSet<Submodule> Submodules { get; set; }
    public DbSet<SubmoduleHistory> SubmoduleHistory { get; set; }
    public DbSet<SubmoduleTemplate> SubmoduleTemplate { get; set; }

    public DbSet<MenuModule> MenuModules { get; set; }
    public DbSet<MenuModuleHistory> MenuModuleHistory { get; set; }
    public DbSet<MenuModuleTemplate> MenuModuleTemplate { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<UserHistory> UserHistory { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleHistory> RoleHistory { get; set; }

    public DbSet<TextModule> TextModules { get; set; }
    public DbSet<TextModuleHistory> TextModuleHistory { get; set; }
    public DbSet<TextModuleTemplate> TextModuleTemplate { get; set; }

    public DbSet<MessageModule> MessageModules { get; set; }
    public DbSet<MessageModuleHistory> MessageModuleHistory { get; set; }
    public DbSet<MessageModuleTemplate> MessageModuleTemplate { get; set; }

    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<CalendarHistory> CalendarHistory { get; set; }
    public DbSet<CalendarTemplate> CalendarTemplate { get; set; }

    public DbSet<Solution> Solutions { get; set; }
    public DbSet<SolutionHistory> SolutionHistory { get; set; }
    public DbSet<SolutionTemplate> SolutionTemplate { get; set; }

    public DbSet<UserIPWhitelist> UserIPWhitelists { get; set; }
    public DbSet<UserIPWhitelistHistory> UserIPWhitelistHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RapidERPDbContext).Assembly);
    }
}
