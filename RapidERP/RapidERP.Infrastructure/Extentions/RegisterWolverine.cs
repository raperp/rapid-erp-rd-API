using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RapidERP.Application.Assembly;
using Wolverine;

namespace RapidERP.Infrastructure.Extentions;

public static class RegisterWolverine
{
    public static void ConfigureWolverine(this IHostBuilder hostBuilder, IServiceCollection services)
    {
        hostBuilder.UseWolverine(opts =>
        {
            opts.Discovery.IncludeAssembly(typeof(RapidERPApplication).Assembly);
        });
    }
}
