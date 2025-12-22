using Microsoft.Extensions.Hosting;
using Wolverine;

namespace RapidERP.Infrastructure.Extentions;

public static class RegisterWolverine
{
    public static void ConfigureWolverine(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseWolverine();
    }
}
