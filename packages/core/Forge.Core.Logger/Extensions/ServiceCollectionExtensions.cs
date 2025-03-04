using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Forge.Core.Logger.Extensions
{
    /// <summary>
    /// Extension methods for registering the Forge.Core.Logger with a dependency injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the default Forge.Core.Logger implementation to the service collection with console logging.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the logger to.</param>
        /// <returns>The updated IServiceCollection for chaining.</returns>
        public static IServiceCollection AddForgeLogger(this IServiceCollection services)
        {
            return services.AddSingleton<ILogger, Abstractions.Logger>();
        }

        /// <summary>
        /// Adds a customized Forge.Core.Logger implementation to the service collection with a user-defined configuration.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the logger to.</param>
        /// <param name="configure">An action to configure the LoggerConfiguration instance.</param>
        /// <returns>The updated IServiceCollection for chaining.</returns>
        public static IServiceCollection AddForgeLogger(this IServiceCollection services, Action<LoggerConfiguration> configure)
        {
            var config = new LoggerConfiguration();
            configure(config);
            return services.AddSingleton<ILogger>(new Abstractions.Logger(config));
        }
    }
}