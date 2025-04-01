using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Forge.Core.Logger.Extensions;

/// <summary>
/// Extension methods for registering the Forge.Core.Logger with dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Forge.Core.Logger to the DI container.
    /// It loads ForgeLogger configuration from appsettings.json if available, otherwise applies default settings.
    /// </summary>
    public static IServiceCollection AddForgeLogger(this IServiceCollection services, IConfiguration? configuration = null)
    {
        var loggerConfig = new LoggerConfiguration();
        var forgeLoggerSection = configuration?.GetSection("ForgeLogger");

        if (forgeLoggerSection.Exists())
        {
            loggerConfig.ReadFrom.Configuration(forgeLoggerSection);
        }

        var logger = loggerConfig.CreateLogger();
        Log.Logger = logger;

        services.AddSingleton<ILogger, Abstractions.Logger>();
        
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(logger, dispose: true);
        });

        return services;
    }
}