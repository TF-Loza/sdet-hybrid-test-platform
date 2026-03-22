using Microsoft.Extensions.Configuration;

namespace ApiTests.Config;

public static class ConfigurationHelper
{
    private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    public static string BaseUrl => Configuration["ApiSettings:BaseUrl"]
        ?? throw new InvalidOperationException("ApiSettings:BaseUrl is missing from appsettings.json");
}