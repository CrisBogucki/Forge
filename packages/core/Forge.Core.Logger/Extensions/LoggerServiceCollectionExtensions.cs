using Forge.Core.Logger.Abstractions;
using Forge.Core.Logger.Features.Sinks.ConsoleSink;
using Forge.Core.Logger.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Extensions;

public static class LoggerBuilderExtensions
{
    public static ILoggingBuilder AddForgeLogger(this ILoggingBuilder builder, IConfiguration? configuration = null)
    {
        builder.ClearProviders();
        
        var options = new ForgeLoggerOptions();
        configuration?.GetSection("Logging:ForgeLogger").Bind(options);
        
        var sinks = new List<ILogSink>();
        
        if (options.Sinks.Console != null)
        {
            sinks.Add(new ConsoleSink(options.Sinks.Console));
        }
        
        var logger = new ForgeLogger(sinks);
        builder.AddProvider(new ForgeLoggerProvider(logger));
        
        return builder;
    }
}