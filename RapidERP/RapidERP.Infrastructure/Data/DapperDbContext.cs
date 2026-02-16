using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace RapidERP.Infrastructure.Data;

public class DapperDbContext(IConfiguration configuration)
{
    public IDbConnection ConnectDatabase() => new SqlConnection(configuration.GetConnectionString("RapidERPConnection"));
}
