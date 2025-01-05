using Microsoft.Extensions.Configuration;

namespace TodoEc2.Infrastructure.Extension
{
    public static class ConfigurationExtension
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("ConnectionSQLServer")!;
        }
    }
}
