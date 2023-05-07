using Microsoft.Extensions.Configuration;

namespace CorePlugin.Plugin;

public static class ConfigurationExtensions
{
    public static string? GetConnectionString(this IConfiguration configuration, string name, bool isDevelopment = false)
        => Microsoft.Extensions.Configuration.ConfigurationExtensions
            .GetConnectionString(configuration, isDevelopment ? name : "Production")?
            .Replace("core", name.ToLower()) ?? null;
}
