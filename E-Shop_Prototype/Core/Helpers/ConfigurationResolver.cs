using Microsoft.Extensions.Configuration;

namespace E_Shop_Mini.Helpers
{
    public static class ConfigurationResolver
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}