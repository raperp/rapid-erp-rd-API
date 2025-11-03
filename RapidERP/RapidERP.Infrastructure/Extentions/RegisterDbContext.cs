using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Extentions;
public static class RegisterDbContext
{
    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RapidERPConnectionConfig") ?? throw new InvalidOperationException("Connection string 'RapidERPConnectionConfig' not found.");

        services.AddDbContext<RapidERPDbContextConfig>(options => {
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddDbContextWrite(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RapidERPConnectionConfigWrite") ?? throw new InvalidOperationException("Connection string 'RapidERPConnectionConfigWrite' not found.");

        services.AddDbContext<RapidERPDbContextWrite>(options => {
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddDbContextRead(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RapidERPConnectionConfigRead") ?? throw new InvalidOperationException("Connection string 'RapidERPConnectionConfigRead' not found.");

        services.AddDbContext<RapidERPDbContextRead>(options => {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
