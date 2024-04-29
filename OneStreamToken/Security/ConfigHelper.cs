namespace OneStreamToken.Security
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot _configuration;

        static ConfigHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static string GetValue(string key)
        {
            return _configuration[key] ?? "";
        }

        public static string GetSectionValue(string sectionName, string subSectionName, string key)
        {
            return _configuration.GetSection($"{sectionName}:{subSectionName}:{key}").Value ?? "";
        }
        public static string GetSectionValue(string sectionName, string key)
        {
            return _configuration.GetSection($"{sectionName}:{key}").Value ?? "";
        }

        public static string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name) ?? "";
        }
    }
}
