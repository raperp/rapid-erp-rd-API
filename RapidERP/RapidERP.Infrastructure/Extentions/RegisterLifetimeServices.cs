using Microsoft.Extensions.DependencyInjection;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Interfaces.Tenant;
using RapidERP.Infrastructure.Services;
using RapidERP.Infrastructure.Services.TenantServices;

namespace RapidERP.Infrastructure.Extentions;

public static class RegisterLifetimeServices
{
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IStatusType, StatusTypeService>();
        services.AddScoped<IActionType, ActionTypeService>();
        services.AddScoped<IExportType, ExportTypeService>();
        services.AddScoped<IArea, AreaService>();
        services.AddScoped<ILanguage, LanguageService>();
        services.AddScoped<ICity, CityService>();
        services.AddScoped<ITenant, TenantService>();
        services.AddScoped<ITenantLicense, TenantLicenseService>();
        services.AddScoped<ITenantLanguage, TenantLanguageService>();
        services.AddScoped<ITenantCalendar, TenantCalendarService>();
        services.AddScoped<ICurrency, CurrencyService>();
        services.AddScoped<ICountry, CountryService>();
        services.AddScoped<ILanguage, LanguageService>();
        services.AddScoped<IState, StateService>();
        services.AddScoped<IShared, SharedServices>();
        services.AddScoped<IDepartment, DepartmentService>();
        services.AddScoped<ISalesman, SalesmanService>();
        services.AddScoped<IDesignation, DesignationService>();
        services.AddScoped<IOrderType, OrderTypeService>();
        services.AddScoped<ITable, TableService>();
        services.AddScoped<IKitchen, KitchenService>();
        services.AddScoped<IRider, RiderService>();
        services.AddScoped<IMainModule, MainModuleService>();
        services.AddScoped<IMenuModule, MenuModuleService>();
        services.AddScoped<ISubmodule, SubmoduleService>();
        services.AddScoped<IUser, UserService>();
        services.AddScoped<IRole, RoleService>();
        services.AddScoped<ITextModule, TextModuleService>();
        services.AddScoped<IMessageModule, MessageModuleService>();

        return services;
    }
}
