using Microsoft.Extensions.DependencyInjection;
using RapidERP.Application.Interfaces;
using RapidERP.Infrastructure.Services;

namespace RapidERP.Infrastructure.Extentions;
public static class RegisterLifetimeServices
{
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IExportType, ExportTypeService>();
        
        return services;
    }
}
