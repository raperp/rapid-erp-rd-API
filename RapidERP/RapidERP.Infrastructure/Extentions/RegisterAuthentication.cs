using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Extentions;

public static class RegisterAuthentication
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        


        return services;
    }
}
