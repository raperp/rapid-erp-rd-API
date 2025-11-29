using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Extentions;
public static class RegisterDbContext
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RapidERPConnection") ?? throw new InvalidOperationException("Connection string 'RapidERPConnection' not found.");
        var RapidMasterConnectionString = configuration.GetConnectionString("RapidMasterConnection") ?? throw new InvalidOperationException("Connection string 'RapidMasterConnection' not found.");
        var RapidHRMConnectionString = configuration.GetConnectionString("RapidHRMConnection") ?? throw new InvalidOperationException("Connection string 'RapidHRMConnection' not found.");
        var RapidMSDConnectionString = configuration.GetConnectionString("RapidMSDConnection") ?? throw new InvalidOperationException("Connection string 'RapidMSDConnection' not found.");

        services.AddDbContext<RapidERPDbContext>(options => {
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<RapidMasterERPDbContext>(options => {
            options.UseSqlServer(RapidMasterConnectionString);
        });

        services.AddDbContext<RapidHRMDbContext>(options => {
            options.UseSqlServer(RapidHRMConnectionString);
        });

        services.AddDbContext<RapidMSDDbContext>(options => {
            options.UseSqlServer(RapidMSDConnectionString);
        });

        return services;
    }
}
