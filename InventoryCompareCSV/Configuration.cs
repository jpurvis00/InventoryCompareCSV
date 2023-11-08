
using Microsoft.Extensions.Configuration;

namespace InventoryCompareCSV
{
    internal class Configuration
    {
        public static string InitializeConfiguration()
        {
            IConfiguration _config;
            string _csvFile = string.Empty;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile($"appsettings.{environment}.json")
                .AddEnvironmentVariables();

            _config = builder.Build();

            /* Created two different "Prod" environments. I installed this on two different machines
             * and the downloads directory had a different path.
             * Production = work computer
             * Production2 = laptop
             */
            if (environment == "Development")
            {
                _csvFile = _config.GetValue<string>("devFilePath");
            }
            else if(environment == "Production")
            {
                _csvFile = _config.GetValue<string>("prodFilePath");
            }
            else if(environment == "Production2")
            {
                _csvFile = _config.GetValue<string>("prod2FilePath");
            }
                return _csvFile;
        }
    }
}
