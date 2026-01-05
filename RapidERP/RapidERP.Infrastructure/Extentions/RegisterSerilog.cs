using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;

namespace RapidERP.Infrastructure.Extentions;

public static class RegisterSerilog
{
    public static void ConfigureSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        hostBuilder.UseSerilog((context, loggerConfiguration) => 
        {
            loggerConfiguration.WriteTo.Console();
            //loggerConfiguration.WriteTo.Seq("http://localhost:5341");
            //loggerConfiguration.WriteTo.File(new JsonFormatter(), "log.txt");
            //loggerConfiguration.WriteTo.MSSqlServer(configuration.GetConnectionString("RapidERPConnection"),
            //    new MSSqlServerSinkOptions
            //    {
            //        TableName = "Logs",
            //        SchemaName = "dbo",
            //        AutoCreateSqlDatabase = true,
            //        AutoCreateSqlTable = true
            //    });
        });
    }
}
