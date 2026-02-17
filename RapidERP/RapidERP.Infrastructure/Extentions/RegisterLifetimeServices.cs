using Microsoft.Extensions.DependencyInjection;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Interfaces.Tenant;
using RapidERP.Application.Repository;
using RapidERP.Infrastructure.Data;
using RapidERP.Infrastructure.Services;
using RapidERP.Infrastructure.Services.CountryServices;
using RapidERP.Infrastructure.Services.TenantServices;

namespace RapidERP.Infrastructure.Extentions;

public static class RegisterLifetimeServices
{
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IStatusTypeService, StatusTypeService>();
        services.AddScoped<IActionTypeService, ActionTypeService>();
        services.AddScoped<IExportTypeService, ExportTypeService>();
        services.AddScoped<IAreaService, AreaService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<ITenantLicenseService, TenantLicenseService>();
        services.AddScoped<ITenantLanguageService, TenantLanguageService>();
        services.AddScoped<ITenantCalendarService, TenantCalendarService>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<ISharedService, SharedServices>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<ISalesmanService, SalesmanService>();
        services.AddScoped<IDesignationService, DesignationService>();
        services.AddScoped<IOrderTypeService, OrderTypeService>();
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IKitchenService, KitchenService>();
        services.AddScoped<IRiderService, RiderService>();
        services.AddScoped<IMainModuleService, MainModuleService>();
        services.AddScoped<IMenuModuleService, MenuModuleService>();
        services.AddScoped<ISubmoduleService, SubmoduleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ITextModuleService, TextModuleService>();
        services.AddScoped<IMessageModuleService, MessageModuleService>();
        services.AddScoped<ICalendarService, CalendarService>();
        services.AddScoped<ISolutionService, SolutionService>();
        services.AddScoped<ICommunicationService, CommunicationService>();
        services.AddScoped<IUserIPWhitelistService, UserIPWhitelistService>();
        services.AddScoped<IRepository, Repository.Repository>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ICountryLocalization, CountryLocalizationService>();
        services.AddScoped<ICountryExport, CountryExportService>();

        return services;
    }
}
