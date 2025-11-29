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
        
        services.AddDbContext<RapidERPDbContext>(options => {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
