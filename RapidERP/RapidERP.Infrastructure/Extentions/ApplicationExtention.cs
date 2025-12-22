using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;

namespace RapidERP.Infrastructure.Extentions;

public static class ApplicationExtention
{
    public static void ConfigureSerilog(this IHostBuilder host, IConfiguration configuration)
    {
        host.UseSerilog((context, lc) => 
        {
            lc.WriteTo.Console();
            lc.WriteTo.Seq("http://localhost:5341");
            lc.WriteTo.File(new JsonFormatter(), "log.txt");
            lc.WriteTo.MSSqlServer(configuration.GetConnectionString("RapidERPConnection"),
                new MSSqlServerSinkOptions
                {
                    TableName = "Logs",
                    SchemaName = "dbo",
                    AutoCreateSqlDatabase = true,
                    AutoCreateSqlTable = true
                });
        });
    }
}
