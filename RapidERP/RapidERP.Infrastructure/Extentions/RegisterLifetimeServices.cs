using Microsoft.Extensions.DependencyInjection;
using RapidERP.Application.Interfaces;
using RapidERP.Infrastructure.Services;

namespace RapidERP.Infrastructure.Extentions;
public static class RegisterLifetimeServices
{
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        //services.AddScoped<IStatusType, StatusTypeService>();
        //services.AddScoped<IActionType, ActionTypeService>();
        services.AddScoped<IExportType, ExportTypeService>();
        //services.AddScoped<IDocumentTypeService, DocumentTypeService>();
        //services.AddScoped<ILanguage, LanguageService>();
        //services.AddScoped<ILanguageLocalization, LanguageLocalizationService>();
        //services.AddScoped<IOrganization, OrganizationService>();
        //services.AddScoped<ICurrency, CurrencyService>();
        //services.AddScoped<ICurrencyLocalization, CurrencyLocalizationService>();
        //services.AddScoped<ICountry, CountryService>();
        //services.AddScoped<ICountryLocalization, CountryLocalizationService>();
        //services.AddScoped<IState, StateService>();
        //services.AddScoped<IStateLocalization, StateLocalizationService>();
        //services.AddScoped<IDepartment, DepartmentService>();
        //services.AddScoped<IDepartmentLocalization, DepartmentLocalizationService>();
        //services.AddScoped<IDesignation, DesignationService>();
        //services.AddScoped<IDesignationLocalization, DesignationLocalizationService>();

        return services;
    }
}
