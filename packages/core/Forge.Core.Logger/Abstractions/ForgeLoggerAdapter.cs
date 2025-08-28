using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Abstractions;

internal class ForgeLoggerAdapter(ForgeLogger forgeLogger, string categoryName)
    : Microsoft.Extensions.Logging.ILogger
{
    public IDisposable BeginScope<TState>(TState state) => null!;

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var message = formatter(state, exception);
        forgeLogger.Log(logLevel, $"{categoryName} [{eventId.Id}]: {message}",
            exception);
    }
}