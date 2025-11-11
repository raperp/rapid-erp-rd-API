using Microsoft.Extensions.DependencyInjection;
using RapidERP.Application.Interfaces;
using RapidERP.Infrastructure.Services;

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
        services.AddScoped<ICurrency, CurrencyService>();
        services.AddScoped<ICountry, CountryService>();
        services.AddScoped<ILanguage, LanguageService>();
        services.AddScoped<ITenant, TenantService>();
        services.AddScoped<IState, StateService>();
        //services.AddScoped<IStateLocalization, StateLocalizationService>();
        services.AddScoped<IDepartment, DepartmentService>();
        //services.AddScoped<IDepartmentLocalization, DepartmentLocalizationService>();
        services.AddScoped<IDesignation, DesignationService>();
        //services.AddScoped<IDesignationLocalization, DesignationLocalizationService>();

        return services;
    }
}
